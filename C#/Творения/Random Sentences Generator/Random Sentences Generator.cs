using System;

namespace Random_Sentences_Generator;

class Program
{
    static void Main(string[] args)
    {
        string[] names = { "Peter", "Michell", "Jane", "Steve" };
        string[] places = { "Sofia", "Plovdiv", "Varna", "Burgas" };
        string[] verbs = { "eats", "holds", "sees", "plays with", "brings" };
        string[] nouns = { "stones", "cake", "apple", "laptop", "bikes" };
        string[] adverbs = { "slowly", "diligently", "warmly", "sadly", "rapidly" };
        string[] details = { "near the river", "at home", "in the park" };

        Console.WriteLine("Hello, this is your first random-generated sentence:");
        while (true)
        {
            string randomName = GetRandomWord(names);
            string randomPlace = GetRandomWord(places);
            string randomVerb = GetRandomWord(verbs);
            string randomNoun = GetRandomWord(nouns);
            string randomAdverb = GetRandomWord(adverbs);
            string randomDetail = GetRandomWord(details);

            string who = $"{randomName} from {randomPlace}";
            string action = $"{randomAdverb} {randomVerb} {randomNoun}";
            string sentence = $"{who} {action} {randomDetail}";

            Console.WriteLine(sentence);
            Console.WriteLine("Press [Enter] to generate a new one.");

            Console.ReadLine();
        }
    }

    static string GetRandomWord(string[] words)
    {
        Random random = new();
        int randomIndex = random.Next(words.Length);
        string word = words[randomIndex];

        return word;
    }
}
