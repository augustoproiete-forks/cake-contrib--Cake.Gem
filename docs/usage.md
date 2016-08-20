# Build Script

In order to make use of the Cake.Gem Addin, you will need to first use the `#addin` preprocessor to install Cake.Gem, but once that is done, you can directly use the available aliases.

In addition, the `gem` utility will need to be installed and available on the machine on which the script is running.  Alternatively, you can provide a `ToolPath` to where it can be located.

## GemBuild

```csharp
#addin Cake.Gem

Task("Build-Gem")
    .Does(() =>
{
    GemBuild("test.gemspec");
});
```

or, with specific settings:

```csharp
#addin Cake.Gem

Task("Build-Gem")
    .Does(() =>
{
    GemBuild("test.gemspec", new GemBuildSettings()
    {
        Force = true
    });
```

## GemPush

```csharp
#addin Cake.Gem

Task("Push-Gem")
    .Does(() =>
{
    GemPush("test.gem");
});
```

or, with specific settings:

```csharp
#addin Cake.Gem

Task("Push-Gem")
    .Does(() =>
{
    // Download the API Key into the gem credentials file.  This assumes that this file doesn't already exist
    var homeDirectory = new DirectoryPath(IsRunningOnWindows() ? EnvironmentVariable("USERPROFILE") : EnvironmentVariable("HOME"));
    DownloadFile("https://rubygems.org/api/v1/api_key.yaml", userProfile.CombineWithFilePath(".gem/credentials"), new DownloadFileSettings()
    {
        Username = "gep13",
        Password = "password"
    });

    GemPush("test.gem", new GemPushSettings()
    {
        Key = "rubygems"
    });
});
```

<div class="admonition note">
    <p class="first admonition-title">Note</p>
    <p class="last">
        Despite what you might think (I know I did to start with), the Key property is NOT referring to your actual API Key that you can get from within your profile on rubygems.org.  Instead, it is referring to the name of the API Key once it is stored within your credentials file.
    </p>
</div>

<div class="admonition attention">
    <p class="first admonition-title">Attention</p>
    <p class="last">
        The above DownloadFile example can ONLY be used on Cake Version 0.16.0 and later.
    </p>
</div>