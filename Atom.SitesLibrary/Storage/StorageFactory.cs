using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Models;
using System;

namespace Atom.VectorSiteLibrary.Storage
{
    public class StorageFactory
    {
        private readonly StorageTypes _storageType;
        private readonly string _connectionString;

        public StorageFactory(StorageTypes type, string connectionString)
        {
            _storageType = type;
            _connectionString = connectionString;
        }

        public IStorage<JosContent> GetContentStorage()
        {
            IStorage<JosContent> contentStorage;
            switch (_storageType)
            {
                case StorageTypes.MYSQL:
                    contentStorage = new MySqlContentStorage(_connectionString);
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
                    sectionStorage = new MySqlSectionStorage(_connectionString);
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
                    categoryStorage = new MySqlCategoriesStorage(_connectionString);
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
                    contentFrontpageStorage = new MySql.MySqlContentFrontpageStorage(_connectionString);
                    break;
                default:
                    throw new ArgumentException("ОШИБКА! Данный тип хранилища отсутствует!");
            }

            return contentFrontpageStorage;
        }
    }
}
