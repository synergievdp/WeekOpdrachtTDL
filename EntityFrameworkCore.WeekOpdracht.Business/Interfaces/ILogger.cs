using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.WeekOpdracht.Business.Interfaces
{
    public interface ILogger
    {
        void write(string message);
        void write(Exception ex);
    }
}
