using System.Collections.Generic;
using MusicBox.Core;
using MusicBox.Tests.Fakes;
using Xunit;

namespace MusicBox.Tests;

public class VerboseLoggerTests
{
    [Fact]
    public void Logger_IsCalledOncePerNote_WithHzAndMs()
    {
        var audio = new FakeAudio();
        var app = new MusicBoxApp(audio, quarterMs: 100);

        var lines = new List<string>();
        app.SetPlaybackLogger(lines.Add);

        app.LoadFromString("(Do, negra), (Re, corchea)");
        app.PlayForward();

        Assert.Equal(2, lines.Count);

        // Line 1 should mention Do, 261.63 Hz, Negra, 100 ms
        Assert.Contains("Do", lines[0]);
        Assert.Contains("261.63", lines[0]);
        Assert.Contains("Negra", lines[0]);
        Assert.Contains("100 ms", lines[0]);

        // Line 2 should mention Re, 293.66 Hz, Corchea, 50 ms
        Assert.Contains("Re", lines[1]);
        Assert.Contains("293.66", lines[1]);
        Assert.Contains("Corchea", lines[1]);
        Assert.Contains("50 ms", lines[1]);
    }
}
