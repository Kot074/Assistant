using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atom.VectorSiteLibrary.Storage
{
    internal class MySqlCategoriesStorage : IStorage<JosCategory>
    {
        private readonly VectorContext _context;

        public MySqlCategoriesStorage(VectorContext context)
        {
            _context = context;
        }

        public JosCategory Get(int id)
        {
            return _context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == id);
        }

        public IQueryable<JosCategory> GetAll()
        {
            return _context.JosCategories.AsNoTracking();
        }

        public void Remove(JosCategory entity)
        {
            var currentSection = _context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                throw new NullReferenceException("ОШИБКА! Такой категории не существует!");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public JosCategory Save(JosCategory entity)
        {
            var currentSection = _context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                _context.JosCategories.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return _context.Entry(entity).Entity;
        }
    }
}
