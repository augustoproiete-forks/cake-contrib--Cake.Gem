namespace Cake.Gem.Build
{
    /// <summary>
    /// Contains settings used by <see cref="GemBuildRunner"/>.
    /// </summary>
    public sealed class GemBuildSettings : GemSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to skip validation of the spec.
        /// </summary>
        public bool Force { get; set; }
    }
}