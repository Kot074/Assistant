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
        private readonly string _connectionString;

        public MySqlSectionStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public JosSection Get(int id)
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosSections.AsNoTracking().FirstOrDefault(s=>s.Id == id);
            }
        }

        public List<JosSection> GetAll()
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosSections.AsNoTracking().ToList();
            }
        }

        public void Remove(JosSection entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentSection = context.JosSections.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                if (currentSection is null)
                {
                    throw new NullReferenceException("ОШИБКА! Такого раздела не существует!");
                }
                else
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public JosSection Save(JosSection entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentSection = context.JosSections.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                if (currentSection is null)
                {
                    context.JosSections.Add(entity);
                } else
                {
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();
                return context.Entry(entity).Entity;
            }
        }
    }
}
