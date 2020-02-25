using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment16.Singleton
{
    class User
    {
        public int Id { get; set; }

        public uint Age { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; } = Status.Beginner;

        public string privateKey { get; set; }
    }
}
