﻿using System;
using System.Collections.Generic;

namespace Assignment9.Model
{
    class Article : IEntity, IComparable
    {
        private Guid _id;
        public string ID { get { return _id.ToString(); } }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public User Author { get; private set; }

        public bool IsApproved { get; private set; }

        public DateTime? PublicationTime { get; private set; }

        public DateTime? SendOnApprovmentTime { get; private set; }

        public List<string> Tags { get; }

        public Dictionary<User, Review> Reviews { get; }

        public double Rating
        {
            get
            {
                double avg = 0;
                foreach (var item in Reviews.Values)
                {
                    avg += (double) item.Rating;
                }
                return avg / Reviews.Count;
            }
        }

        public int CompareTo(object obj)
        {
            return this.Rating.CompareTo(((Article)obj).Rating);
        }
    }
}
