namespace mpt_lab_7;

public class WordCounter
{
    static void Main()
    {
        string text = "Dies veniunt et eunt. Dies solis surgit et occidit. Omnes dies sunt similes, sed non sunt " +
                      "idem. In omni die, in omni die, videmus mirabilia. Tempus fugit et tempus manet, sed memoria " +
                      "manet in aeternum. Omnia mutantur, omnia mutantur, sed non omnia pereunt.";
        
        WordCountAnalyzer analyzer = new WordCountAnalyzer();
        Dictionary<string, int> wordCount = analyzer.CountWords(text);

        Console.WriteLine("\nWords and their occurrences in the text:\n");
        foreach (var pair in wordCount)
        {
            Console.WriteLine($"The word '{pair.Key}' occurs {pair.Value} time(s)");
        }
    }
}