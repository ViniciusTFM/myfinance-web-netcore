using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Models
{
    public class LogModel
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public char Operacao { get; set; }
    }
}
