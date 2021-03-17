using System.Threading;

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var version = "1.0.0";

var rootDir = new DirectoryPath("..");
var srcDir = new DirectoryPath("../src");
var artifactsDir = rootDir.Combine("artifacts");

var sln = rootDir.CombineWithFilePath("GameJoltAPI.sln");
var desktopBuild = rootDir.CombineWithFilePath("build/Desktop.proj");
var apiProject = srcDir.CombineWithFilePath("GameJoltAPI/GameJoltAPI.csproj");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() => {
        EnsureDirectoryExists(artifactsDir);
        CleanDirectory(artifactsDir);
    });

Task("Compile")
    .Does(() => {
        DotNetCoreBuild(desktopBuild.FullPath, new DotNetCoreBuildSettings {
            Configuration = configuration
        });
    });

Task("Pack")
    .Does(() => {
        DotNetCorePack(apiProject.FullPath, new DotNetCorePackSettings {
            OutputDirectory = artifactsDir,
            Configuration = configuration,
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Compile");

RunTarget(target);
