# Word Count Analyzer

This program analyzes the frequency of words in a given text by counting the occurrences of each word and storing the 
results in a dictionary.

## Overview

The `WordCountAnalyzer` class provides methods to count the occurrences of each word in a provided text string. It 
includes the following methods:

### `CountWords(string text)`

- **Description**: Counts the occurrences of each word in the given text and returns a dictionary containing each 
unique word and its count in the text.
- **Parameters**:
    - `text`: The input text to be analyzed.

### `GetWordsFromText(string text)`

- **Description**: Splits the text into an array of words using specific delimiters.
- **Parameters**:
    - `text`: The input text to extract words from.

### `SanitizeWord(string word)`

- **Description**: Sanitizes the word by converting it to lowercase.
- **Parameters**:
    - `word`: The word to sanitize.

### `UpdateWordCount(Dictionary<string, int> wordCount, string word)`

- **Description**: Updates the count of a word in the word count dictionary.
- **Parameters**:
    - `wordCount`: The dictionary containing word counts.
    - `word`: The word to update the count for.

## How to Use

1. Create an instance of the `WordCountAnalyzer` class.
2. Call the `CountWords(text)` method with the text you want to analyze.
3. Receive a dictionary containing the word count results.

## Example Usage

```csharp
string text = "Your text goes here...";
WordCountAnalyzer analyzer = new WordCountAnalyzer();
Dictionary<string, int> wordCount = analyzer.CountWords(text);

// Display the word count results
foreach (var pair in wordCount)
{
    Console.WriteLine($"The word '{pair.Key}' occurs {pair.Value} time(s)");
}