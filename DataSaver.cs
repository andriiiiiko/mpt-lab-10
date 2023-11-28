using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace mpt_lab_7;

/// <summary>
/// Provides methods for saving and loading WordCountData using binary serialization.
/// </summary>
public class DataSaver
{
    /// <summary>
    /// Saves WordCountData to a binary file using serialization.
    /// </summary>
    /// <param name="fileName">The name of the file to save the binary data to.</param>
    /// <param name="data">The WordCountData to be serialized and saved.</param>
    public void SaveBinary(string fileName, WordCountData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using FileStream fs = new FileStream(fileName, FileMode.Create);
        formatter.Serialize(fs, data);
    }
    
    /// <summary>
    /// Loads WordCountData from a binary file using deserialization.
    /// </summary>
    /// <param name="fileName">The name of the file containing the binary data.</param>
    /// <returns>The deserialized WordCountData object.</returns>
    public WordCountData LoadBinary(string fileName)
    {
        WordCountData data;
        BinaryFormatter formatter = new BinaryFormatter();
        using FileStream fs = new FileStream(fileName, FileMode.Open);
        data = (WordCountData)formatter.Deserialize(fs);

        return data;
    }
}