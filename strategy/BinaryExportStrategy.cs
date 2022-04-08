using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
public class BinaryExportStrategy : IExportStrategy
{

    private readonly string outputDirectory;
    private readonly string outputFileName;
    public BinaryExportStrategy(string outputDirectory, string outputFileName)
    {
        this.outputDirectory = outputDirectory;
        this.outputFileName = outputFileName;
    }

    public void Export(Profile userProfile)
    {
        var outputFilePath = Path.Combine(this.outputDirectory, this.outputFileName);
        using (var stream = File.Open(outputFilePath, FileMode.Create))
        {
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
            {
                writer.Write(userProfile.Age);
                writer.Write(userProfile.Sex);
                writer.Write(userProfile.Location);
            }
        }
    }
}

