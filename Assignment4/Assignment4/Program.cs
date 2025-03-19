using System;

class Node<T>
{
    public T Data;
    public Node<T>? Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList<T>
{
    private Node<T>? head;

    public void Add(T data)
    {
        if (head == null)
        {
            head = new Node<T>(data);
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node<T>(data);
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T>? current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(5);
        list.Add(30);

        
        Console.WriteLine("链表元素:");
        list.ForEach(item => Console.Write(item + " "));
        Console.WriteLine();

        
        int max = int.MinValue;
        list.ForEach(item => max = item > max ? item : max);
        Console.WriteLine("最大值: " + max);

        
        int min = int.MaxValue;
        list.ForEach(item => min = item < min ? item : min);
        Console.WriteLine("最小值: " + min);

        
        int sum = 0;
        list.ForEach(item => sum += item);
        Console.WriteLine("总和: " + sum);
    }
}
