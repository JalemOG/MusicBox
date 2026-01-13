using System.Linq;
using MusicBox.Structures;
using Xunit;

namespace MusicBox.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void Append_AddsToTail_AndUpdatesHeadTail()
    {
        var list = new DoublyLinkedList<int>();
        list.Append(1);
        list.Append(2);
        list.Append(3);

        Assert.Equal(3, list.Count);
        Assert.NotNull(list.Head);
        Assert.NotNull(list.Tail);
        Assert.Equal(1, list.Head!.Value);
        Assert.Equal(3, list.Tail!.Value);
        Assert.Equal(new[] { 1, 2, 3 }, list.Forward().ToArray());
    }

    [Fact]
    public void Prepend_AddsToHead_AndUpdatesHeadTail()
    {
        var list = new DoublyLinkedList<int>();
        list.Prepend(1);
        list.Prepend(2);
        list.Prepend(3);

        Assert.Equal(3, list.Count);
        Assert.NotNull(list.Head);
        Assert.NotNull(list.Tail);
        Assert.Equal(3, list.Head!.Value);
        Assert.Equal(1, list.Tail!.Value);
        Assert.Equal(new[] { 3, 2, 1 }, list.Forward().ToArray());
    }

    [Fact]
    public void Backward_IteratesFromTailToHead()
    {
        var list = new DoublyLinkedList<string>();
        list.Append("a");
        list.Append("b");
        list.Append("c");

        Assert.Equal(new[] { "c", "b", "a" }, list.Backward().ToArray());
    }

    [Fact]
    public void Clear_ResetsListState()
    {
        var list = new DoublyLinkedList<int>();
        list.Append(10);
        list.Append(20);

        list.Clear();

        Assert.Equal(0, list.Count);
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
        Assert.Empty(list.Forward());
        Assert.Empty(list.Backward());
    }
}
