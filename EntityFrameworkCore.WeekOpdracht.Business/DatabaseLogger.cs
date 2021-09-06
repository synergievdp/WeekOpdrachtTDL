using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class DatabaseLogger : ILogger
    {
        private readonly DataContext context;

        public DatabaseLogger()
        {
            this.context = new DataContext();
        }

        public void write(string message)
        {
            context.Logs.Add(new Log() { DateTime = DateTime.Now, Message = message });

            context.SaveChanges();
        }

        public void write(Exception ex)
        {
            context.Logs.Add(new Log() { DateTime = DateTime.Now, Message = ex.Message });

            context.SaveChanges();
        }
    }
}
