using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class MessagesTab:ViewComponent
    {
         private readonly IUnitOfWork _db;
        public MessagesTab(IUnitOfWork db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            //Get current logged user to show him messages
            string CurrentUserId = userPanel.User.Id;

            //Get conversation with current  user are member
            List<Conversation> Conversations = _db.conversation.GetAll(u=>u.UserOneId == CurrentUserId || u.UserTwoId == CurrentUserId ).ToList();

            //Get user whos chat with our logged user
            //Him id can be saved in column "UserOneId" or "UserTwoId" so we have to check both
            foreach(Conversation conversation in Conversations)
            {
                if(conversation.UserOneId != CurrentUserId)
                {
                    conversation.RecipientUser = _db.applicationUser.GetFirstOfDefault(u=>u.Id == conversation.UserOneId);
                }
                else
                {
                    conversation.RecipientUser = _db.applicationUser.GetFirstOfDefault(u=>u.Id == conversation.UserTwoId);
                }
            }
            return View(Conversations);
        }
    }

}