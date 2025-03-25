using System;

class Node<T>
{
    public T val { get; set; }
    public Node<T>? next;
    public Node(T val, Node<T>? next)
    {
        this.val = val;
        this.next = next;
    }
}

class List<T>
{
    public Node<T>? head;
    public int len;
    public List()
    {
        this.head = null;
        this.len = 0;
    }
    public void add(T t)
    {
        Node<T> node = new Node<T>(t, null);
        node.next = this.head;
        head = node;
    }
    public void forEach(Action<T> action)
    {
        Node<T>? tem = head;
        while(tem!=null)
        {
            action(tem.val);
            tem = tem.next;
        }
    }
}

class Program
{
    static void Main()
    {
        List<int> list = new List<int>();
        list.add(10);
        list.add(20);
        list.add(5);
        list.add(30);

        Console.WriteLine("the list includes:");
        list.forEach(item => Console.Write($"{item} "));
        Console.WriteLine("\n");

        int max = list.head.val;
        list.forEach(item => max = item > max ? item : max);
        Console.WriteLine($"max = {max}");

        int sum = 0;
        list.forEach(item => sum += item);
        Console.WriteLine("总和: " + sum);

        int min = int.MaxValue;
        list.forEach(item => min = item < min ? item : min);
        Console.WriteLine("最小值: " + min);
    }
}