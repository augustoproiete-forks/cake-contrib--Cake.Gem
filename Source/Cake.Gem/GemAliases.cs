using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Gem.Build;
using Cake.Gem.Push;

namespace Cake.Gem
{
    /// <summary>
    /// Contains aliases related to Gem CLI
    /// </summary>
    /// <summary>
    /// <para>Contains functionality related to the<see href="https://rubygems.org/pages/download">RubyGems Package Manager</see>.</para>
    /// <para>
    /// In order to use the commands for this addin, the gem utility will need to be installed and available, or you will need to provide a ToolPath to where it can be located, and also you will need to include the following in your build.cake file to download and
    /// reference the addin from NuGet.org:
    /// <code>
    /// #addin Cake.Gem
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("Gem")]
    public static class GemAliases
    {
        /// <summary>
        /// Builds the gem using the path to the gemspec file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gemSpecFilePath">The path to the gemspec file.</param>
        /// <example>
        /// <code>
        /// GemBuild("test.gemspec");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void GemBuild(this ICakeContext context, FilePath gemSpecFilePath)
        {
            GemBuild(context, gemSpecFilePath, new GemBuildSettings());
        }

        /// <summary>
        /// Builds the gem using the path to the gemspec file and any additional settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gemSpecFilePath">The path to the gemspec file.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// GemBuild("test.gemspec", new GemBuildSettings()
        /// {
        ///     Force = true
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void GemBuild(this ICakeContext context, FilePath gemSpecFilePath, GemBuildSettings settings)
        {
            var runner = new GemBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Build(gemSpecFilePath, settings);
        }

        /// <summary>
        /// Pushes the gem using the path to the gem file.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gemFilePath">The path to the gem file.</param>
        /// <example>
        /// <code>
        /// GemBuild("test.gemspec");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void GemPush(this ICakeContext context, FilePath gemFilePath)
        {
            GemPush(context, gemFilePath, new GemPushSettings());
        }

        /// <summary>
        /// Pushes the gem using the path to the gem file and any additional settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="gemFilePath">The path to the gem file.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// GemBuild("test.gem", new GemPushSettings()
        /// {
        ///     Key = "rubygems" }
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void GemPush(this ICakeContext context, FilePath gemFilePath, GemPushSettings settings)
        {
            var runner = new GemPushRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Push(gemFilePath, settings);
        }
    }
}