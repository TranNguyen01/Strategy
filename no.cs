using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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
            var outputFilePath = Path.Combine(this.outputDirectory, $"{this.outputFileName}.json");
            string json = JsonSerializer.Serialize(userProfile);
            File.WriteAllText(outputFilePath, json);
        }

        public void ExportAsBinary(Profile userProfile)
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
}