using Nhom8_QLTV.src.models;
using System;

namespace Nhom8_QLTV.src.utils
{
    internal class Session
    {
        private static Session instance;
        private static user user = null;

        private Session() { }

        public static Session getInstance()
        {
            if (instance == null) instance = new Session();

            return instance;
        }

        public void setUser(user u)
        {
            user = u;
        }

        public user getUser()
        {
            return user;
        }
    }
}
