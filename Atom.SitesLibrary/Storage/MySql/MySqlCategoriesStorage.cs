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
        private readonly string _connectionString;

        public MySqlCategoriesStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public JosCategory Get(int id)
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == id);
            }
        }

        public List<JosCategory> GetAll()
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosCategories.AsNoTracking().ToList();
            }
        }

        public void Remove(JosCategory entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentSection = context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                if (currentSection is null)
                {
                    throw new NullReferenceException("ОШИБКА! Такой категории не существует!");
                }
                else
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public void Save(JosCategory entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentSection = context.JosCategories.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                if (currentSection is null)
                {
                    context.JosCategories.Add(entity);
                }
                else
                {
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
    }
}
