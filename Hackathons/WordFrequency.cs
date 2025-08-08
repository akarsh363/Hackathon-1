using System;
using System.Collections.Generic; // For list and dictionary..

class WordFrequency
{
    //Counting word frequencies
    public static Dictionary<string, int> CountFrequencies(string input)
    {
        var wordFreq = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        string[] words = input
            .Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            string w = word.ToLower();
            if (wordFreq.ContainsKey(w))
                wordFreq[w]++;
            else
                wordFreq[w] = 1;
        }

        return wordFreq;
    }

    //Sort word frequencies 
    public static List<KeyValuePair<string, int>> SortFrequencies(Dictionary<string, int> freqMap)
    {
        List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>();

        foreach (var kvp in freqMap)
        {
            sortedList.Add(kvp);
        }

        //first by frequency descending, then by key descending
        sortedList.Sort(delegate (KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            if (a.Value != b.Value)
            {
                return b.Value.CompareTo(a.Value); // Higher frequency first
            }
            else
            {
                return string.Compare(b.Key, a.Key, StringComparison.OrdinalIgnoreCase); // Reverse alphabetical
            }
        });

        return sortedList;
    }

    //Print the sorted frequencies
    public static void PrintFrequencies(List<KeyValuePair<string, int>> sortedFreq)
    {
        if (sortedFreq.Count == 0)
        {
            Console.WriteLine("0");
            return;
        }

        foreach (var kvp in sortedFreq)
        {
            Console.WriteLine($"{kvp.Value} {kvp.Key}");
        }
    }

    // Main Function
    static void Main()
    {
        Console.WriteLine("Enter the Sentence: ");
        string input = Console.ReadLine();
        var freqMap = CountFrequencies(input);
        var sortedFreq = SortFrequencies(freqMap);
        PrintFrequencies(sortedFreq);
    }
}
