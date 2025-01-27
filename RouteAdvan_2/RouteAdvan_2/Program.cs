using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example 1: Reverse ArrayList in-place
        var list = new List<int> { 1, 2, 3, 4, 5 };
        ReverseArrayList(list);
        Console.WriteLine("Reversed List: " + string.Join(", ", list));

        // Example 2: Get even numbers
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var evenNumbers = GetEvenNumbers(numbers);
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

        // Example 3: FixedSizeList<T>
        var fixedList = new FixedSizeList<int>(3);
        fixedList.Add(1);
        fixedList.Add(2);
        fixedList.Add(3);
        Console.WriteLine("FixedSizeList Element at Index 1: " + fixedList.Get(1));

        // Example 4: First non-repeated character
        string input = "swiss";
        int index = FirstNonRepeatedCharacter(input);
        Console.WriteLine("First Non-Repeated Character Index: " + index);

        // Example 5: Count numbers greater than X
        int[] array = { 11, 5, 3 };
        var queries = new List<int> { 1, 5, 13 };
        var results = CountGreaterThanX(array, queries);
        Console.WriteLine("Count Greater Than X: " + string.Join(", ", results));

        // Example 6: Palindrome check
        int[] palindromeArray = { 1, 3, 2, 3, 1 };
        Console.WriteLine("Is Palindrome: " + IsPalindrome(palindromeArray));

        // Example 7: Reverse a queue using a stack
        var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
        var reversedQueue = ReverseQueue(queue);
        Console.WriteLine("Reversed Queue: " + string.Join(", ", reversedQueue));

        // Example 8: Balanced parentheses check
        string parentheses = "[()]{()}";
        Console.WriteLine("Is Balanced: " + IsBalanced(parentheses));

        // Example 9: Remove duplicates from an array
        int[] arrayWithDuplicates = { 1, 2, 2, 3, 4, 4 };
        var uniqueArray = RemoveDuplicates(arrayWithDuplicates);
        Console.WriteLine("Unique Array: " + string.Join(", ", uniqueArray));

        // Example 10: Remove odd numbers from a list
        var listWithOdds = new List<int> { 1, 2, 3, 4, 5 };
        var listWithoutOdds = RemoveOddNumbers(listWithOdds);
        Console.WriteLine("List Without Odds: " + string.Join(", ", listWithoutOdds));

        // Example 11: Generic queue
        var genericQueue = new GenericQueue();
        genericQueue.Enqueue(1);
        genericQueue.Enqueue("Apple");
        genericQueue.Enqueue(5.28);
        Console.WriteLine("Dequeued: " + genericQueue.Dequeue());

        // Example 12: Search for target in a stack
        var stack = new Stack<int>(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine(SearchInStack(stack, 3));

        // Example 13: Intersection of two arrays
        int[] array1 = { 1, 2, 3, 4, 4 };
        int[] array2 = { 10, 4, 4 };
        var intersection = FindIntersection(array1, array2);
        Console.WriteLine("Intersection: " + string.Join(", ", intersection));

        // Example 14: Contiguous sublist with target sum
        var sublistInput = new List<int> { 1, 2, 3, 7, 5 };
        int targetSum = 12;
        var sublist = FindSublistWithSum(sublistInput, targetSum);
        Console.WriteLine("Sublist With Target Sum: " + string.Join(", ", sublist));

        // Example 15: Reverse first K elements of a queue
        var queueForK = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
        int k = 3;
        var reversedKQueue = ReverseFirstKElements(queueForK, k);
        Console.WriteLine("Queue After Reversing First K Elements: " + string.Join(", ", reversedKQueue));
    }

    // 1. Reverse ArrayList in-place
    public static void ReverseArrayList<T>(List<T> list)
    {
        int left = 0, right = list.Count - 1;
        while (left < right)
        {
            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }

    // 2. Return a list of even numbers
    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        return numbers.Where(n => n % 2 == 0).ToList();
    }

    // 3. FixedSizeList<T>
    public class FixedSizeList<T>
    {
        private readonly List<T> _list;
        private readonly int _capacity;

        public FixedSizeList(int capacity)
        {
            _capacity = capacity;
            _list = new List<T>(capacity);
        }

        public void Add(T item)
        {
            if (_list.Count >= _capacity)
                throw new InvalidOperationException("List is full.");
            _list.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _list.Count)
                throw new ArgumentOutOfRangeException("Index is out of range.");
            return _list[index];
        }
    }

    // 4. First non-repeated character
    public static int FirstNonRepeatedCharacter(string input)
    {
        var frequency = new Dictionary<char, int>();

        foreach (char c in input)
        {
            if (frequency.ContainsKey(c))
                frequency[c]++;
            else
                frequency[c] = 1;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (frequency[input[i]] == 1)
                return i;
        }

        return -1;
    }

    // 5. Count numbers greater than X
    public static List<int> CountGreaterThanX(int[] array, List<int> queries)
    {
        return queries.Select(query => array.Count(num => num > query)).ToList();
    }

    // 6. Palindrome check
    public static string IsPalindrome(int[] array)
    {
        int left = 0, right = array.Length - 1;
        while (left < right)
        {
            if (array[left] != array[right])
                return "NO";
            left++;
            right--;
        }
        return "YES";
    }

    // 7. Reverse a queue using a stack
    public static Queue<T> ReverseQueue<T>(Queue<T> queue)
    {
        var stack = new Stack<T>();
        while (queue.Count > 0)
        {
            stack.Push(queue.Dequeue());
        }
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }
        return queue;
    }

    // 8. Balanced parentheses check
    public static string IsBalanced(string input)
    {
        var stack = new Stack<char>();
        foreach (char c in input)
        {
            if (c == '(' || c == '{' || c == '[')
                stack.Push(c);
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
                    return "Unbalanced";
            }
        }
        return stack.Count == 0 ? "Balanced" : "Unbalanced";
    }

    private static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }

    // 9. Remove duplicates from an array
    public static int[] RemoveDuplicates(int[] array)
    {
        return array.Distinct().ToArray();
    }

    // 10. Remove odd numbers from a list
    public static List<int> RemoveOddNumbers(List<int> list)
    {
        return list.Where(n => n % 2 == 0).ToList();
    }

    // 11. Generic queue
    public class GenericQueue
    {
        private readonly Queue<object> _queue = new Queue<object>();

        public void Enqueue(object item)
        {
            _queue.Enqueue(item);
        }

        public object Dequeue()
        {
            return _queue.Dequeue();
        }
    }

    // 12. Search for target in a stack
    public static string SearchInStack(Stack<int> stack, int target)
    {
        int count = 0;
        foreach (int item in stack)
        {
            count++;
            if (item == target)
                return $"Target was found successfully and the count = {count}";
        }
        return "Target was not found";
    }

    // 13. Intersection of two arrays
    public static List<int> FindIntersection(int[] array1, int[] array2)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in array1)
        {
            if (dict.ContainsKey(num))
                dict[num]++;
            else
                dict[num] = 1;
        }

        var intersection = new List<int>();
        foreach (var num in array2)
        {
            if (dict.ContainsKey(num) && dict[num] > 0)
            {
                intersection.Add(num);
                dict[num]--;
            }
        }

        return intersection;
    }

    // 14. Find contiguous sublist with target sum
    public static List<int> FindSublistWithSum(List<int> list, int targetSum)
    {
        int currentSum = 0;
        var sumDict = new Dictionary<int, int> { { 0, -1 } };

        for (int i = 0; i < list.Count; i++)
        {
            currentSum += list[i];

            if (sumDict.ContainsKey(currentSum - targetSum))
            {
                int start = sumDict[currentSum - targetSum] + 1;
                return list.GetRange(start, i - start + 1);
            }

            if (!sumDict.ContainsKey(currentSum))
                sumDict[currentSum] = i;
        }

        return new List<int>();
    }

    // 15. Reverse first K elements of a queue
    public static Queue<int> ReverseFirstKElements(Queue<int> queue, int k)
    {
        if (k > queue.Count || k <= 0)
            throw new ArgumentException("Invalid value for k.");

        var stack = new Stack<int>();

        for (int i = 0; i < k; i++)
        {
            stack.Push(queue.Dequeue());
        }

        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        for (int i = 0; i < queue.Count - k; i++)
        {
            queue.Enqueue(queue.Dequeue());
        }

        return queue;
    }
}
