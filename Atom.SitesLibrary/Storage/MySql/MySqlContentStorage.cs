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
        private readonly string _connectionString;

        public MySqlContentStorage(string connectionString)
        {
            _connectionString = connectionString;
        }
        public JosContent Get(int id)
        {
            using (var context = new VectorContext(_connectionString))
            {
                try
                {
                    return context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == id);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Произошла ошибка при попытке получения данных из базы.");
                }
            }
        }

        public List<JosContent> GetAll()
        {
            using (var context = new VectorContext(_connectionString))
            {
                try
                {
                    return context.JosContents.AsNoTracking().ToList();
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("Произошла ошибка при попытке получения данных из базы.");
                }
            }
        }

        public void Remove(JosContent entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentSection = context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                if (currentSection is null)
                {
                    throw new ArgumentException("ОШИБКА! Такого контента не существует!");
                }
                else
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public JosContent Save(JosContent entity)
        {
            using (var context = new VectorContext(_connectionString))
            {
                var currentContent = context.JosContents.AsNoTracking().FirstOrDefault(s => s.Id == entity.Id);
                try
                {
                    if (currentContent is null)
                    {
                        context.JosContents.Add(entity);
                    }
                    else
                    {
                        context.Entry(entity).State = EntityState.Modified;
                    }

                    context.SaveChanges();
                    return context.Entry(entity).Entity;
                }
                catch (Exception ex)
                {
                    throw new Exception("Возникла ошибка при попытке сохранения в базу данных.");
                }
            }
        }
    }
}
