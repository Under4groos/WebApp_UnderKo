namespace WebApp_UnderKo.Models.IO.Storage
{
    public struct StorageFile
    {
        public string Name { get; set; }
        public string Ext { get; set; }

        public string DirectoryName { get; set; }
        public StorageFile(string filename)
        {
            var v = new FileInfo(filename);
            if (v.Exists)
            {

                Name = v.Name;

                Ext = v.Extension;

                if (G_.FileExtension.TryGetContentType(filename, out string contentType))
                {
                    Ext += $" ( {contentType} ) ";

                }

                DirectoryName = v.Directory.Name;
            }
        }

    }
}
