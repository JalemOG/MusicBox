namespace MusicBox.Playback;

public interface IPlayerAudio
{
    void PlayTone(double frequencyHz, int durationMs);
    void Silence(int durationMs);
}
