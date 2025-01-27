using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example 1: Frequency of elements using a hash table
        var array = new int[] { 1, 2, 2, 3, 3, 3 };
        var frequency = CountFrequency(array);
        Console.WriteLine("Frequency: " + string.Join(", ", frequency.Select(kvp => $"{kvp.Key}:{kvp.Value}")));

        // Example 2: Key with the highest value in a hash table
        var hashTable = new Dictionary<string, int>
        {
            { "key1", 10 },
            { "key2", 20 },
            { "key3", 15 }
        };
        Console.WriteLine("Key with Highest Value: " + KeyWithHighestValue(hashTable));

        // Example 3: Keys associated with a specific value
        var hashTableStrings = new Dictionary<string, string>
        {
            { "key1", "apple" },
            { "key2", "banana" },
            { "key3", "apple" }
        };
        var keys = FindKeysForValue(hashTableStrings, "apple");
        Console.WriteLine("Keys for Value 'apple': " + (keys.Any() ? string.Join(", ", keys) : "Key not found"));

        // Example 4: Group anagrams together
        var strings = new string[] { "bat", "tab", "cat", "act" };
        var groupedAnagrams = GroupAnagrams(strings);
        Console.WriteLine("Grouped Anagrams: ");
        foreach (var group in groupedAnagrams)
            Console.WriteLine(string.Join(", ", group));

        // Example 5: Check for duplicates in an array
        var duplicatesArray = new int[] { 1, 2, 3, 4, 2 };
        Console.WriteLine("Contains Duplicates: " + ContainsDuplicates(duplicatesArray));

        // Example 6: SortedDictionary operations
        var students = new SortedDictionary<int, string>();
        students[1] = "Alice";
        students[2] = "Bob";
        students[3] = "Charlie";
        Console.WriteLine("Students: " + string.Join(", ", students.Select(kvp => $"{kvp.Key}:{kvp.Value}")));

        // Example 7: Employee directory using SortedList
        var employees = new SortedList<int, string>
        {
            { 1001, "John" },
            { 1003, "Jane" },
            { 1002, "Doe" }
        };
        Console.WriteLine("Employee Directory: " + string.Join(", ", employees.Select(kvp => $"{kvp.Key}:{kvp.Value}")));

        // Example 8: Find missing numbers
        var missingArray = new int[] { 1, 2, 4, 6 };
        var missingNumbers = FindMissingNumbers(missingArray, 6);
        Console.WriteLine("Missing Numbers: " + string.Join(", ", missingNumbers));

        // Example 9: Create a HashSet with unique values
        var listWithDuplicates = new List<int> { 1, 2, 2, 3, 4, 4 };
        var uniqueSet = CreateHashSet(listWithDuplicates);
        Console.WriteLine("Unique Values: " + string.Join(", ", uniqueSet));

        // Example 10: Swap keys and values in a hash table
        var swappedHashTable = SwapKeysAndValues(hashTable);
        Console.WriteLine("Swapped Hash Table: " + string.Join(", ", swappedHashTable.Select(kvp => $"{kvp.Key}:{kvp.Value}")));

        // Example 11: Union of two sets
        var set1 = new HashSet<int> { 1, 2, 3 };
        var set2 = new HashSet<int> { 3, 4, 5 };
        var unionSet = UnionOfSets(set1, set2);
        Console.WriteLine("Union of Sets: " + string.Join(", ", unionSet));

        // Example 12: Count keys starting with a specific character
        var dictionary = new Dictionary<string, int>
        {
            { "apple", 1 },
            { "animal", 2 },
            { "airport", 3 }
        };
        Console.WriteLine("Keys starting with 'a': " + CountKeysStartingWith(dictionary, 'a'));

        // Example 13: Elements greater than target in a sorted set
        var sortedSet = new SortedSet<int> { 1, 3, 5, 7, 9 };
        var greaterThanTarget = FindElementsGreaterThan(sortedSet, 4);
        Console.WriteLine("Elements Greater Than Target: " + string.Join(", ", greaterThanTarget));

        // Example 14: Keys with even values in a sorted list
        var sortedList = new SortedList<int, int>
        {
            { 1, 10 },
            { 2, 15 },
            { 3, 20 }
        };
        var evenValueKeys = FindKeysWithEvenValues(sortedList);
        Console.WriteLine("Keys with Even Values: " + string.Join(", ", evenValueKeys));
    }

    // Implementations
    public static Dictionary<int, int> CountFrequency(int[] array) =>
        array.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

    public static string KeyWithHighestValue(Dictionary<string, int> hashTable) =>
        hashTable.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;

    public static List<string> FindKeysForValue(Dictionary<string, string> hashTable, string targetValue) =>
        hashTable.Where(kvp => kvp.Value == targetValue).Select(kvp => kvp.Key).ToList();

    public static List<List<string>> GroupAnagrams(string[] strings) =>
        strings.GroupBy(str => string.Concat(str.OrderBy(c => c)))
               .Select(group => group.ToList()).ToList();

    public static bool ContainsDuplicates(int[] array) =>
        array.Length != array.Distinct().Count();

    public static List<int> FindMissingNumbers(int[] array, int n) =>
        Enumerable.Range(1, n).Except(array).ToList();

    public static HashSet<int> CreateHashSet(List<int> list) =>
        new HashSet<int>(list);

    public static Dictionary<int, string> SwapKeysAndValues(Dictionary<string, int> hashTable) =>
        hashTable.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

    public static HashSet<int> UnionOfSets(HashSet<int> set1, HashSet<int> set2) =>
        new HashSet<int>(set1.Union(set2));

    public static int CountKeysStartingWith(Dictionary<string, int> dictionary, char targetChar) =>
        dictionary.Keys.Count(key => key.StartsWith(targetChar.ToString()));

    public static List<int> FindElementsGreaterThan(SortedSet<int> sortedSet, int target) =>
        sortedSet.Where(x => x > target).ToList();

    public static List<int> FindKeysWithEvenValues(SortedList<int, int> sortedList) =>
        sortedList.Where(kvp => kvp.Value % 2 == 0).Select(kvp => kvp.Key).ToList();
}
