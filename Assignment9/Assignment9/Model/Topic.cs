using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Model
{
    class Topic : IEntity
    {
        private Guid _id;
        public string ID { get { return _id.ToString(); } }

        public string Name { get; }
    }
}
