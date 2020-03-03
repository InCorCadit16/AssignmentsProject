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
            var ctx = new Context();

            var baseUserQuery = new Query(ctx)
            {
                AccessLevel = AccessLevel.Outer,
                Address = 312
            };

            var data = baseUserQuery.Execute();
        }
    }

    public class Query
    {
        public const int OuterDataStart = 500;
        public const int AdminDataStart = 1200;
        private Context _context;
        
        public int Address { get; set; }

        public AccessLevel AccessLevel { get; set; }

        public Query(Context context)
        {
            _context = context;
        }

        public Result Execute()
        {
            if (Address <= 0)
                return new Result("Wrong Address format");
            if (AccessLevel < 0)
                return new Result("Wrong Access Level format");
            if ((Address >= OuterDataStart && AccessLevel < AccessLevel.Inner) ||
                    (Address >= AdminDataStart && AccessLevel < AccessLevel.Admin))
                return new Result("Do not have required Access Level");
            else
                return _context.GetResult(Address);
        }
    }

    public class Context
    {
        Dictionary<int, Result> _memory; 

        public Context()
        {
            _memory = new Dictionary<int, Result>();
            for (int i = 1; i <= 2000; i++)
            {
                if (i < Query.OuterDataStart)
                    _memory.Add(i, new Result("Outer Access Data"));
                else if (i < Query.AdminDataStart)
                    _memory.Add(i, new Result("Inner Access Data"));
                else
                    _memory.Add(i, new Result("Only Admin Access Data"));
            }
        }

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

    public enum AccessLevel { Outer, Inner, Admin }
}
