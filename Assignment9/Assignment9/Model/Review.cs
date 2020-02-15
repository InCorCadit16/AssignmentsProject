using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Model
{
    class Review : IEntity
    {
        private Guid _id;
        public string ID { get { return _id.ToString(); } }

        public Article SourceArticle { get; }

        public string Comment { get; private set; }

        public uint? Rating { get; private set; }
        
        public DateTime? PublicationTime { get; }
    }
}
