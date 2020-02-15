using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment9.Model
{
    class User : IEntity, IComparable
    {
        private Guid _id;
        public string ID { get { return _id.ToString(); } }

        public string Nickname { get; private set; }

        public string Email { get; private set; }

        private string Password { get; set; }

        public int? Age { get; private set; }

        public Role Role { get; private set; }

        public List<Article> Articles { get; } 

        public List<Topic> FavouriteTopics { get; }

        public int Rating
        {
            get
            {
                int rating = 0;
                foreach(var art in Articles)
                {
                    if (art.Rating > 9)
                        rating += 2;
                    else if (art.Rating > 7)
                        rating += 1;
                    else if (art.Rating < 3.5)
                        rating -= 1;
                    else if (art.Rating < 1.5)
                        rating -= 2;
                }
                return rating;
            }
        }

        public User(string Nickname, string Email, string Password)
        {
            _id = Guid.NewGuid();
            this.Nickname = Nickname;
            this.Email = Email;
            this.Password = Password;
        }

        public int CompareTo(object obj)
        {
            return this.Rating.CompareTo(((User)obj).Rating);
        }
    }
}
