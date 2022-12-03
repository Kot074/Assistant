using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Atom.VectorSiteLibrary.Storage.MySql
{
    public class MySqlOrderStorage : IStorage<Order>
    {
        private readonly VectorContext _context;

        public MySqlOrderStorage(VectorContext context)
        {
            _context = context;
        }
        public IQueryable<Order> GetAll()
        {
            try
            {
                return _context.Orders.AsNoTracking();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Произошла ошибка при попытке получения списка приказов из базы.");
            }
        }

        public Order Get(int id)
        {
            try
            {
                return _context.Orders.AsNoTracking().FirstOrDefault(s => s.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Произошла ошибка при попытке получения приказа {id}-ОД из базы.");
            }
        }

        public Order Save(Order entity)
        {
            var currentContent = _context.Orders.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            try
            {
                if (currentContent is null)
                {
                    _context.Orders.Add(entity);
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
                throw new Exception("Возникла ошибка при попытке сохранения приказа в базу данных.");
            }
        }

        public void Remove(Order entity)
        {
            var currentSection = _context.Orders.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
            if (currentSection is null)
            {
                throw new ArgumentException("ОШИБКА! Такого приказа не существует!");
            }
            else
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
    }
}
