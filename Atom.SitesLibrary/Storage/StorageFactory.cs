using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Models;
using System;

namespace Atom.VectorSiteLibrary.Storage
{
    public class StorageFactory
    {
        private readonly StorageTypes _storageType;
        private readonly VectorContext _context;

        public StorageFactory(StorageTypes type, VectorContext context)
        {
            _storageType = type;
            _context = context;
        }

        public IStorage<JosContent> GetContentStorage()
        {
            IStorage<JosContent> contentStorage;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    contentStorage = new MySqlContentStorage(_context);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный тип хранилища отсутствует!");
            }

            return contentStorage;
        }

        public IStorage<JosSection> GetSectionStorage()
        {
            IStorage<JosSection> sectionStorage;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    sectionStorage = new MySqlSectionStorage(_context);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный тип хранилища отсутствует!");
            }

            return sectionStorage;
        }

        public IStorage<JosCategory> GetCategoryStorage()
        {
            IStorage<JosCategory> categoryStorage;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    categoryStorage = new MySqlCategoriesStorage(_context);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный тип хранилища отсутствует!");
            }

            return categoryStorage;
        }

        public IStorage<JosContentFrontpage> GetContentFrontpageStorage()
        {
            IStorage<JosContentFrontpage> contentFrontpageStorage = null;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    contentFrontpageStorage = new MySql.MySqlContentFrontpageStorage(_context);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный тип хранилища отсутствует!");
            }

            return contentFrontpageStorage;
        }

        public IStorage<Order> GetOrderStorage()
        {
            IStorage<Order> orderStorage = null;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    orderStorage = new MySql.MySqlOrderStorage(_context);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный хранилище для приказов отсутствует!");
            }

            return orderStorage;
        }
    }
}
