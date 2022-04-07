using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StrategyPatternDemo.AntiPattern
{
    public class ProfileExporter
    {
        private readonly string outputDirectory;
        private readonly string outputFileName;

        public ProfileExporter(string outputDirectory, string outputFileName)
        {
            this.outputDirectory = outputDirectory;
            this.outputFileName = outputFileName;
        }

        public void ExportAsXml(Profile userProfile)
        {
            var outputFilePath = Path.Combine(this.outputDirectory, $"{this.outputFileName}.xml");

            using (var writer = XmlWriter.Create(outputFilePath))
            {
                var serializer = new XmlSerializer(typeof(Profile));
                serializer.Serialize(writer, userProfile);
            }
        }

        public void ExportAsJson(Profile userProfile)
        {
            // Does the same thing as ExportAsXml, except with JSON output
        }

        public void ExportAsBinary(Profile userProfile)
        {
            // Does the same thing as ExportAsXml, except with binary output
        }
    }
}