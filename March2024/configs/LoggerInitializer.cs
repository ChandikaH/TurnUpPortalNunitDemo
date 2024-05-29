using log4net.Config;

public static class LoggerInitializer
{
    public static void Initialize()
    {
        XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
    }
}
