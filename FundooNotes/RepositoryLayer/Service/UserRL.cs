namespace RepositoryLayer.Service
{
    using System;
    using System.Text;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using CommonLayer.Model;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.Context;

    /// <summary>
    /// user RL class
    /// </summary>
    public class UserRL : IUserRL
    {
        /// <summary>
        /// Fundoo Context
        /// </summary>
        private readonly FundooContext fundooContext;
        /// <summary>
        /// toolsettings
        /// </summary>
        private readonly IConfiguration Toolsettings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fundooContext">the fundoo context</param>
        /// <param name="_Toolsettings">the toolsettings</param>
        
        public UserRL(FundooContext fundooContext, IConfiguration Toolsettings)
        {
            this.fundooContext = fundooContext;
            this.Toolsettings = Toolsettings;
        }

        /// <summary>
        /// Method for get gmail
        /// </summary>
        /// <param name="Email">email</param>
        /// <returns>email</returns>
        public UserEntity GetEmail(string Email)
        {
            var result = fundooContext.User.FirstOrDefault(e => e.Email == Email);

            return result;
        }

        /// <summary>
        /// method for user registration
        /// </summary>
        /// <param name="User">user registration</param>
        /// <returns>user details</returns>
        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = User.FirstName;
                userEntity.LastName = User.LastName;
                userEntity.Email = User.Email;
                userEntity.Password = EncryptPassword(User.Password);
                fundooContext.Add(userEntity);
                int result = fundooContext.SaveChanges();
                if (result > 0)
                    return userEntity;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// method for encrypt password
        /// </summary>
        /// <param name="Password"> the user password</param>
        /// <returns>encrypt password</returns>
       public string EncryptPassword(string Password)
        {
            try
            {
                byte[] encode = new byte[Password.Length];
                encode = Encoding.UTF8.GetBytes(Password);
                string encryptPass = Convert.ToBase64String(encode);
                return encryptPass;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// method for user login 
        /// </summary>
        /// <param name="userLogin"> the user login</param>
        /// <returns>user login</returns>
        public string Login(UserLogin userLogin)
        {
            try
            {
                if (string.IsNullOrEmpty(userLogin.Email) || string.IsNullOrEmpty(userLogin.Password))
                {
                    return null;
                }

                var user = fundooContext.User.Where(x => x.Email == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();
                string dcryptPass = this.EncryptPassword(userLogin.Password);

                if (user != null)
                {
                    string token = GenerateSecurityToken(user.Email, user.Id);
                    return token;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// method for JWT token for login authentication with email and id
        /// </summary>
        /// <param name="Email"> the email</param>
        /// <param name="Id">the id</param>
        /// <returns>Token</returns>
        public string GenerateSecurityToken(string Email, long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Toolsettings["Jwt:secretkey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,Email),
                new Claim("Id",Id.ToString())
            };
            var token = new JwtSecurityToken(Toolsettings["Jwt:Issuer"],
              Toolsettings["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// method for user forget password
        /// </summary>
        /// <param name="email">the email</param>
        /// <returns>Password change</returns>
        public string ForgetPassword(string email)
        {
            var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                var token = GenerateSecurityToken(user.Email, user.Id);
                new MsmqModel().Sender(token);
                return token;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// method for reset password using token
        /// </summary>
        /// <param name="email">the email</param>
        /// <param name="password">the password</param>
        /// <param name="confirmpassword">the confirm password</param>
        /// <returns>reset password</returns>
        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {
                if (password.Equals(confirmpassword))
                {
                    var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = confirmpassword;
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
