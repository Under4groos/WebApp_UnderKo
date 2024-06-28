using System.Text;

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
            string path_file = Path.Combine(G_.CacheData.PATH_BASE, path);
            return await WriteAsync(path_file, data);
        }

        public static async Task<bool> WriteAsync(string path, string data)
        {
            try
            {
                using (FileStream writeter = File.OpenWrite(path))
                {
                    byte[] encodedText = Encoding.UTF8.GetBytes(data);
                    G_.logger.NewLine($"File write: {path}");
                    await writeter.WriteAsync(encodedText, 0, encodedText.Length);

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }

        public static async Task<bool> PATH_BASE_LocalRead(string path, Action<string> result, bool iscache = false)
        {
            string path_file = Path.Combine(G_.CacheData.PATH_BASE, path);
            return await ReadAsync(path_file, result, iscache);
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


                using (StreamReader reader = File.OpenText(path))
                {

                    var fileText = await reader.ReadToEndAsync();
                    G_.logger.NewLine($"File read: {path}");

                    if (!_cache_file.ContainsKey(path) && iscache == true)
                        _cache_file.Add(path, fileText);

                    result?.Invoke(fileText);

                    return true;
                }
            }
            else
            {
                G_.logger.NewLine(path);
            }

            return false;
        }
    }
}
