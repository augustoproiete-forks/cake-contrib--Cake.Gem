using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using Cake.Gem.Build;

namespace Cake.Gem
{
    /// <summary>
    /// Contains aliases related to Gem CLI
    /// </summary>
    [CakeAliasCategory("Gem")]
    public static class GemAliases
    {
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
        ///     Force = true }
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void GemBuild(this ICakeContext context, FilePath gemSpecFilePath, GemBuildSettings settings)
        {
            var runner = new GemBuildRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Build(gemSpecFilePath, settings);
        }
    }
}