namespace WebApp_UnderKo.Models.IO
{
    public static class InputOutput
    {

        private static Dictionary<string, string> _cache_file = new Dictionary<string, string>();

        public static bool CreateFolders(string base_path, string[] names)
        {

            if (Directory.Exists(base_path))
            {
                foreach (string name in names)
                {
                    string full_ = Path.Combine(base_path, name);
                    if (Directory.Exists(full_))
                    {
                        G_.logger.NewLine($"Directory Exists: {full_}");
                        continue;
                    }

                    Directory.CreateDirectory(full_);
                    G_.logger.NewLine($"Directory create: {full_}");
                }
                return true;
            }
            else
            {
                G_.logger.NewLine($"Directory not found: {base_path}");
            }
            return false;
        }

        public static async Task<bool> PATH_BASE_LocalWriteAsync(string path, string data)
        {

            return await WriteAsync(path, data);
        }

        public static async Task<bool> WriteAsync(string path, string data)
        {
            try
            {
                await File.WriteAllTextAsync(path, data);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public static async Task<bool> PATH_BASE_LocalRead(string path, Action<string> result, bool iscache = false)
        {

            return await ReadAsync(path, result, iscache);
        }

        public static async Task<bool> ReadAsync(string path, Action<string> result, bool iscache = false)
        {

            if (File.Exists(path))
            {
                if (_cache_file.ContainsKey(path) && iscache == true)
                {
                    result?.Invoke(_cache_file[path]);
                    return true;
                }




                var fileText = await File.ReadAllTextAsync(path);
                G_.logger.NewLine($"File read: {path}");

                if (!_cache_file.ContainsKey(path) && iscache == true)
                    _cache_file.Add(path, fileText);

                result?.Invoke(fileText);

                return true;

            }
            else
            {
                G_.logger.NewLine(path);
            }

            return false;
        }
    }
}
