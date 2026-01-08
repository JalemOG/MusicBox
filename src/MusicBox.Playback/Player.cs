using MusicBox.Core;
using MusicBox.Structures;

namespace MusicBox.Playback;

public sealed class Player
{
    private readonly IPlayerAudio _audio;
    private readonly Tempo _tempo;

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
        _audio.PlayTone(ev.FrequencyHz(), ms);
        // opcional: un pequeño silencio entre notas
        // _audio.Silence(10);
    }
}
