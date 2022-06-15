using Atom.VectorSiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atom.VectorSiteLibrary.Storage
{
    public interface IStorage<T>
    {
        public List<T> GetAll();
        public T Get(int id);
        public void Save(T entity);
        public void Remove(T entity);
    }
}
