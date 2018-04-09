using System;
using Cake.Core;
using Cake.Gem.Tests.Fixtures;
using Cake.Testing;
using Xunit;

namespace Cake.Gem.Tests
{
    public sealed class GemPushRunnerTests
    {
        public sealed class ThePushMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("settings", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Throw_If_Gem_Executable_Was_Not_Found()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Gem: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/Gem/gem.bat", "/bin/tools/Gem/gem.bat")]
            [InlineData("./tools/Gem/gem.bat", "/Working/tools/Gem/gem.bat")]
            public void Should_Use_Tfx_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.ToolPath = toolPath;
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Gem: Process was not started.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Gem: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_Find_Gem_Executable_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new GemPushRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/gem.bat", result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Gem_File_Is_Null()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.GemFilePath = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("gemFilePath", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Add_Key_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Key = "rubygems";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" --key \"rubygems\"", result.Args);
            }

            [Fact]
            public void Should_Add_Host_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Host = "http://localhost:8989";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" --host \"http://localhost:8989\"", result.Args);
            }

            [Fact]
            public void Should_Add_Http_Proxy_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.HttpProxy = "http://localhost:8989";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" -p \"http://localhost:8989\"", result.Args);
            }

            [Fact]
            public void Should_Add_Verbose_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Verbose = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" -V", result.Args);
            }

            [Fact]
            public void Should_Add_Quiet_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Quiet = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" -q", result.Args);
            }

            [Fact]
            public void Should_Add_Config_File_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.ConfigFilePath = "test.config";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" --config-file \"/Working/test.config\"", result.Args);
            }

            [Fact]
            public void Should_Add_Backtrace_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Backtrace = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" --backtrace", result.Args);
            }

            [Fact]
            public void Should_Add_Debug_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemPushRunnerFixture();
                fixture.Settings.Debug = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("push \"c:/temp/test.gem\" --debug", result.Args);
            }
        }
    }
}
