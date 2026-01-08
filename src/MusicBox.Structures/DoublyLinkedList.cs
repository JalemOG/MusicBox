using System;
using System.Collections.Generic;

namespace MusicBox.Structures;

public sealed class DoublyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _size;

    public int Count => _size;
    public Node<T>? Head => _head;
    public Node<T>? Tail => _tail;

    public void Append(T value)
    {
        var node = new Node<T>(value);

        if (_tail is null)
        {
            _head = _tail = node;
        }
        else
        {
            node.Prev = _tail;
            _tail.Next = node;
            _tail = node;
        }

        _size++;
    }

    public void Prepend(T value)
    {
        var node = new Node<T>(value);

        if (_head is null)
        {
            _head = _tail = node;
        }
        else
        {
            node.Next = _head;
            _head.Prev = node;
            _head = node;
        }

        _size++;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }

    public IEnumerable<T> Forward()
    {
        var cur = _head;
        while (cur is not null)
        {
            yield return cur.Value;
            cur = cur.Next;
        }
    }

    public IEnumerable<T> Backward()
    {
        var cur = _tail;
        while (cur is not null)
        {
            yield return cur.Value;
            cur = cur.Prev;
        }
    }
}
