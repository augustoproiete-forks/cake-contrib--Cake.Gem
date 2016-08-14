using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Testing;
using Cake.Gem.Tests.Fixtures;
using Xunit;

namespace Cake.Gem.Tests
{
    public sealed class GemBuildRunnerTests
    {
        public sealed class TheBuildMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
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
                var fixture = new GemBuildRunnerFixture();
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
                var fixture = new GemBuildRunnerFixture();
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
                var fixture = new GemBuildRunnerFixture();
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
                var fixture = new GemBuildRunnerFixture();
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
                var fixture = new GemBuildRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/gem.bat", result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_GemSpec_File_Is_Null()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.GemSpecFilePath = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("gemSpecFilePath", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Add_Force_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.Force = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" --force", result.Args);
            }

            [Fact]
            public void Should_Add_Verbose_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.Verbose = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" -V", result.Args);
            }

            [Fact]
            public void Should_Add_Quiet_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.Quiet = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" -q", result.Args);
            }

            [Fact]
            public void Should_Add_Config_File_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.ConfigFilePath = "test.config";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" --config-file \"/Working/test.config\"", result.Args);
            }

            [Fact]
            public void Should_Add_Backtrace_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.Backtrace = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" --backtrace", result.Args);
            }

            [Fact]
            public void Should_Add_Debug_To_Arguments_If_Set()
            {
                // Given
                var fixture = new GemBuildRunnerFixture();
                fixture.Settings.Debug = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("build \"c:/temp/text.config\" --debug", result.Args);
            }
        }
    }
}