using System.IO;

var myProfile = new Profile
{
    Age = 21,
    Sex = "Male",
    Location = "UIT"
};
var strategy = new JsonExportStrategy(Directory.GetCurrentDirectory(), "myProfile");
var exporter = new ProfileExporter(strategy);
exporter.Export(myProfile);

