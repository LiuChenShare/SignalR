using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HubClient hubClient = new HubClient();
            hubClient.connectButton();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    hubClient.SendMessage("大家好，我是" + hubClient.GuidId.ToString());
                }
            });
            Console.WriteLine("按Enter键结束");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
