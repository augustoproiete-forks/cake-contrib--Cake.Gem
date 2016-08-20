namespace Cake.Gem.Push
{
    /// <summary>
    /// Contains settings used by <see cref="GemPushRunner"/>.
    /// </summary>
    public sealed class GemPushSettings : GemSettings
    {
        /// <summary>
        /// Gets or sets the name of the API Key in the credentials file which should be used for pushing the gem.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the address of the (gemcutter-compatible) host which the gem should be pushed to.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the Http Proxy which should be used for remote operations.
        /// </summary>
        public string HttpProxy { get; set; }
    }
}