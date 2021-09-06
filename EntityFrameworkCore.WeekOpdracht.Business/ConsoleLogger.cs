using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class ConsoleLogger : ILogger
    {
        public void write(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        public void write(Exception ex)
        {
            Console.WriteLine($"{DateTime.Now}: {ex.Message}");
        }
    }
}
