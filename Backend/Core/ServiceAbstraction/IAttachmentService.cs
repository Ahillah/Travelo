
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IAttachmentService
    {
        public string Upload(IFormFile file, string FolderName);
        public bool Delete(string FilePath);
    }
}
