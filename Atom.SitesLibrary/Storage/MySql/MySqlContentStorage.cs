using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atom.VectorSiteLibrary.Storage
{
    internal class MySqlContentStorage : IStorage<JosContent>
    {
        private readonly VectorContext _context;

        public MySqlContentStorage(VectorContext context)
        {
            _context = context;
        }
        public JosContent Get(int id)
        {
            try
            {
                return _context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Произошла ошибка при попытке получения данных из базы.");
            }
        }

        public IQueryable<JosContent> GetAll()
        {
            try
            {
                return _context.JosContents.AsNoTracking();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Произошла ошибка при попытке получения данных из базы.");
            }
        }

        public void Remove(JosContent entity)
        {
            var currentSection = _context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                throw new ArgumentException("ОШИБКА! Такого контента не существует!");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public JosContent Save(JosContent entity)
        {
            var currentContent = _context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            try
            {
                if (currentContent is null)
                {
                    _context.JosContents.Add(entity);
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;
                return _context.Entry(entity).Entity;
            }
            catch (Exception)
            {
                throw new Exception("Возникла ошибка при попытке сохранения в базу данных.");
            }
        }
    }
}
