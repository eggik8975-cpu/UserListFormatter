using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> FormatUsers(string rawString)
    {
        var pairs = rawString
            .Split(',')
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrWhiteSpace(p));

        var result = new List<string>();

        foreach (var pair in pairs)
        {
            var parts = pair
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                continue;

            string surname = Capitalize(parts[0]);
            string name = Capitalize(parts[1]);

            result.Add($"{surname} {name}");
        }

        return result;
    }

    static string Capitalize(string word)
    {
        if (string.IsNullOrEmpty(word))
            return word;

        return char.ToUpper(word[0]) + word.Substring(1).ToLower();
    }

    static void Main()
    {
        string raw = " иванов иван,петров петр, сидорова Анна, бобров БОРИС ";

        Console.WriteLine("--- Форматирование списка пользователей ---");
        Console.WriteLine($"Исходная строка: \"{raw}\"");
        Console.WriteLine("Отформатированный список:");

        var formatted = FormatUsers(raw);
        for (int i = 0; i < formatted.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {formatted[i]}");
        }
    }
}