using StackExchange.Redis;
using System;

namespace Oraculo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("40.77.24.62");
            var db = connection.GetDatabase();
            var sub = connection.GetSubscriber();
            
            sub.Subscribe("Perguntas", (ch, msg) =>
            {
                Console.WriteLine(msg.ToString());
            });
            Console.ReadLine();
        }
    }
}
