using System.Collections.Generic;
using MusicBox.Playback;

namespace MusicBox.Tests.Fakes;

public sealed class FakeAudio : IPlayerAudio
{
    public List<(double freq, int ms)> Tones { get; } = new();
    public List<int> Silences { get; } = new();

    public void PlayTone(double frequencyHz, int durationMs) => Tones.Add((frequencyHz, durationMs));
    public void Silence(int durationMs) => Silences.Add(durationMs);
    public void Clear() { Tones.Clear(); Silences.Clear(); }
}
