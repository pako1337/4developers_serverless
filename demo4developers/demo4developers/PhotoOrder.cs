using Microsoft.WindowsAzure.Storage.Table;

namespace demo4developers
{
    public class PhotoOrder : TableEntity
    {
        public string Email { get; set; }
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
