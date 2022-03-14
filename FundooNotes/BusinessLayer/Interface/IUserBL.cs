using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserEntity Registration(UserRegistration User);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string email);
        public bool ResetPassword(string email, string password, string confirmpassword);
    }
}
