using Cake.Core.IO;
using Cake.Gem.Push;

namespace Cake.Gem.Tests.Fixtures
{
    internal sealed class GemPushRunnerFixture : GemFixture<GemPushSettings>
    {
        public FilePath GemFilePath { get; set; }

        public GemPushRunnerFixture()
        {
            GemFilePath = "c:/temp/test.gem";
        }

        protected override void RunTool()
        {
            var tool = new GemPushRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Push(GemFilePath, Settings);
        }
    }
}