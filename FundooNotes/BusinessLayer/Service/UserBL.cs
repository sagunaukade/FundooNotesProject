using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;

namespace Businesslayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userRL.Login(userLogin);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserEntity Registration(UserRegistration user)
        {
            try
            {
                return userRL.Registration(user);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {

                return userRL.ResetPassword(email, password, confirmpassword);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}