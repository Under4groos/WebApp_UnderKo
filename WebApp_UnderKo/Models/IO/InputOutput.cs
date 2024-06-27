﻿using System.Text;

namespace WebApp_UnderKo.Models.IO
{
    public static class InputOutput
    {


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

        public static async Task<bool> WWWROOT_LocalWriteAsync(string path, string data)
        {
            string path_file = Path.Combine(G_.CacheData.PATH_WWWROOT, path);
            return await WriteAsync(path_file, data);
        }

        public static async Task<bool> WriteAsync(string path, string data)
        {
            try
            {
                using (FileStream writeter = File.OpenWrite(path))
                {
                    byte[] encodedText = Encoding.UTF8.GetBytes(data);
                    await writeter.WriteAsync(encodedText, 0, encodedText.Length);
                    G_.logger.NewLine($"File write: {path}");
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }


        }

        public static async Task<bool> WWWROOT_LocalRead(string path, Action<string> result)
        {
            string path_file = Path.Combine(G_.CacheData.PATH_WWWROOT, path);
            return await ReadAsync(path_file, result);
        }

        public static async Task<bool> ReadAsync(string path, Action<string> result)
        {

            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    var fileText = await reader.ReadToEndAsync();
                    result?.Invoke(fileText);
                    G_.logger.NewLine($"File read: {path}");
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
