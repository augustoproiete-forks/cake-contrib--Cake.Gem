using Cake.Core.Tooling;
using Cake.Testing.Fixtures;

namespace Cake.Gem.Tests
{
    internal abstract class GemFixture<TSettings> : ToolFixture<TSettings>
        where TSettings : ToolSettings, new()
    {
        protected GemFixture()
            : base("gem.bat")
        {
        }
    }
}