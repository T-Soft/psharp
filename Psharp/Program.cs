using System;
using System.Threading;
using System.Threading.Tasks;

namespace Psharp
{
    class Program
    {
        static async Task Main(string[] args)
		{
			string[] words = new string[] {"Seal with it!", "Belek!"};

			var rnd = new Random();

			while (true)
			{
				Console.WriteLine(words[rnd.Next(0, 2)]);
				await Task.Delay(1000);
			}
        }
    }
}
