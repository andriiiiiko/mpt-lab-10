namespace mpt_lab_7;

/// <summary>
/// Contains the entry point for the application.
/// </summary>
public class WordCounter
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
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
        WordCountData? loadedDataJson = jsonSerializer.DeserializeFromJson("wordCountData.json");

        // Display loaded data
        Console.WriteLine("\nLoaded Data from Binary File:\n");
        DisplayWordCount(loadedDataBinary.WordCount);

        Console.WriteLine("\nLoaded Data from JSON File:\n");
        if (loadedDataJson != null) DisplayWordCount(loadedDataJson.WordCount);

        // Sort and display sorted data
        Console.WriteLine("\nSorted Words:\n");
        DisplaySortedWords(loadedDataBinary.SortedWords);

        Console.WriteLine("\nSorted Word Count:\n");
        DisplaySortedWordCount(loadedDataBinary.SortedWordCount);

        // Filter and display filtered data
        Console.WriteLine("\nFiltered Words (length > 3):\n");
        DisplayWordCount(analyzer.FilterWords(loadedDataBinary.WordCount, pair => pair.Key.Length > 3));
        
        
        int arraySize = 1000000;
        int minValue = 0;
        int maxValue = 10000;
        int numThreads = 4;

        int[] arrayToFill = new int[arraySize];
        ParallelArrayProcessor.FillArrayInParallel(arrayToFill, minValue, maxValue, numThreads);

        // Measure and compare the time for sorting with different numbers of threads
        Console.WriteLine("Sorting with 1 thread:");
        MeasureAndDisplaySortingTime(arrayToFill, 1);

        Console.WriteLine("Sorting with 4 threads:");
        MeasureAndDisplaySortingTime(arrayToFill, 4);
    }

    /// <summary>
    /// Displays the word count.
    /// </summary>
    /// <param name="wordCount">The word count dictionary.</param>
    static void DisplayWordCount(Dictionary<string, int> wordCount)
    {
        foreach (var pair in wordCount)
        {
            Console.WriteLine($"The word '{pair.Key}' occurs {pair.Value} time(s)");
        }
    }
    
    /// <summary>
    /// Displays sorted words.
    /// </summary>
    /// <param name="sortedWords">The array of sorted words.</param>
    static void DisplaySortedWords(string[] sortedWords)
    {
        foreach (var word in sortedWords)
        {
            Console.WriteLine(word);
        }
    }

    /// <summary>
    /// Displays sorted word count.
    /// </summary>
    /// <param name="sortedWordCount">The array of key-value pairs representing sorted word count.</param>
    static void DisplaySortedWordCount(KeyValuePair<string, int>[] sortedWordCount)
    {
        foreach (var pair in sortedWordCount)
        {
            Console.WriteLine($"The word '{pair.Key}' occurs {pair.Value} time(s)");
        }
    }
    
    /// <summary>
    /// Measures and displays the sorting time for the specified array with a specified number of threads.
    /// </summary>
    /// <param name="arrayToSort">The array to be sorted.</param>
    /// <param name="numThreads">The number of parallel threads for sorting.</param>
    private static void MeasureAndDisplaySortingTime(int[] arrayToSort, int numThreads)
    {
        int[] arrayToSortCopy = arrayToSort.ToArray(); // Create a copy for fair comparison

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        ParallelArrayProcessor.ParallelSort(arrayToSortCopy, numThreads);
        stopwatch.Stop();

        Console.WriteLine($"Sorting time with {numThreads} threads: {stopwatch.ElapsedMilliseconds} ms");
    }
}