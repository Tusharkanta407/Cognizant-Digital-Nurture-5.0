using System;

namespace DesignPatterns.Singleton
{
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _instance = 
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        public string AppName { get; private set; }
        public string Version { get; private set; }

        private ConfigurationManager()
        {
            Console.WriteLine("Initializing Configuration Manager...");
            AppName = "DotNet FSE Application";
            Version = "1.0.0";
        }

        public static ConfigurationManager Instance => _instance.Value;

        public void DisplayConfig()
        {
            Console.WriteLine($"App: {AppName}, Version: {Version}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Executing Singleton Pattern ---");

            ConfigurationManager config1 = ConfigurationManager.Instance;
            ConfigurationManager config2 = ConfigurationManager.Instance;

            config1.DisplayConfig();

            if (ReferenceEquals(config1, config2))
            {
                Console.WriteLine("SUCCESS: Both variables contain the exact same instance in memory.");
            }
        }
    }
}