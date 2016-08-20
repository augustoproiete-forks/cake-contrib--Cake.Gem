using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Gem.Build;

namespace Cake.Gem.Push
{
    /// <summary>
    /// The Gem Push Runner used to push gems.
    /// </summary>
    public sealed class GemPushRunner : GemTool<GemPushSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GemPushRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public GemPushRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Pushes a gem using the specified settings.
        /// </summary>
        /// <param name="gemFilePath">The path to the gem file.</param>
        /// <param name="settings">The settings.</param>
        public void Push(FilePath gemFilePath, GemPushSettings settings)
        {
            if (gemFilePath == null)
            {
                throw new ArgumentNullException(nameof(gemFilePath));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunGem(settings, new GemPushArgumentBuilder(_environment, gemFilePath, settings));
        }
    }
}