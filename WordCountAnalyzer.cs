namespace mpt_lab_7;

/// <summary>
/// Provides methods to analyze the word count in a given text.
/// </summary>
public class WordCountAnalyzer
{
    /// <summary>
    /// Counts the occurrences of each word in the given text.
    /// </summary>
    /// <param name="text">The input text to analyze.</param>
    /// <returns>A dictionary containing each unique word and its count in the text.</returns>
    public Dictionary<string, int> CountWords(string text)
    { 
        Dictionary<string, int> wordCount = new Dictionary<string, int>(); 
        string[] words = GetWordsFromText(text);

        foreach (string word in words)
        { 
            string cleanedWord = SanitizeWord(word);
            UpdateWordCount(wordCount, cleanedWord);
        }
        return wordCount;
    }

    /// <summary>
    /// Splits the text into an array of words using specific delimiters.
    /// </summary>
    /// <param name="text">The input text to extract words from.</param>
    /// <returns>An array of words extracted from the input text.</returns>
    private string[] GetWordsFromText(string text)
    { 
        return text.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, 
            StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Sanitizes the word by converting it to lowercase.
    /// </summary>
    /// <param name="word">The word to sanitize.</param>
    /// <returns>The sanitized word in lowercase.</returns>
    private string SanitizeWord(string word)
    { 
        return word.ToLower();
    }
    
    /// <summary>
    /// Updates the count of a word in the word count dictionary.
    /// </summary>
    /// <param name="wordCount">The dictionary containing word counts.</param>
    /// <param name="word">The word to update the count for.</param>
    private void UpdateWordCount(Dictionary<string, int> wordCount, string word)
    { 
        if (wordCount.ContainsKey(word))
        { 
            wordCount[word]++;
        }
        else
        { 
            wordCount[word] = 1;
        }
    }

    /// <summary>
    /// Filters words based on a custom condition.
    /// </summary>
    /// <param name="wordCount">The dictionary containing word counts.</param>
    /// <param name="filter">The filter condition.</param>
    /// <returns>A filtered dictionary of word counts.</returns>
    public Dictionary<string, int> FilterWords(Dictionary<string, int> wordCount, FilterDelegate filter)
    { 
        return wordCount.Where(pair => filter(pair)).ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}