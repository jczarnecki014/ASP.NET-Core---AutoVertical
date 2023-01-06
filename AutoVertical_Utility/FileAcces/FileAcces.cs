using AutoVertical_Utility.Validation;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace AutoVertical_Utility.FileAcces
{
        /// <summary>
        /// It provides handling tools for files uploaded by user in form
        /// </summary>
        public class FileAcces : IFileAcces
        {
            private IFormFile File { get; set; }
            private string DirectoryPath{ get;set;}
            public Validate FileState { get;set; }
            private string WWWRootPath{ get;set; }
            private string? DefaultName{ get;set; }
            public FileAcces(IFormFile File,string wwwRootPath,string DirectoryPath,string? DefaultName = null)
            {
                this.File = File;
                this.DirectoryPath= DirectoryPath;
                this.WWWRootPath= wwwRootPath;
                this.DefaultName= DefaultName;

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
            public FileAcces(IFormFile File)
            {
                this.File = File;

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
                string fileName;
                if(DefaultName != null)
                {
                    fileName = this.DefaultName;
                }
                else
                {
                    fileName = this.GetGuidName();
                }
                /*string directoryPath = CreateDirectory();*/
                string fileExtension = Path.GetExtension(this.File.FileName);
                string filePath = this.DirectoryPath+fileName+fileExtension;
                string fullPath = this.WWWRootPath+filePath;
                if(File != null) 
                {
                   using(FileStream newFile = new FileStream(fullPath,FileMode.Create))
                   {
                        File.CopyTo(newFile);
                   }
                   return filePath;
                }
                else
                {
                    throw new Exception("File coudn't be null");
                }
                
            }

            private string GetGuidName()
            {
                return Guid.NewGuid().ToString();
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

                if(File.Length>Options.File_Maximum_Weight)
                {
                    FileState.errorCount++;
                    FileState.isValid = false;
                    FileState.values["FileSizeIsValid"] = false;
                }
               
            }
        }
}
