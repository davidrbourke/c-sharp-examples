using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Examples
{
    public class Concurrency
    {
        private byte[] _fileBytes;

        public Concurrency()
        {
            SetFile();
        }

        private void SetFile()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.AppendLine("Sample text 1234567890!\"£$\"%^&*()_+");
            }
            UTF8Encoding encoding = new UTF8Encoding(true);
            _fileBytes = encoding.GetBytes(sb.ToString());
        }

        public long GetTimeOfWritingLargeFiles()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream fileStream = File.Create($"{Directory.GetCurrentDirectory()}\\output1.txt"))
            {
                fileStream.Write(_fileBytes, 0, _fileBytes.Length);
            }
            using (FileStream fileStream = File.Create($"{Directory.GetCurrentDirectory()}\\output2.txt"))
            {
                fileStream.Write(_fileBytes, 0, _fileBytes.Length);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public async Task<long> GetTimeOfLongRunningMethodAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            await LongRunningMethod();
            await LongRunningMethod();
            
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public async Task<long> GetTimeOfLongRunningMethodWithWhenAllAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task>
            {
                LongRunningMethod(),
                LongRunningMethod()
            };

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public async Task LongRunningMethod()
        {
            await Task.Run(() => Thread.Sleep(2000));
        }
    }
}
