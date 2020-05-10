using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(GameplaySettings.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(GameplaySettings.BuildInfo.Company)]
[assembly: AssemblyProduct(GameplaySettings.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + GameplaySettings.BuildInfo.Author)]
[assembly: AssemblyTrademark(GameplaySettings.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(GameplaySettings.BuildInfo.Version)]
[assembly: AssemblyFileVersion(GameplaySettings.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(GameplaySettings.GameplaySettings), GameplaySettings.BuildInfo.Name, GameplaySettings.BuildInfo.Version, GameplaySettings.BuildInfo.Author, GameplaySettings.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame(null, null)]