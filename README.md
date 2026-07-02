# ADOFAI UMM Mod Template

A Dance of Fire and Ice (ADOFAI) UnityModManager (UMM) Mod development template.

这是一个 A Dance of Fire and Ice (ADOFAI) 的 UnityModManager (UMM) Mod 开发模板项目。

## Project Structure / 项目结构

```
Project Root / 项目根目录/
├── ADOFAIModTemplate.csproj    # Project file / 项目文件
├── src/                         # Source code / 源代码
│   ├── Main.cs                  # Main mod class / 主 Mod 类
│   ├── Settings.cs              # Mod settings class / Mod 设置类
│   ├── Patches.cs               # Harmony patches / Harmony 补丁
│   └── ResourceLoader.cs        # Resource loader / 资源加载器
├── Info.json                    # UMM mod info file / UMM Mod 信息文件
├── Properties/
    └── AssemblyInfo.cs          # Assembly info / 程序集信息

```

## Features / 功能特性

- ✅ UnityModManager integration / UnityModManager 集成
- ✅ Harmony patch support / Harmony 补丁支持
- ✅ Mod settings with GUI / 带 GUI 的 Mod 设置
- ✅ Auto-deploy to game folder / 自动部署到游戏文件夹
- ✅ Optional auto-launch game / 可选的自动启动游戏
- ✅ Bilingual comments (English/Chinese) / 双语注释（英文/中文）

## Development Environment / 开发环境

- .NET Framework 4.8.1
- Visual Studio 2019+ / JetBrains Rider
- UnityModManager 0.27.0+
- Harmony 2.3.3

## Using This Template / 使用此模板

### Install Template / 安装模板
```bash
# Install from local NuGet package
# 从本地 NuGet 包安装
dotnet new install path\to\StArray.ADOFAIModTemplate.1.0.0.nupkg

# Or install from local repository
# 或从本地存储库安装
dotnet new install path\to\ADOFAIModTemplate
```

### Create New Project / 从模板创建新项目

**Using Command Line / 使用命令行:**

```bash
# Basic usage (use --name or -n to specify project name)
# 基础用法（使用 --name 或 -n 指定项目名称）
dotnet new adofaimod --name MyModName

# With all parameters
# 完整参数
dotnet new adofaimod -n MyModName -d "My Mod Description" -a "Your Name" -v "1.0.0"

# With game path (auto-deploy and launch)
# 带游戏路径（自动部署和启动）
dotnet new adofaimod -n MyModName -g "C:\Games\ADOFAI\A Dance of Fire and Ice.exe"

# Create solution file (if needed)
# 创建解决方案文件（如果需要）
cd MyModName
dotnet new sln --name MyModName
dotnet sln add MyModName.csproj
```

**Using IDE / 使用 IDE:**

After installing the template, you can also create projects directly from your IDE:

安装模板后，也可以直接从 IDE 中创建项目：

- **Visual Studio**: Create a new project -> Search templates -> Search for "ADOFAI" or "Base ADOFAI Mod Template"
- **Visual Studio**: 创建新项目 -> 搜索模板 -> 搜索 "ADOFAI" 或 "Base ADOFAI Mod Template"

- **JetBrains Rider**: File (in editor) -> New Solution -> Custom Templates -> Base ADOFAI Mod Template
- **JetBrains Rider**: 文件（在编辑器中）-> 新建解决方案 -> 自定义模板 -> Base ADOFAI Mod Template

### Parameters / 参数说明
- `-d, --description`: Mod description / Mod 描述
- `-a, --author`: Author name / 作者名称
- `-v, --version`: Version number / 版本号
- `-g, --game-path`: Game exe path (optional, for auto-deploy and launch) / 游戏 exe 路径

### Uninstall Template / 卸载模板
```bash
dotnet new uninstall StArray.ADOFAIModTemplate
```

## Build Project / 构建项目

### Using Visual Studio or JetBrains Rider / 使用 Visual Studio 或 JetBrains Rider

1. Open the `.csproj` file or `.sln` file (if created) in Visual Studio or Rider / 在 Visual Studio 或 Rider 中打开 `.csproj` 或 `.sln` 文件（如果已创建）
2. The IDE will automatically create a solution if opening .csproj directly / 如果直接打开 .csproj，IDE 会自动创建解决方案
3. Select Debug or Release configuration / 选择 Debug 或 Release 配置
4. Press F6 (VS) or Ctrl+Shift+F9 (Rider) or click "Build" -> "Build Solution" / 按 F6 (VS) 或 Ctrl+Shift+F9 (Rider) 或点击"生成" -> "生成解决方案"
5. Files will be automatically copied to `out/` folder / 文件会自动复制到 `out/` 文件夹
6. If game path is configured, mod will be deployed and game launched (if enabled) / 如果配置了游戏路径，会自动部署 Mod 并启动游戏（如果启用）

### Using Command Line / 使用命令行
```bash
# Build with solution file / 使用解决方案文件构建
dotnet build YourModName.sln -c Release

# Or build project directly / 或直接构建项目
dotnet build YourModName.csproj -c Release
```

### Configure Game Path and Auto-Launch / 配置游戏路径和自动启动

If you didn't specify the game path when creating the project, you can manually edit the `.csproj` file:

如果创建项目时没有指定游戏路径，可以手动编辑 `.csproj` 文件：

```xml
<PropertyGroup>
  <GameExePath>C:\Games\ADOFAI\A Dance of Fire and Ice.exe</GameExePath>
  <AutoLaunchGame>true</AutoLaunchGame>
</PropertyGroup>
```

**Properties / 属性:**
- `GameExePath`: Path to game executable / 游戏可执行文件路径
- `AutoLaunchGame`: Set to `true` to auto-launch game after build, `false` to disable / 设为 `true` 构建后自动启动游戏，`false` 禁用

After configuration, each build will automatically:

配置后，每次构建都会自动：

1. Copy files to `out/` folder / 复制文件到 `out/` 文件夹
2. Deploy to game's `Mods/YourModName/` folder / 部署到游戏的 `Mods/YourModName/` 文件夹
3. Launch the game (if `AutoLaunchGame` is `true`) / 启动游戏（如果 `AutoLaunchGame` 为 `true`）

## Install Mod / 安装 Mod

After building, copy all files from the `out/` folder to the game's Mods directory:

构建完成后，将 `out/` 文件夹中的所有文件复制到游戏的 Mods 目录：

```
<Game Directory>/Mods/YourModName/
```

Or use the auto-deploy feature by configuring `GameExePath` in the `.csproj` file.

或者通过在 `.csproj` 文件中配置 `GameExePath` 使用自动部署功能。

## Development Guide / 开发指南

1. Implement your mod functionality in `Main.cs` / 在 `Main.cs` 中实现你的 Mod 功能
2. Use Harmony to create patch classes to modify game behavior / 使用 Harmony 创建补丁类来修改游戏行为
3. Update mod information in `Info.json` / 更新 `Info.json` 中的 Mod 信息
4. Add settings in `Settings.cs` / 在 `Settings.cs` 中添加设置
5. Add more class files as needed / 根据需要添加更多类文件

## License / 许可证

GPL-3.0-or-later

## Links / 链接

- Repository / 仓库: https://github.com/StArrayJaN/ADOFAIModTemplate
- ADOFAI: https://store.steampowered.com/app/977950/A_Dance_of_Fire_and_Ice/
- UnityModManager: https://www.nexusmods.com/site/mods/21
