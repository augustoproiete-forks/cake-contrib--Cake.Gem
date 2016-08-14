using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Gem
{
    /// <summary>
    /// Contains the common settings used by all commands in Gem.
    /// </summary>
    public abstract class GemSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to use verbose level of output.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to silence commands.
        /// </summary>
        public bool Quiet { get; set; }

        /// <summary>
        /// Gets or sets a value for the configuration file to use instead of default
        /// </summary>
        public FilePath ConfigFilePath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show stack backtrace on errors.
        /// </summary>
        public bool Backtrace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to turn on Ruby debugging.
        /// </summary>
        public bool Debug { get; set; }
    }
}