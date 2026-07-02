using System;
using System.IO;
using UnityEngine;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// Helper class for loading resources from the Resources folder
    /// 从 Resources 文件夹加载资源的辅助类
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// Gets the path to the mod's Resources folder
        /// 获取 Mod 的 Resources 文件夹路径
        /// </summary>
        public static string ResourcesPath
        {
            get
            {
                if (Main.Mod == null)
                    throw new InvalidOperationException("Mod is not initialized / Mod 未初始化");
                
                return Path.Combine(Main.Mod.Path, "Resources");
            }
        }

        /// <summary>
        /// Loads a text file from the Resources folder
        /// 从 Resources 文件夹加载文本文件
        /// </summary>
        /// <param name="fileName">File name relative to Resources folder / 相对于 Resources 文件夹的文件名</param>
        /// <returns>File content as string / 文件内容字符串</returns>
        public static string LoadTextFile(string fileName)
        {
            string filePath = Path.Combine(ResourcesPath, fileName);
            
            if (!File.Exists(filePath))
            {
                Main.Mod?.Logger.Error($"Text file not found / 文本文件未找到: {filePath}");
                return string.Empty;
            }

            try
            {
                string content = File.ReadAllText(filePath);
                Main.Mod?.Logger.Log($"Loaded text file / 已加载文本文件: {fileName}");
                return content;
            }
            catch (Exception ex)
            {
                Main.Mod?.Logger.Error($"Failed to load text file / 加载文本文件失败: {fileName}\n{ex}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Loads an image file as a Texture2D from the Resources folder
        /// 从 Resources 文件夹加载图像文件为 Texture2D
        /// </summary>
        /// <param name="fileName">File name relative to Resources folder / 相对于 Resources 文件夹的文件名</param>
        /// <returns>Texture2D or null if failed / Texture2D 或失败时返回 null</returns>
        public static Texture2D? LoadTexture(string fileName)
        {
            string filePath = Path.Combine(ResourcesPath, fileName);
            
            if (!File.Exists(filePath))
            {
                Main.Mod?.Logger.Error($"Image file not found / 图像文件未找到: {filePath}");
                return null;
            }

            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);
                Texture2D texture = new Texture2D(2, 2);
                
                if (texture.LoadImage(fileData))
                {
                    Main.Mod?.Logger.Log($"Loaded texture / 已加载纹理: {fileName} ({texture.width}x{texture.height})");
                    return texture;
                }
                else
                {
                    Main.Mod?.Logger.Error($"Failed to load image data / 加载图像数据失败: {fileName}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Main.Mod?.Logger.Error($"Failed to load texture / 加载纹理失败: {fileName}\n{ex}");
                return null;
            }
        }

        /// <summary>
        /// Loads binary data from a file in the Resources folder
        /// 从 Resources 文件夹加载二进制数据
        /// </summary>
        /// <param name="fileName">File name relative to Resources folder / 相对于 Resources 文件夹的文件名</param>
        /// <returns>Byte array or empty array if failed / 字节数组或失败时返回空数组</returns>
        public static byte[] LoadBinaryFile(string fileName)
        {
            string filePath = Path.Combine(ResourcesPath, fileName);
            
            if (!File.Exists(filePath))
            {
                Main.Mod?.Logger.Error($"Binary file not found / 二进制文件未找到: {filePath}");
                return Array.Empty<byte>();
            }

            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                Main.Mod?.Logger.Log($"Loaded binary file / 已加载二进制文件: {fileName} ({data.Length} bytes)");
                return data;
            }
            catch (Exception ex)
            {
                Main.Mod?.Logger.Error($"Failed to load binary file / 加载二进制文件失败: {fileName}\n{ex}");
                return Array.Empty<byte>();
            }
        }

        /// <summary>
        /// Checks if a file exists in the Resources folder
        /// 检查文件是否存在于 Resources 文件夹中
        /// </summary>
        /// <param name="fileName">File name relative to Resources folder / 相对于 Resources 文件夹的文件名</param>
        /// <returns>True if file exists / 文件存在返回 true</returns>
        public static bool FileExists(string fileName)
        {
            string filePath = Path.Combine(ResourcesPath, fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// Gets all files in the Resources folder
        /// 获取 Resources 文件夹中的所有文件
        /// </summary>
        /// <param name="searchPattern">Search pattern (e.g., "*.txt") / 搜索模式（例如 "*.txt"）</param>
        /// <param name="searchOption">Search option / 搜索选项</param>
        /// <returns>Array of file paths / 文件路径数组</returns>
        public static string[] GetFiles(string searchPattern = "*.*", SearchOption searchOption = SearchOption.AllDirectories)
        {
            try
            {
                if (!Directory.Exists(ResourcesPath))
                {
                    Main.Mod?.Logger.Warning($"Resources folder not found / Resources 文件夹未找到: {ResourcesPath}");
                    return Array.Empty<string>();
                }

                return Directory.GetFiles(ResourcesPath, searchPattern, searchOption);
            }
            catch (Exception ex)
            {
                Main.Mod?.Logger.Error($"Failed to get files / 获取文件失败: {ex}");
                return Array.Empty<string>();
            }
        }
    }
}
