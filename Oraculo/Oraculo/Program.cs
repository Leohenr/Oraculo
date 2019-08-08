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
            while (true)
            {
                sub.Subscribe("Perguntas", (ch, msg) =>
                {
                    Console.WriteLine(msg.ToString());
                    string resposta = Console.ReadLine();

                    var perguntaNumero = msg.ToString().Substring(0, msg.ToString().IndexOf(":"));
                    db.HashSet(perguntaNumero, new HashEntry[] { new HashEntry("EstouTestandoEin", resposta) });
                });
            }
        }
    }
}
