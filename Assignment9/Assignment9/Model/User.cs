using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment9.Model
{
    class User : Entity, IComparable<User>
    {

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
            this.Nickname = Nickname;
            this.Email = Email;
            this.Password = Password;
            Role = Role.User;
            Articles = new List<Article>();
            FavouriteTopics = new List<Topic>();
        }

        public int CompareTo(User usr)
        {
            return this.Rating.CompareTo(usr.Rating);
        }
    }
}
