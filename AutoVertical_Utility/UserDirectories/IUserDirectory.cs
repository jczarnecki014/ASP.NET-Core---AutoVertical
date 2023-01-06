using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Utility.UserDirectories
{
    public interface IUserDirectory
    {
        public void CreateUserDirectory();
        public string CreateAdvertDirectory();
        public static void DeleteDirectory(string? Path)
        {
            if(Path != null) 
            {
                Directory.Delete(Path, true);
            }
        }
    }
}
