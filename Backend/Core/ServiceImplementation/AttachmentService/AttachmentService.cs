using Microsoft.AspNetCore.Http;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        private readonly List<string> allowedExtentions = new List<string>() { ".jpg", ".png", ".jpeg" };
        private const int fileMaxSize = 2097152;


        public string Upload(IFormFile file, string FolderName)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            if (!allowedExtentions.Contains(fileExtension))
                throw new Exception("Invalid File Extension");
            if (file.Length > fileMaxSize)
                throw new Exception("Invalid file size,over our range");
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", FolderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var FileName = $"{Guid.NewGuid()}_{file.FileName}";
            var FilePath = Path.Combine(folderPath, FileName);
            using var fs = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(fs);
            fs.Close();
            return FileName;
        }
        public bool Delete(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                return true;
            }
            return false;
        }
    }
}
