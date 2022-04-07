    public class ProfileExporter
    {
        private readonly IExportStrategy exportStrategy;

        public ProfileExporter(IExportStrategy exportStrategy)
        {
            this.exportStrategy = exportStrategy;
        }

        public void Export(Profile userProfile)
        {
            this.exportStrategy.Export(userProfile);
        }
    }