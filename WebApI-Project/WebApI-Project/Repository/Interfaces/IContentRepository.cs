using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApI_Project.Data.Entities;

namespace WebApI_Project.Repository.Interfaces
{
    public interface IContentRepository
    {
        void SaveContents(Content content);
        Task<IEnumerable<Content>> GetContentsAsync();

        Task<Content> GetContentsById(string name);

        Task<bool> SaveAllAsync();

        void DeleteContent(Content content);

        void Update(Content content);
    }
}
