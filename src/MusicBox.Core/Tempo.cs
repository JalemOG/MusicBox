using MusicBox.Domain;
using MusicBox.Errors;

namespace MusicBox.Core;

public sealed class Tempo
{
    private int _quarterMs;

    public Tempo(int quarterMs)
    {
        SetQuarterMs(quarterMs);
    }

    public int QuarterMs => _quarterMs;

    public void SetQuarterMs(int ms)
    {
        if (ms < 100 || ms > 5000)
            throw new InvalidTempoException("Quarter (negra) duration must be between 100 ms and 5000 ms.");

        _quarterMs = ms;
    }

    public int DurationMs(Figure figure)
    {
        // Factors relative to negra
        // Redonda=4, Blanca=2, Negra=1, Corchea=0.5, Semicorchea=0.25
        double factor = figure switch
        {
            Figure.Redonda => 4.0,
            Figure.Blanca => 2.0,
            Figure.Negra => 1.0,
            Figure.Corchea => 0.5,
            Figure.Semicorchea => 0.25,
            _ => 1.0
        };

        return (int)System.Math.Round(_quarterMs * factor);
    }
}
