using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment16.Singleton
{
    class DataSingleton
    {
        static readonly Lazy<DataSingleton> _singleton = new Lazy<DataSingleton>(() => new DataSingleton(), true);

        List<User> userList;
        
        private DataSingleton() 
        {
            userList = new List<User>();
        }

        public static DataSingleton GetInstance()
        {
            return _singleton.Value;
        }

        public void AddUser(User usr)
        {
            userList.Add(usr);
        }
        public void RemoveUser(User usr)
        {
            userList.Remove(usr);
        }

        public User GetUser(int id)
        {
            return userList.Find(User => User.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(userList);
        }



    }
}
