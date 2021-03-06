﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CustomPrototypes.NetStandard.Common
{
    public static class FileExtensions
    {
        private static readonly string LocalFolder;

        static FileExtensions()
        {
            // Gets the target platform's valid save location
            LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }
        
        // Stream options

        public static async Task<string> SaveToLocalFolderAsync(this Stream dataStream, string fileName)
        {
            // Use Combine so that the correct file path slashes are used
            var filePath = Path.Combine(LocalFolder, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var fileStream = File.OpenWrite(filePath))
            {
                if (dataStream.CanSeek)
                    dataStream.Position = 0;

                await dataStream.CopyToAsync(fileStream);

                return filePath;
            }
        }

        public static async Task<Stream> LoadFileStreamAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    return fileStream;
                }
            });
        }

        // Byte[] options

        public static async Task<string> SaveToLocalFolderAsync(this byte[] dataBytes, string fileName)
        {
            return await Task.Run(() =>
            {
                // Use Combine so that the correct file path slashes are used
                var filePath = Path.Combine(LocalFolder, fileName);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                File.WriteAllBytes(filePath, dataBytes);

                return filePath;
            });
        }

        public static async Task<byte[]> LoadFileBytesAsync(string filePath)
        {
            return await Task.Run(() => File.ReadAllBytes(filePath));
        }
        
        // Delete Options

        public static async Task<bool> DeleteFileAtPathAsync(this string filePath)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });
        }
    }
}
