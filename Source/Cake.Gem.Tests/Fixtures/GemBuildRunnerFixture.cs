using Cake.Core.IO;
using Cake.Gem.Build;

namespace Cake.Gem.Tests.Fixtures
{
    internal sealed class GemBuildRunnerFixture : GemFixture<GemBuildSettings>
    {
        public FilePath GemSpecFilePath { get; set; }

        public GemBuildRunnerFixture()
        {
            GemSpecFilePath = "c:/temp/text.config";
        }

        protected override void RunTool()
        {
            var tool = new GemBuildRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Build(GemSpecFilePath, Settings);
        }
    }
}
