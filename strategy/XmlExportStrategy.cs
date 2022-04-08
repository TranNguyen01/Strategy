using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class XmlExportStrategy : IExportStrategy
{
    private readonly string outputDirectory;
    private readonly string outputFileName;
    public XmlExportStrategy(string outputDirectory, string outputFileName)
    {
        this.outputDirectory = outputDirectory;
        this.outputFileName = outputFileName;
    }

    public void Export(Profile userProfile)
    {
        var outputFilePath = Path.Combine(this.outputDirectory, $"{this.outputFileName}.xml");

        using (var writer = XmlWriter.Create(outputFilePath))
        {
            var serializer = new XmlSerializer(typeof(Profile));
            serializer.Serialize(writer, userProfile);
        }
    }
}

