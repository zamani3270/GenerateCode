using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Infrastucture
{
    public class ResultItem<T> where T : class
    {
        public T Data { get; set; }

        public bool Successed { get; set; }

        public string Message { get; set; }

    }
}
