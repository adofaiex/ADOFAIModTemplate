using HarmonyLib;

namespace ADOFAIModTemplate
{
    /// <summary>
    /// Harmony patches for the mod
    /// Mod 的 Harmony 补丁
    /// </summary>
    public static class Patches
    {
        /// <summary>
        /// Patch for scrController.Start method
        /// scrController.Start 方法的补丁
        /// </summary>
        [HarmonyPatch(typeof(scrController), "Start")]
        public static class ControllerStartPatch
        {
            /// <summary>
            /// Prefix patch - runs before the original method
            /// 前置补丁 - 在原方法之前运行
            /// </summary>
            /// <param name="__instance">scrController instance / scrController 实例</param>
            public static void Prefix(scrController __instance)
            {
                Main.Mod?.Logger.Log("Controller start");
            }

            /// <summary>
            /// Postfix patch - runs after the original method
            /// 后置补丁 - 在原方法之后运行
            /// </summary>
            /// <param name="__instance">scrController instance / scrController 实例</param> 
            public static void Postfix(scrController __instance)
            {
                Main.Mod?.Logger.Log("Controller started");

                // Example: Use settings / 示例：使用设置
                if (Main.Settings.EnableFeature)
                {
                    Main.Mod?.Logger.Log($"Feature enabled, example value: {Main.Settings.ExampleValue}");
                }
            }
        }
    }
}
