using MusicBox.Core;
using MusicBox.Tests.Fakes;
using MusicBox.Errors;
using Xunit;

namespace MusicBox.Tests;

public class PlaybackTests
{
    [Fact]
    public void PlayForward_ProducesTonesInOrder()
    {
        var audio = new FakeAudio();
        var app = new MusicBoxApp(audio, quarterMs: 100);

        app.LoadFromString("(Do, negra), (Re, negra), (Mi, negra)");
        app.PlayForward();

        Assert.Equal(3, audio.Tones.Count);
        Assert.Equal(261.63, audio.Tones[0].freq, 2);
        Assert.Equal(293.66, audio.Tones[1].freq, 2);
        Assert.Equal(329.63, audio.Tones[2].freq, 2);
    }

    [Fact]
    public void PlayBackward_ProducesTonesInReverseOrder()
    {
        var audio = new FakeAudio();
        var app = new MusicBoxApp(audio, quarterMs: 100);

        app.LoadFromString("(Do, negra), (Re, negra), (Mi, negra)");
        app.PlayBackward();

        Assert.Equal(3, audio.Tones.Count);
        Assert.Equal(329.63, audio.Tones[0].freq, 2);
        Assert.Equal(293.66, audio.Tones[1].freq, 2);
        Assert.Equal(261.63, audio.Tones[2].freq, 2);
    }

    [Fact]
    public void SetQuarterDuration_OutOfRange_Throws()
    {
        var audio = new FakeAudio();
        var app = new MusicBoxApp(audio, quarterMs: 100);

        Assert.Throws<InvalidTempoException>(() => app.SetQuarterDuration(10));
    }
}
