using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment16.Singleton
{
    public class UserValidator
    {
        public static List<User> Validate(int minAge = 0, int maxAge = int.MaxValue, Status minStatus = Status.Beginner, string orderBy = "Id")
        {
            List<int> list = new List<int>();

            var matching = from usr in DataSingleton.GetInstance().GetAllUsers()
                           where usr.Age >= minAge && usr.Age < maxAge && usr.Status >= minStatus
                           orderby usr.GetType().GetProperty(orderBy).GetValue(usr)
                        select usr;
            return matching.ToList();
        }
    }
}
