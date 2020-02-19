using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Model
{
    class Review : Entity
    {
        public Article SourceArticle { get; }

        public string Comment { get; private set; }

        public uint? Rating { get; private set; }
        
        public DateTime? PublicationTime { get; }
    }
}
