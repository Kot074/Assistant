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
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Произошла ошибка при попытке получения списка приказов из базы.", ex);
            }
        }

        public Order Get(int id)
        {
            throw new InvalidOperationException($"В реестре приказов нельзя извлечь одну запись.");
        }

        public Order Save(Order entity)
        {
            var currentContent = _context.Orders.AsNoTracking().SingleOrDefault(s => s.Id == entity.Id && s.Date.Year == entity.Date.Year);
            try
            {
                if (string.IsNullOrEmpty(entity.Label.Trim()))
                {
                    throw new Exception("Заголовок приказа не может быть пустым.");
                }

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
            catch (Exception ex)
            {
                throw new Exception($"Возникла ошибка при попытке сохранения приказа в базу данных: {ex.InnerException?.Message ?? ex.Message}", ex);
            }
        }

        public void Remove(Order entity)
        {
            var currentOrderRecord = _context.Orders.AsNoTracking().SingleOrDefault(s => s.Id == entity.Id && s.Date.Year == entity.Date.Year);
            if (currentOrderRecord is null)
            {
                throw new ArgumentException("ОШИБКА! Такого приказа не существует!");
            }
            else
            {
                var dbEntity = _context.Entry<Order>(entity);
                dbEntity.State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
    }
}
