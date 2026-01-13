using MusicBox.Domain;
using Xunit;

namespace MusicBox.Tests;

public class DomainCatalogTests
{
    [Fact]
    public void NoteCatalog_IsCaseInsensitive_AndTrims()
    {
        var notes = new NoteCatalog();

        Assert.True(notes.IsValid(" Do "));
        Assert.True(notes.IsValid("re"));
        Assert.True(notes.IsValid("SOL"));
        Assert.Equal(Note.Do, notes.FromString(" do "));
        Assert.Equal(Note.Sol, notes.FromString("SOL"));
    }

    [Fact]
    public void FigureCatalog_IsCaseInsensitive_AndTrims()
    {
        var figs = new FigureCatalog();

        Assert.True(figs.IsValid(" Negra "));
        Assert.True(figs.IsValid("corchea"));
        Assert.True(figs.IsValid("SEMICORCHEA"));
        Assert.Equal(Figure.Negra, figs.FromString(" negra "));
        Assert.Equal(Figure.Semicorchea, figs.FromString("SEMICORCHEA"));
    }
}

