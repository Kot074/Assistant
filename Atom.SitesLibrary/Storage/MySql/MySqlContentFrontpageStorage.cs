using System;
using System.Collections.Generic;
using System.Linq;
using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Atom.VectorSiteLibrary.Storage.MySql
{
    public class MySqlContentFrontpageStorage : IStorage<JosContentFrontpage>
    {
        private readonly VectorContext _context;

        public MySqlContentFrontpageStorage(VectorContext context)
        {
            _context = context;
        }

        public IQueryable<JosContentFrontpage> GetAll()
        {
            return _context.JosContentFrontpages.AsNoTracking();
        }

        public JosContentFrontpage Get(int id)
        {
            return _context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == id);
        }

        public JosContentFrontpage Save(JosContentFrontpage entity)
        {
            var currentContentFrontpage = _context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == entity.ContentId);
            if (currentContentFrontpage is null)
            {
                _context.JosContentFrontpages.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return _context.Entry(entity).Entity;
        }

        public void Remove(JosContentFrontpage entity)
        {
            var currentContentFrontpage = _context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == entity.ContentId);
            if (currentContentFrontpage is null)
            {
                throw new NullReferenceException("ОШИБКА! Такой записи не существует!");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
    }
}
