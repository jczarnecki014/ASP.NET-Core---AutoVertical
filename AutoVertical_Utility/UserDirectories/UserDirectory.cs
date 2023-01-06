using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Utility.UserDirectories
{
    public class UserDirectory:IUserDirectory
    {
        private readonly string[] BasicDirectiories = {"Adverts","Avatar","Advertisement"};
        private readonly string wwwRoot;
        private readonly string UserDirectoryPath;
        private readonly string UserId;
        public UserDirectory(string userId,string wwwRoot)
        {
            this.UserId = userId;
            this.wwwRoot = wwwRoot; 
            this.UserDirectoryPath = """/Users/""" + UserId;
        }


        public string CreateAdvertDirectory()
        {
            string DirectoryName = Guid.NewGuid().ToString();
            string AdvertDirectoryPath = this.UserDirectoryPath + """/Adverts/""" + DirectoryName + """/""";
            DirectoryInfo directory = new DirectoryInfo(this.wwwRoot+AdvertDirectoryPath);
            if(!directory.Exists )
            { 
                directory.Create();
            }
            return AdvertDirectoryPath;
        }



        public void CreateUserDirectory()
        {
            string userDirectoryPath = this.wwwRoot+this.UserDirectoryPath;
            DirectoryInfo directoryInfo= new DirectoryInfo(userDirectoryPath);
            if(!directoryInfo.Exists)
            {
                directoryInfo.Create();
                foreach(string Directory in BasicDirectiories) 
                {
                    directoryInfo= new DirectoryInfo(userDirectoryPath + $"""\{Directory}""");
                    directoryInfo.Create();
                }
            }
        }
    }
}
