using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace FlightDocsSystem.Service
{
    public interface IDocumentList
    {
        public Task<List<DocumentList>> GetDocumentListAllAsync();
        public Task<bool> EditDocumentListAsync(int id, DocumentList DocumentLists);
        public Task<bool> AddDocumentListAsync(DocumentList DocumentLists);
        public Task<DocumentList> GetDocumentListAsync(int? id);
       
    }
    public class DocumentListSvc : IDocumentList
    {
        protected DataContext _context;
        public DocumentListSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddDocumentListAsync(DocumentList DocumentLists)
        {
            _context.Add(DocumentLists);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditDocumentListAsync(int id, DocumentList DocumentLists)
        {
            _context.documentLists.Update(DocumentLists);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DocumentList>> GetDocumentListAllAsync()
        {
            var dataContext = _context.documentLists;
            return await dataContext.ToListAsync();
        }

        public async Task<DocumentList> GetDocumentListAsync(int? id)
        {
            var DocumentLists = await _context.documentLists
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (DocumentLists == null)
            {
                return null;
            }

            return DocumentLists;
        }
        
    }
}
