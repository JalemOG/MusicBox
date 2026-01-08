using MusicBox.Domain;
using MusicBox.Structures;

namespace MusicBox.Playback;

public sealed class Player
{
    private readonly IPlayerAudio _audio;
    private readonly Tempo _tempo;

    // 🔹 Logger opcional (verbose)
    public Action<string>? Logger { get; set; }

    public Player(IPlayerAudio audio, Tempo tempo)
    {
        _audio = audio;
        _tempo = tempo;
    }

    public void PlayForward(DoublyLinkedList<MusicEvent> score)
    {
        foreach (var ev in score.Forward())
            PlayEvent(ev);
    }

    public void PlayBackward(DoublyLinkedList<MusicEvent> score)
    {
        foreach (var ev in score.Backward())
            PlayEvent(ev);
    }

    private void PlayEvent(MusicEvent ev)
    {
        int ms = _tempo.DurationMs(ev.Figure);
        double hz = ev.FrequencyHz();

        // 👀 AQUÍ se muestra la info real
        Logger?.Invoke(
            $"Playing: {ev.Note} ({hz:F2} Hz) - {ev.Figure} ({ms} ms)"
        );

        _audio.PlayTone(hz, ms);
    }
}
