using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace SV.WebApp.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string imgPath;
        private readonly string serverPath;
        
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            serverPath = Path.Combine(webHostEnvironment.WebRootPath);
            imgPath = Path.Combine(webHostEnvironment.WebRootPath, "img");
        }

        public string Save(IFormFile file)
        {
            try
            {
                string fileName = null;
                FileInfo fileInfo = new FileInfo(file.FileName);

                if (file != null)
                {
                    fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                    string filePath = Path.Combine(imgPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }

                return fileName;
            }
            catch (Exception)
            {
                return "not found";
            }
        }

        public bool Remove(string fileName)
        {
            try
            {
                string filePath = Path.Combine(imgPath, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Read(string fileName)
        {
            string output = "file not found";

            try
            {
                string filePath = Path.Combine(serverPath, fileName);

                if (File.Exists(filePath))
                {
                    output = File.ReadAllText(filePath);
                }

                return output;
            }
            catch (Exception)
            {
                return output;
            }
        }

        public string Update(string text)
        {
            string output = "";

            try
            {
                string filePath = Path.Combine(serverPath, "EmailTemplate.html");

                if (File.Exists(filePath))
                {
                    File.WriteAllText(filePath, text);
                }

                return output;
            }
            catch (Exception)
            {
                return output;
            }
        }

    }
}
