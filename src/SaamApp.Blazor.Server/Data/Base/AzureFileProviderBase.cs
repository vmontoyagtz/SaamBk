using Syncfusion.EJ2.FileManager.Base;

namespace SfFileService.FileManager.Base
{
    public interface AzureFileProviderBase : FileProviderBase
    {
        void RegisterAzure(string accountName, string accountKey, string blobName);
    }
}