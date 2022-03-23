namespace Businesslayer.Service
{
    using System;
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
    /// <summary>
    /// User Class
    /// </summary>
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        /// <summary>
        /// Constructor of UserBL
        /// </summary>
        /// <param name="userRL">UserRL</param>
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        /// <summary>
        /// User Login method
        /// </summary>
        /// <param name="userLogin">user login</param>
        /// <returns>User login</returns>
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
        /// <summary>
        /// user registration
        /// </summary>
        /// <param name="user">user name</param>
        /// <returns>user registration</returns>
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
        /// <summary>
        /// forget password
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// forget password
        /// </returns>
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
        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="email"> email</param>
        /// <param name="password">password</param>
        /// <param name="confirmpassword">confirm password</param>
        /// <returns>reset password</returns>
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