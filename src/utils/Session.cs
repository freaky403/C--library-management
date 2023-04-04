using System;

namespace Nhom8_QLTV.src.utils
{
    internal class Session
    {
        private static Session instance;
        private String username;
        private String email;
        private String password;

        private Session() { }

        public static Session getInstance()
        {
            if (instance == null) instance = new Session();

            return instance;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getUsername()
        {
            return this.username;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getEmail()
        {
            return this.email;
        }
    }
}
