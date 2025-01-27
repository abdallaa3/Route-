using System;
using System.Collections;
using System.Collections.Generic;

public class Range<T> where T : IComparable<T>
{
    private T _minValue;
    private T _maxValue;

    public Range(T minValue, T maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(_minValue) >= 0 && value.CompareTo(_maxValue) <= 0;
    }

    public dynamic Length()
    {
        dynamic min = _minValue;
        dynamic max = _maxValue;
        return max - min;
    }
}

public static class ArrayListExtensions
{
    public static void ReverseArrayList(ArrayList arrayList)
    {
        int start = 0;
        int end = arrayList.Count - 1;

        while (start < end)
        {
            var temp = arrayList[start];
            arrayList[start] = arrayList[end];
            arrayList[end] = temp;

            start++;
            end--;
        }
    }
}

public static class NumberUtils
{
    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        return numbers.FindAll(n => n % 2 == 0);
    }
}

public class FixedSizeList<T>
{
    private T[] _items;
    private int _capacity;
    private int _size = 0;

    public FixedSizeList(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        _capacity = capacity;
        _items = new T[capacity];
    }

    public void Add(T item)
    {
        if (_size >= _capacity)
            throw new InvalidOperationException("List is full.");

        _items[_size++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException("Invalid index.");

        return _items[index];
    }
}

public static class CharacterUtils
{
    public static int FirstNonRepeatedCharacter(string str)
    {
        var characterCount = new Dictionary<char, int>();

        // Count occurrences  
        foreach (char c in str)
        {
            if (characterCount.ContainsKey(c))
                characterCount[c]++;
            else
                characterCount[c] = 1;
        }

        // Find first non-repeated character  
        for (int i = 0; i < str.Length; i++)
        {
            if (characterCount[str[i]] == 1)
                return i; 
        }

        return -1;  
    }
}

class Program
{
    static void Main(string[] args)
    {

        // Range Example  
        var intRange = new Range<int>(1, 10);
        Console.WriteLine(intRange.IsInRange(5)); // True  
        Console.WriteLine(intRange.Length()); // 9  

        // ArrayList Example  
        var arrayList = new ArrayList { 1, 2, 3, 4, 5 };
        ArrayListExtensions.ReverseArrayList(arrayList);
        Console.WriteLine(string.Join(", ", arrayList)); 

        // Even Numbers Example  
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var evenNumbers = NumberUtils.GetEvenNumbers(numbers);
        Console.WriteLine(string.Join(", ", evenNumbers));   

        // FixedSizeList Example  
        var fixedList = new FixedSizeList<int>(3);
        fixedList.Add(1);
        fixedList.Add(2);
        fixedList.Add(3);
        // fixedList.Add(4); // Uncommenting this line would throw an exception  

        Console.WriteLine(fixedList.Get(0));   

        // First Non-Repeated Character Example  
        Console.WriteLine(CharacterUtils.FirstNonRepeatedCharacter("swiss"));   
    }
}
