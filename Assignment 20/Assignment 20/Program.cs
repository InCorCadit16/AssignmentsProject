using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_20
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Query
    {
        private Context _context;
        
        public int Address { get; set; }

        public Query(Context context)
        {
            _context = context;
        }

        public Result Execute()
        {
            if (Address <= 0)
                return new Result("Wrong Address format");
            else
                return _context.GetResult(Address);
        }
    }

    public class Context
    {
        Dictionary<int, Result> _memory; 

        public virtual Result GetResult(int Address)
        {
            if (_memory.TryGetValue(Address, out Result result))
            {
                return result;
            } else
            {
                return new Result($"No Result for this Address: {Address}");
            }
        }
    }

    public class Result
    {
        public Result(string value)
        {
            Value = value;
        }

        public Result() { }

        public string Value { get; set; }
    }
}
