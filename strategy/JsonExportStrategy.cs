using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonExportStrategy : IExportStrategy
{
    private readonly string outputDirectory;
    private readonly string outputFileName;
    public JsonExportStrategy(string outputDirectory, string outputFileName)
    {
        this.outputDirectory = outputDirectory;
        this.outputFileName = outputFileName;
    }
    public void Export(Profile userProfile)
    {
        var outputFilePath = Path.Combine(this.outputDirectory, $"{this.outputFileName}.json");
        string json = JsonSerializer.Serialize(userProfile);
        File.WriteAllText(outputFilePath, json);
    }
}