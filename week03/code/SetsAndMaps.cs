using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1 - Find Pairs with Sets
    // Finds symmetric pairs of two-letter words (e.g. "am" & "ma") in O(n) time.
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> set = new HashSet<string>(words);
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            // Skip palindrome-like words (e.g. "aa") — they can't have a distinct reverse
            if (word[0] == word[1])
                continue;

            string reverse = $"{word[1]}{word[0]}";

            // Only add the pair once by enforcing lexicographic order
            if (set.Contains(reverse) && String.Compare(word, reverse) < 0)
            {
                result.Add($"{word} & {reverse}");
            }
        }

        return result.ToArray();
    }

    // Problem 2 - Degree Summary
    // Reads a CSV file and counts how many people hold each type of degree (column index 3).
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degrees = new Dictionary<string, int>();

        // Skip(1) skips the header row if one exists — safe to remove if census.txt has no header
        foreach (string line in File.ReadAllLines(filename).Skip(1))
        {
            string[] parts = line.Split(',');

            if (parts.Length < 4)
                continue;

            string degree = parts[3].Trim();

            if (string.IsNullOrEmpty(degree))
                continue;

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    // Problem 3 - Anagrams
    // Returns true if word1 and word2 are anagrams (same letters, same counts).
    // Ignores spaces and letter case.
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Quick length check — anagrams must have equal length
        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        // Count frequency of each letter in word1
        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        // Subtract frequency using word2; any mismatch means not an anagram
        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // Problem 5 - Earthquake JSON Data
    // Fetches today's earthquake data from USGS and returns formatted summary strings.
    public static string[] EarthquakeDailySummary()
    {
        const string url =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using HttpClient client = new HttpClient();

        string json = client.GetStringAsync(url).Result;

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        FeatureCollection featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> result = new List<string>();

        foreach (Feature feature in featureCollection.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            // Skip entries that are missing location or magnitude data
            if (string.IsNullOrEmpty(place))
                continue;

            result.Add($"{place} - Mag {mag ?? 0}");
        }

        return result.ToArray();
    }
}
