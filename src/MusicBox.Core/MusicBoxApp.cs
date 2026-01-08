using MusicBox.Domain;
using MusicBox.Playback;
using MusicBox.Structures;

namespace MusicBox.Core;

public sealed class MusicBoxApp
{
    private readonly Tempo _tempo;
    private readonly ScoreParser _parser;
    private DoublyLinkedList<MusicEvent> _score;
    private readonly Player _player;

    public MusicBoxApp(IPlayerAudio audio, int quarterMs = 500)
    {
        _tempo = new Tempo(quarterMs);
        _parser = new ScoreParser(new NoteCatalog(), new FigureCatalog());
        _score = new DoublyLinkedList<MusicEvent>();
        _player = new Player(audio, _tempo);
    }

    public void SetPlaybackLogger(Action<string>? logger)
    {
        // _player es privado, pero estamos dentro de la clase
        _player.Logger = logger;
    }
    public void LoadFromString(string input) => _score = _parser.Parse(input);

    public void SetQuarterDuration(int ms) => _tempo.SetQuarterMs(ms);

    public void PlayForward() => _player.PlayForward(_score);

    public void PlayBackward() => _player.PlayBackward(_score);

    public void Clear() => _score.Clear();

    public int Count() => _score.Count;
}
