using System;
using System.Threading;

namespace MusicBox.Playback;

public sealed class BeepAudioEngine : IPlayerAudio
{
    public void PlayTone(double frequencyHz, int durationMs)
    {
        int freq = (int)Math.Round(frequencyHz);
        int ms = Math.Max(1, durationMs);

        // Console.Beep solo acepta 37..32767 Hz
        freq = Math.Clamp(freq, 37, 32767);

        Console.Beep(freq, ms);
    }

    public void Silence(int durationMs)
    {
        Thread.Sleep(Math.Max(0, durationMs));
    }
}
