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

        // Save using binary serialization
        WordCountData data = new WordCountData { WordCount = wordCount };
        DataSaver dataSaver = new DataSaver();
        dataSaver.SaveBinary("wordCountData.bin", data);

        // Save using JSON serialization
        JsonSerializer jsonSerializer = new JsonSerializer();
        jsonSerializer.SerializeToJson("wordCountData.json", data);

        // Load from binary file
        WordCountData loadedDataBinary = dataSaver.LoadBinary("wordCountData.bin");

        // Load from JSON file
        WordCountData loadedDataJson = jsonSerializer.DeserializeFromJson("wordCountData.json");

        // Display loaded data
        Console.WriteLine("\nLoaded Data from Binary File:\n");
        DisplayWordCount(loadedDataBinary.WordCount);

        Console.WriteLine("\nLoaded Data from JSON File:\n");
        DisplayWordCount(loadedDataJson.WordCount);
    }

    static void DisplayWordCount(Dictionary<string, int> wordCount)
    {
        foreach (var pair in wordCount)
        {
            Console.WriteLine($"The word '{pair.Key}' occurs {pair.Value} time(s)");
        }
    }
}