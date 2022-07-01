using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atom.VectorSiteLibrary.Storage
{
    internal class MySqlSectionStorage : IStorage<JosSection>
    {
        private readonly VectorContext _context;

        public MySqlSectionStorage(VectorContext context)
        {
            _context = context;
        }

        public JosSection Get(int id)
        {
            return _context.JosSections.AsNoTracking().FirstOrDefault(s=>s.Id == id);
        }

        public IQueryable<JosSection> GetAll()
        {
            return _context.JosSections.AsNoTracking();
        }

        public void Remove(JosSection entity)
        {
            var currentSection = _context.JosSections.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                throw new NullReferenceException("ОШИБКА! Такого раздела не существует!");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public JosSection Save(JosSection entity)
        {
            var currentSection = _context.JosSections.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                _context.JosSections.Add(entity);
            } else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return _context.Entry(entity).Entity;
        }
    }
}
