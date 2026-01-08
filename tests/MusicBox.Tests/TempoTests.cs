using MusicBox.Core;
using MusicBox.Domain;
using MusicBox.Errors;
using Xunit;

namespace MusicBox.Tests;

public class TempoTests
{
    [Fact]
    public void Tempo_Limits_RejectTooSmall()
    {
        Assert.Throws<InvalidTempoException>(() => new Tempo(99));
    }

    [Fact]
    public void Tempo_Limits_RejectTooLarge()
    {
        Assert.Throws<InvalidTempoException>(() => new Tempo(5001));
    }

    [Fact]
    public void DurationMs_ScalesCorrectly()
    {
        var tempo = new Tempo(200); // negra = 200ms
        Assert.Equal(200, tempo.DurationMs(Figure.Negra));
        Assert.Equal(400, tempo.DurationMs(Figure.Blanca));
        Assert.Equal(800, tempo.DurationMs(Figure.Redonda));
        Assert.Equal(100, tempo.DurationMs(Figure.Corchea));
        Assert.Equal(50, tempo.DurationMs(Figure.Semicorchea));
    }
}
