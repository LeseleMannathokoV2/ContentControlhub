using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApI_Project.Data;
using WebApI_Project.Data.Entities;
using WebApI_Project.Repository.Interfaces;

namespace WebApI_Project.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly DataContext _context;

        public ContentRepository(DataContext context)
        {
            _context = context;
        }

        public void DeleteContent(Content content)
        {
            _context.Contents.Remove(content);
        }

        public void Update(Content content)
        {
            _context.Entry(content).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Content>> GetContentsAsync()
        {
            return await _context.Contents.ToListAsync();
        }

        public void SaveContents(Content content)
        {
            _context.Contents.Add(content);
        }

        public async Task<Content> GetContentsById(string name)
        {
            return await _context.Contents.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
