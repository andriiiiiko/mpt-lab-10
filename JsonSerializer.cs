namespace mpt_lab_7;

/// <summary>
/// Provides methods for serializing and deserializing WordCountData to and from JSON.
/// </summary>
public class JsonSerializer
{
    /// <summary>
    /// Serializes WordCountData to JSON and saves it to a file.
    /// </summary>
    /// <param name="fileName">The name of the file to save the JSON data to.</param>
    /// <param name="data">The WordCountData to be serialized and saved.</param>
    public void SerializeToJson(string fileName, WordCountData data)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(data);
        File.WriteAllText(fileName, json);
    }

    /// <summary>
    /// Deserializes WordCountData from a JSON file.
    /// </summary>
    /// <param name="fileName">The name of the file containing the JSON data.</param>
    /// <returns>The deserialized WordCountData object.</returns>
    public WordCountData? DeserializeFromJson(string fileName)
    {
        string json = File.ReadAllText(fileName);
        return System.Text.Json.JsonSerializer.Deserialize<WordCountData>(json);
    }
}