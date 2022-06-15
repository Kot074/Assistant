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
        private readonly string _connectionString;

        public MySqlContentFrontpageStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<JosContentFrontpage> GetAll()
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosContentFrontpages.AsNoTracking().ToList();
            }
        }

        public JosContentFrontpage Get(int id)
        {
            using (var context = new VectorContext(_connectionString))
            {
                return context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == id);
            }
        }

        public JosContentFrontpage Save(JosContentFrontpage entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentContentFrontpage = context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == entity.ContentId);
                if (currentContentFrontpage is null)
                {
                    context.JosContentFrontpages.Add(entity);
                }
                else
                {
                    context.Entry(entity).State = EntityState.Modified;
                }
                context.SaveChanges();

                return context.Entry(entity).Entity;
            }
        }

        public void Remove(JosContentFrontpage entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentContentFrontpage = context.JosContentFrontpages.AsNoTracking().FirstOrDefault(s => s.ContentId == entity.ContentId);
                if (currentContentFrontpage is null)
                {
                    throw new NullReferenceException("ОШИБКА! Такой записи не существует!");
                }
                else
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}
