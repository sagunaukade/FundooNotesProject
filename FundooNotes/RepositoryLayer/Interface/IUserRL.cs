namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;
   
    public interface IUserRL
   {
        /// <summary>
        /// user registration
        /// </summary>
        /// <param name="User">the user</param>
        /// <returns>registration</returns>
        public UserEntity Registration(UserRegistration User);

        /// <summary>
        /// user login
        /// </summary>
        /// <param name="userLogin">the user login</param>
        /// <return> user login></returns>
        public string Login(UserLogin userLogin);

        /// <summary>
        /// forget password
        /// </summary>
        /// <param name="email">the email</param>
        /// <returns>forget password</returns>
        public string ForgetPassword(string email);
        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <param name="confirmpassword">confirm password</param>
        /// <returns> Reset password</returns>
        public bool ResetPassword(string email, string password, string confirmpassword);
    }
}
