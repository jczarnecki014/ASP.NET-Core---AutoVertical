﻿using AutoVertical_Utility.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Utility.FileAcces
{
    public interface IFileAcces
    {
        public Validate FileState{ get; }
        public string Create();
        public static string Delete(string imgSrc)
        {
            FileInfo fileInfo= new FileInfo(imgSrc);
            if(fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            return fileInfo.DirectoryName;
        }
    }
}
