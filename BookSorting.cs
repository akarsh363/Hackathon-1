using System;
using System.Collections.Generic;

class BookSorting
{
    // Extract author and title from each entry
    private static (string author, string title) ParseEntry(string entry)
    {
        var split = entry.Split(new string[] { "\" by " }, StringSplitOptions.None);
        string title = split[0].Trim('"');
        string author = split[1].Split(',')[0];  // Only first author
        return (author.Trim(), title.Trim());
    }

    // Sort titles 
    public static List<string> SortTitles(List<string> books)
    {
        books.Sort(delegate (string a, string b)
        {
            var (authorA, titleA) = ParseEntry(a);
            var (authorB, titleB) = ParseEntry(b);

            int authorCompare = string.Compare(authorA, authorB, StringComparison.OrdinalIgnoreCase);
            if (authorCompare == 0)
            {
                return string.Compare(titleA, titleB, StringComparison.OrdinalIgnoreCase);
            }
            return authorCompare;
        });

        // Extract just the titles
        List<string> titles = new List<string>();
        foreach (string book in books)
        {
            var (_, title) = ParseEntry(book);
            titles.Add(title);
        }

        return titles;
    }

    // Main Function...
    static void Main()
    {
        var input = new List<string>
        {
            "\"The Canterbury Tales\" by Chaucer",
            "\"Algorithms\" by Sedgewick",
            "\"The C Programming Language\" by Kernighan and Ritchie"
        };

        var sortedTitles = SortTitles(input);

        foreach (var title in sortedTitles)
            Console.WriteLine(title);
    }
}