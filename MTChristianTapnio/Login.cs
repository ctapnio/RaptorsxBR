/* PROG32356 - Midterm - Winter 2020
 * Created By: Christian Tapnio
 * ID: 991359879
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace MTChristianTapnio
{
    class Login
    {
        private int _id;
        private string _username;
        private string _password;
        
        public Login(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
       

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
       
    }
}
