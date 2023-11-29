namespace mpt_lab_7;

/// <summary>
/// Represents a delegate used for filtering word count entries.
/// </summary>
/// <param name="wordCountEntry">The key-value pair representing a word and its count.</param>
/// <returns>True if the entry passes the filter; otherwise, false.</returns>
public delegate bool FilterDelegate(KeyValuePair<string, int> wordCountEntry);