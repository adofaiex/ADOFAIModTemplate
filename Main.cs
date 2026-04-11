using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// Main entry point for the ADOFAI UMM Mod
    /// ADOFAI UMM Mod 主类
    /// </summary>
    public static class Main
    {
        /// <summary>
        /// Reference to the mod entry / Mod 入口引用
        /// </summary>
        public static UnityModManager.ModEntry? Mod { get; private set; }
        
        /// <summary>
        /// Harmony instance for patching / Harmony 补丁实例
        /// </summary>
        public static Harmony? Harmony { get; private set; }
        
        /// <summary>
        /// Mod settings / Mod 设置
        /// </summary>
        public static Settings Settings { get; private set; } = null!;

        /// <summary>
        /// Mod entry point called by UnityModManager
        /// UnityModManager 调用的 Mod 入口点
        /// </summary>
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Mod = modEntry;
            
            // Load settings / 加载设置
            Settings = Settings.Load(modEntry);
            
            // Setup callbacks / 设置回调
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = Settings.OnGUI;
            modEntry.OnSaveGUI = Settings.OnSaveGUI;
            
            // Create Harmony instance / 创建 Harmony 实例
            Harmony = new Harmony(modEntry.Info.Id);
            
            modEntry.Logger.Log("Mod loaded / Mod 已加载");
            return true;
        }

        /// <summary>
        /// Called when mod is toggled on/off
        /// Mod 启用/禁用切换时调用
        /// </summary>
        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                modEntry.Logger.Log("Mod enabled / Mod 已启用");
                Harmony?.PatchAll(Assembly.GetExecutingAssembly());
                
                // Test resource loading / 测试资源加载
                TestResourceLoading();
            }
            else
            {
                modEntry.Logger.Log("Mod disabled / Mod 已禁用");
                Harmony?.UnpatchAll(modEntry.Info.Id);
            }
            return true;
        }

        /// <summary>
        /// Test resource loading functionality
        /// 测试资源加载功能
        /// </summary>
        private static void TestResourceLoading()
        {
            Mod?.Logger.Log("=== Testing Resource Loading / 测试资源加载 ===");
            
            // Test loading text file / 测试加载文本文件
            string testText = ResourceLoader.LoadTextFile("test.txt");
            if (!string.IsNullOrEmpty(testText))
            {
                Mod?.Logger.Log($"Test text content / 测试文本内容:\n{testText}");
            }
            
            // List all files in Resources folder / 列出 Resources 文件夹中的所有文件
            string[] files = ResourceLoader.GetFiles();
            Mod?.Logger.Log($"Found {files.Length} file(s) in Resources folder / 在 Resources 文件夹中找到 {files.Length} 个文件:");
            foreach (string file in files)
            {
                Mod?.Logger.Log($"  - {file}");
            }
            
            Mod?.Logger.Log("=== Resource Loading Test Complete / 资源加载测试完成 ===");
        }
    }
}
