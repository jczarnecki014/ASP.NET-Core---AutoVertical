using AutoVertical_Utility.Validation;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Net.Http.Headers;

namespace AutoVertical_Utility.FileAcces
{
        /// <summary>
        /// It provides handling tools for files uploaded by user in form
        /// </summary>
        public class FileAcces : IFileAcces
        {
            private IFormFile File { get; set; }
            private string WWWRootTree{ get;set;}
            private string SpecificFileDirectory{ get;set; }
            private readonly string MainAnnouncementImgDirectory = """image\tempAnnouncement\""";
            public Validate FileState { get;set; }
            public FileAcces(IFormFile File,string WWWRootPath, string? SpecificFileDirectory = null)
            {
                this.File = File;
                this.WWWRootTree= WWWRootPath;
                this.SpecificFileDirectory = SpecificFileDirectory;

                /*
                 * Create validation object to store information about file validation state
                 * Dictionary provides possible checkpoints with should be validate
                */

                this.FileState = new Validate
                (
                    values: new Dictionary<string, bool>()
                    {
                        {"FileExtensionIsValid",true},
                        {"FileSizeIsValid",true}
                    }
                );
                this.FileValidation();
            }
            public string Create()
            {
                string fileName = this.GetGuidName();
                string directoryPath = CreateDirectory();
                string fileExtension = Path.GetExtension(this.File.FileName);
                string fullPath = Path.Combine(directoryPath,fileName+fileExtension);
                if(File != null) 
                {
                   using(FileStream newFile = new FileStream(fullPath,FileMode.Create))
                   {
                        File.CopyTo(newFile);
                   }
                   return fileName+fileExtension;
                }
                else
                {
                    throw new Exception("File coudn't be null");
                }
                
            }

            public void Delete()
            {
            throw new NotImplementedException();
            }


            private string GetGuidName()
            {
                return Guid.NewGuid().ToString();
            }


            private string CreateDirectory()
            {
                string path;
                if(this.SpecificFileDirectory!= null){
                    path = Path.Combine(this.WWWRootTree,MainAnnouncementImgDirectory,this.SpecificFileDirectory);
                }
                else{
                    path =  Path.Combine(this.WWWRootTree,MainAnnouncementImgDirectory);
                }

                DirectoryInfo directory = new DirectoryInfo(path);
                if(!directory.Exists) 
                {
                    directory.Create();
                }
                return path;
            }

            public void FileValidation()
            {
                /*
                 * Checking if file is a picture
                 * .jpg .png .jpeg
                */
                if(Path.GetExtension(File.FileName) != ".png" && Path.GetExtension(File.FileName) != ".jpg" && Path.GetExtension(File.FileName) != ".jpeg")
                {
                    FileState.errorCount++;
                    FileState.isValid = false;
                    FileState.values["FileExtensionIsValid"] = false;
                }

                /*
                 * Checking if file is not grater than 1.5MB
                 * 1.5MB == 1 572 864 bytes
                */

                if(File.Length>1572864)
                {
                    FileState.errorCount++;
                    FileState.isValid = false;
                    FileState.values["FileSizeIsValid"] = false;
                }
               
            }
        }
}
