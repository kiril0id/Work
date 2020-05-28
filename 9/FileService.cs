using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public class FileService
    {
        
        object obj = new object();
        string path = @"..\file.txt"; 
        public Task WriteFile()
        {
            return Task.Run(() =>
            {
                lock (obj)
                { 
                    var rnd = new Random();
                    Console.WriteLine("Start recording");
                    using (var writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                    {
                        for (var i = 1; i < 10000000; i++)
                        {
                            writer.Write(rnd.Next(Int32.MaxValue));
                        }
                    }
                    Console.WriteLine("Write has finished");
                }
            });
        }
        
        public Task ReadFile()
        {
            return Task.Run(() =>
            {
                lock (obj) 
                {
                    Console.WriteLine("Start");
                    using (var reader = new BinaryReader(File.OpenRead(path)))
                    {
                        try
                        {
                            while (true)
                            {
                                reader.ReadInt32(); 
                            }
                        }
                        catch (EndOfStreamException)
                        {
                            Console.WriteLine("Read has finished");
                        }
                    }
                }
            });
        }
    }
}
   

