using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Gem
{
    /// <summary>
    /// The top level argument builder for the Gem CLI Tool
    /// </summary>
    /// <typeparam name="T">The Settings type to build arguments from</typeparam>
    public abstract class GemArgumentBuilder<T>
        where T : GemSettings
    {
        private readonly ICakeEnvironment _environment;
        private readonly ProcessArgumentBuilder _builder;
        private readonly T _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GemArgumentBuilder{T}"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="setting">The settings</param>
        protected GemArgumentBuilder(ICakeEnvironment environment, T setting)
        {
            _environment = environment;
            _settings = setting;
            _builder = new ProcessArgumentBuilder();
        }

        /// <summary>
        /// Gets the Cake Environment
        /// </summary>
        protected ICakeEnvironment Environment => _environment;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>A populated argument builder.</returns>
        public ProcessArgumentBuilder GetArguments()
        {
            AddArguments(_builder, _settings);
            AddCommonArguments();
            return _builder;
        }

        /// <summary>
        /// Adds the arguments to the specified argument builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="settings">The settings.</param>
        protected abstract void AddArguments(ProcessArgumentBuilder builder, T settings);

        private void AddCommonArguments()
        {
            if (_settings.Verbose)
            {
                _builder.Append("-V");
            }

            if (_settings.Quiet)
            {
                _builder.Append("-q");
            }

            if (_settings.ConfigFilePath != null)
            {
                _builder.Append("--config-file");
                _builder.AppendQuoted(_settings.ConfigFilePath.MakeAbsolute(_environment).FullPath);
            }

            if (_settings.Backtrace)
            {
                _builder.Append("--backtrace");
            }

            if (_settings.Debug)
            {
                _builder.Append("--debug");
            }
        }
    }
}