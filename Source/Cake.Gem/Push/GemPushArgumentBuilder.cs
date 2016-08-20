using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gem.Push
{
    /// <summary>
    /// The Argument Builder for the Push method of the Gem CLI.
    /// </summary>
    internal sealed class GemPushArgumentBuilder : GemArgumentBuilder<GemPushSettings>
    {
        private readonly FilePath _gemFilePath;
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GemPushArgumentBuilder"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="gemFilePath">The path of the gem file.</param>
        /// <param name="settings">The settings.</param>
        public GemPushArgumentBuilder(ICakeEnvironment environment, FilePath gemFilePath, GemPushSettings settings)
            : base(environment, settings)
        {
            _environment = environment;
            _gemFilePath = gemFilePath;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected override void AddArguments(ProcessArgumentBuilder builder, GemPushSettings settings)
        {
            builder.Append("push");

            builder.AppendQuoted(_gemFilePath.MakeAbsolute(_environment).FullPath);

            if (!string.IsNullOrWhiteSpace(settings.Key))
            {
                builder.Append("--key");
                builder.AppendQuoted(settings.Key);
            }

            if (!string.IsNullOrWhiteSpace(settings.Host))
            {
                builder.Append("--host");
                builder.AppendQuoted(settings.Host);
            }

            if (!string.IsNullOrWhiteSpace(settings.HttpProxy))
            {
                builder.Append("-p");
                builder.AppendQuoted(settings.HttpProxy);
            }
        }
    }
}