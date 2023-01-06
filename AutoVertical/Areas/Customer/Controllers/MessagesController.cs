using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IUnitOfWork _db;
        public MessagesController(IUnitOfWork db)
        {
            _db = db;
        }


        public IActionResult CreateConversation(string AdvertUserId,string VehicleId)
        {
             ///
            ///     <summary> Get logged user id </summary>
            ///

            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);

            string CurrentlyLoggedUser = claim.Value;

            ///
            ///     <summary> Check if user don't want create conversation with himself </summary>
            ///
            if(AdvertUserId == CurrentlyLoggedUser)
            {
                TempData["Error"] = "You are owner of this advert, Have you wanted chat alone with yourself ?";
                return RedirectToAction("ShowAnnouncement", "Announcement", new {identifier = VehicleId});
            }
            ///
            ///     <summary> Check if conversation between this users don't alredy exist </summary>
            ///

            Conversation? ExistingConversation = _db.conversation.GetFirstOfDefault(u=>u.UserOneId == AdvertUserId && u.UserTwoId == CurrentlyLoggedUser );

            if(ExistingConversation == null) 
            {
                ExistingConversation = _db.conversation.GetFirstOfDefault(u=>u.UserOneId == CurrentlyLoggedUser && u.UserTwoId == AdvertUserId );
                if(ExistingConversation == null)
                {
                    ///
                    ///     <summary>Conversation between these doesn't exist ! => Create conversation </summary>
                    ///
                    Conversation conversation = new Conversation(){
                        UserOneId = CurrentlyLoggedUser,
                        UserTwoId = AdvertUserId
                    };

                    _db.conversation.Add(conversation);
                    _db.Save();
                }
            }


            return RedirectToAction("Index","UserProfile", new { tab = "MessagesTab"});
        }

        [HttpPost]
        public IActionResult DeleteConversation(int ConversationId) 
        {
            Conversation conversation = _db.conversation.GetFirstOfDefault(u=>u.Id== ConversationId);
            IEnumerable<Message> convMessages = _db.messages.GetAll(u=>u.ConversationId ==conversation.Id);

            //Remove Messages
            _db.messages.RemoveRange(convMessages);
            _db.Save();
            //Remove Conversation
            _db.conversation.Remove(conversation);
            _db.Save();
            return RedirectToAction("Index","UserProfile", new {tab = "MessagesTab"});

        }

        #region API
        [HttpGet]
        public IActionResult GetConversationMessages(int ConversationId)
        {
            ///
            ///     <summary> Get conversation by ID </summary>
            ///
            Conversation conversation = _db.conversation.GetFirstOfDefault(u=>u.Id== ConversationId);

            if(conversation == null)
            {
                return NotFound();
            }

            ///
            ///     <summary> Get logged user id </summary>
            ///

            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);

            string UserId = claim.Value;

            ///
            ///     <summary> If request comes from logged user session load all messages of this conversation  </summary>
            ///

            if(conversation.UserOneId == UserId || conversation.UserTwoId == UserId) 
            {
                 List<Message> messages = _db.messages.GetAll(u=>u.ConversationId== ConversationId,includeProperties:"MessageSenderUser").ToList();
                 conversation.LoggedUserId = UserId;
                 foreach(Message mess in messages)
                 {
                    mess.Conversation =  conversation;
                 }
                messages = messages.OrderBy(u=>u.Date).ToList();
                return Json(messages);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateMessage(int ConversationId,string content)
        {
            if(ConversationId == 0)
            {
                return NotFound();
            }
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);

            string UserId = claim.Value;

            Message mess = new Message()
            {  
                ConversationId =  ConversationId,
                UserId = UserId,
                Date = DateTime.Now,
                Contents = content
            };
            _db.messages.Add(mess);
            _db.Save();

            return RedirectToAction("GetConversationMessages",new {ConversationId = ConversationId});
        }
        #endregion
    }
}
