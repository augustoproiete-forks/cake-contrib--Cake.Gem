using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gem.Build
{
    /// <summary>
    /// The Gem Build Runner used to create gems.
    /// </summary>
    public sealed class GemBuildRunner : GemTool<GemBuildSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GemBuildRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public GemBuildRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Builds a gem using the specified settings.
        /// </summary>
        /// <param name="gemSpecFilePath">The path to the gemspec file.</param>
        /// <param name="settings">The settings.</param>
        public void Build(FilePath gemSpecFilePath, GemBuildSettings settings)
        {
            if (gemSpecFilePath == null)
            {
                throw new ArgumentNullException(nameof(gemSpecFilePath));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunGem(settings, new GemBuildArgumentBuilder(_environment, gemSpecFilePath, settings));
        }
    }
}