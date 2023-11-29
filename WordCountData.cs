namespace mpt_lab_7;

/// <summary>
/// Represents data containing word counts.
/// </summary>
[Serializable]
public class WordCountData
{
    /// <summary>
    /// Gets or sets the word count dictionary.
    /// </summary>
    public Dictionary<string, int> WordCount { get; set; }
    
    /// <summary>
    /// Gets an array of sorted words.
    /// </summary>
    public string[] SortedWords => WordCount.Keys.OrderBy(key => key).ToArray();
    
    /// <summary>
    /// Gets an array of key-value pairs representing sorted word count.
    /// </summary>
    public KeyValuePair<string, int>[] SortedWordCount => WordCount.OrderBy(pair => pair.Key).ToArray();
}