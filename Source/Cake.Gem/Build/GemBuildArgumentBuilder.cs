using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gem.Build
{
    /// <summary>
    /// The Argument Builder for the Build method of the Gem CLI.
    /// </summary>
    internal sealed class GemBuildArgumentBuilder : GemArgumentBuilder<GemBuildSettings>
    {
        private readonly FilePath _gemSpecFilePath;
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GemBuildArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="gemSpecFilePath">The path of the gemspec file.</param>
        /// <param name="settings">The settings.</param>
        public GemBuildArgumentBuilder(ICakeEnvironment environment, FilePath gemSpecFilePath, GemBuildSettings settings)
            : base(environment, settings)
        {
            _environment = environment;
            _gemSpecFilePath = gemSpecFilePath;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected override void AddArguments(ProcessArgumentBuilder builder, GemBuildSettings settings)
        {
            builder.Append("build");

            builder.AppendQuoted(_gemSpecFilePath.MakeAbsolute(_environment).FullPath);

            if (settings.Force)
            {
                builder.Append("--force");
            }
        }
    }
}