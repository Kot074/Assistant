using NewsEditorCore.Types;

namespace NewsEditorCore
{
    interface IWarehouse
    {
        DirectoryItem[] GetList(string path);
        DirectoryItem CreateDirectory(string path);
        void Remove(DirectoryItem node);
        DirectoryItem UploadFile(string sourcePath, string targetPath);
        string GetUrl(string path);
    }
}
