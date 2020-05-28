using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{

    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            Console.WriteLine("Запуск потоков");
            var writer = fileService.WriteFile();
            var reader = fileService.ReadFile();
            Console.WriteLine("Ожидание завершения потоков");
            Task.WaitAll(writer, reader);
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
