using System;

namespace MusicBox.Playback;

public sealed class BeepAudioEngine : IPlayerAudio
{
    public void PlayTone(double frequencyHz, int durationMs)
    {
        // Console.Beep acepta int Hz (37..32767). Tus frecuencias entran perfecto.
        int freq = (int)Math.Round(frequencyHz);

        // duración mínima razonable
        int ms = Math.Max(1, durationMs);

        Console.Beep(freq, ms);
    }

    public void Silence(int durationMs)
    {
        int ms = Math.Max(0, durationMs);
        Thread.Sleep(ms);
    }
}
