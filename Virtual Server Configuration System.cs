using System;
using System.Collections.Generic;

namespace VirtualServerBuilder
{
    
    // Продукт: VirtualServer
   
    class VirtualServer
    {
        public int CPU { get; set; }
        public int Memory { get; set; }
        public string OperatingSystem { get; set; }
        public string Storage { get; set; }
        public string NetworkConfiguration { get; set; }
        public List<string> AdditionalOptions { get; set; }

        public VirtualServer()
        {
            AdditionalOptions = new List<string>();
        }

        public void DisplayConfiguration()
        {
            Console.WriteLine("---- Virtual Server Configuration ----");
            Console.WriteLine($"CPU Cores: {CPU}");
            Console.WriteLine($"Memory: {Memory} GB");
            Console.WriteLine($"Operating System: {OperatingSystem}");
            Console.WriteLine($"Storage: {Storage}");
            Console.WriteLine($"Network: {NetworkConfiguration}");
            Console.WriteLine("Additional Options:");

            if (AdditionalOptions.Count == 0)
                Console.WriteLine("  None");
            else
                foreach (var option in AdditionalOptions)
                    Console.WriteLine($"  - {option}");

            Console.WriteLine("--------------------------------------\n");
        }
    }

    // Интерфейс конструктора
  
    interface IServerBuilder
    {
        IServerBuilder SetCPU(int cores);
        IServerBuilder SetMemory(int size);
        IServerBuilder SetOperatingSystem(string os);
        IServerBuilder SetStorage(int size, string type);
        IServerBuilder SetNetworkConfiguration(string config);
        IServerBuilder AddOption(string option);
        VirtualServer Build();
    }


    // Строитель из бетона
 
    class Server : IServerBuilder
    {
        private VirtualServer server = new VirtualServer();

        public IServerBuilder SetCPU(int cores)
        {
            server.CPU = cores;
            return this;
        }

        public IServerBuilder SetMemory(int size)
        {
            server.Memory = size;
            return this;
        }

        public IServerBuilder SetOperatingSystem(string os)
        {
            server.OperatingSystem = os;
            return this;
        }

        public IServerBuilder SetStorage(int size, string type)
        {
            server.Storage = $"{size} GB {type}";
            return this;
        }

        public IServerBuilder SetNetworkConfiguration(string config)
        {
            server.NetworkConfiguration = config;
            return this;
        }

        public IServerBuilder AddOption(string option)
        {
            server.AdditionalOptions.Add(option);
            return this;
        }

        public VirtualServer Build()
        {
            return server;
        }
    }

   
    // Директор Предварительно настроенные серверы)
 
    class ServerDirector
    {
        public VirtualServer CreateDevelopmentServer()
        {
            return new Server()
                .SetCPU(2)
                .SetMemory(4)
                .SetOperatingSystem("Linux")
                .SetStorage(50, "SSD")
                .SetNetworkConfiguration("Private Network")
                .Build();
        }

        public VirtualServer CreateTestingServer()
        {
            return new Server()
                .SetCPU(4)
                .SetMemory(8)
                .SetOperatingSystem("Linux")
                .SetStorage(100, "SSD")
                .SetNetworkConfiguration("Firewall Enabled")
                .AddOption("Backup")
                .Build();
        }

        public VirtualServer CreateProductionServer()
        {
            return new Server()
                .SetCPU(8)
                .SetMemory(32)
                .SetOperatingSystem("Windows Server")
                .SetStorage(500, "SSD")
                .SetNetworkConfiguration("High Security Firewall")
                .AddOption("Monitoring")
                .AddOption("Backup")
                .AddOption("Auto Updates")
                .Build();
        }
    }

    
    // Основная программа

    class Program
    {
        static void Main(string[] args)
        {
            // Пользовательский сервер
            VirtualServer customServer = new Server()
                .SetCPU(6)
                .SetMemory(16)
                .SetOperatingSystem("Linux")
                .SetStorage(200, "SSD")
                .SetNetworkConfiguration("VPN + Firewall")
                .AddOption("Monitoring")
                .Build();

            customServer.DisplayConfiguration();

            // Предварительно настроенные серверы

            ServerDirector director = new ServerDirector();

            director.CreateDevelopmentServer().DisplayConfiguration();
            director.CreateTestingServer().DisplayConfiguration();
            director.CreateProductionServer().DisplayConfiguration();

            Console.ReadLine();
        }
    }
}
