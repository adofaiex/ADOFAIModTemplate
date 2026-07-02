using UnityModManagerNet;
using UnityEngine;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// Mod settings class
    /// Mod 设置类
    /// </summary>
    public class Settings : UnityModManager.ModSettings
    {
        /// <summary>
        /// Example boolean setting / 示例布尔设置
        /// </summary>
        public bool EnableFeature = true;

        /// <summary>
        /// Example integer setting / 示例整数设置
        /// </summary>
        public int ExampleValue = 100;

        /// <summary>
        /// Example string setting / 示例字符串设置
        /// </summary>
        public string ExampleText = "Hello World";

        /// <summary>
        /// Draw mod GUI / 绘制 Mod GUI
        /// </summary>
        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            // Example: Draw settings UI / 示例：绘制设置界面
            GUILayout.Label("=== Mod Settings / Mod 设置 ===");
            
            EnableFeature = GUILayout.Toggle(
                EnableFeature, 
                "Enable Feature / 启用功能"
            );
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Example Value / 示例数值: ", GUILayout.Width(150));
            if (int.TryParse(
                GUILayout.TextField(ExampleValue.ToString(), GUILayout.Width(100)),
                out int newValue))
            {
                ExampleValue = newValue;
            }
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Example Text / 示例文本: ", GUILayout.Width(150));
            ExampleText = GUILayout.TextField(
                ExampleText, 
                GUILayout.Width(200)
            );
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Called when saving GUI / 保存设置时调用
        /// </summary>
        public void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Save(modEntry);
        }

        /// <summary>
        /// Save settings / 保存设置
        /// </summary>
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        /// <summary>
        /// Load settings / 加载设置
        /// </summary>
        public static Settings Load(UnityModManager.ModEntry modEntry)
        {
            return Load<Settings>(modEntry);
        }
    }
}
