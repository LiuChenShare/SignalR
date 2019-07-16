using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalR_ConsoleApp_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HubClient hubClient = new HubClient();
            hubClient.XXX();
            hubClient.connectButton();
            hubClient.sendButton("TEST", "这是测试消息");
            Console.WriteLine("按Enter键结束");
            while (true)
            {
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        
    }
    
}
