using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Data
{
    public class RequestLog
    {
        public int Id { get; set; }
        public bool IsURLRequested { get; set; }
        public string RequestContent { get; set; }
        public int RequestCount { get; set; }
    }
}
