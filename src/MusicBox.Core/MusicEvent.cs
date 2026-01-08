using MusicBox.Domain;

namespace MusicBox.Core;

public sealed class MusicEvent
{
    public Note Note { get; }
    public Figure Figure { get; }

    public MusicEvent(Note note, Figure figure)
    {
        Note = note;
        Figure = figure;
    }

    public double FrequencyHz() => Note switch
    {
        Note.Do => 261.63,
        Note.Re => 293.66,
        Note.Mi => 329.63,
        Note.Fa => 349.23,
        Note.Sol => 392.00,
        Note.La => 440.00,
        Note.Si => 493.88,
        _ => 440.00
    };
}
