using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        //Initialize Instance Variables
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _Toolsettings;
        //Constructor
        public UserRL(FundooContext fundooContext, IConfiguration _Toolsettings)
        {
            this.fundooContext = fundooContext;
            this._Toolsettings = _Toolsettings;

        }
        public UserEntity GetEmail(string Email)
        {
            var result = fundooContext.User.FirstOrDefault(e => e.Email == Email);

            return result;
        }


        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = User.FirstName;
                userEntity.LastName = User.LastName;
                userEntity.Email = User.Email;
                // userEntity.Password = User.Password;
                // userentity.Password = EncryptPassword(User.Password);
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
        public string Login(UserLogin userLogin)
        {
            try
            {
                // if Email and password is empty return null. 
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
                //string token = GenerateSecurityToken(user.Email, user.Id);
                //return token;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private string GenerateSecurityToken(string Email, long Id)
        {
            //header of jwt token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Toolsettings["Jwt:secretkey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //payload of jwt token
            var claims = new[] {
                new Claim(ClaimTypes.Email,Email),
                new Claim("Id",Id.ToString())
            };
            //signature of jwt token
            var token = new JwtSecurityToken(_Toolsettings["Jwt:Issuer"],
              _Toolsettings["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public string ForgetPassword(String email)
        {
            //Checking email exit or not
            var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                //for token generating
                var token = GenerateSecurityToken(user.Email, user.Id);
                //Passing token to msmq 
                new MsmqModel().Sender(token);
                return token;
            }
            else
            {
                return null;
            }
        }
        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {
                //checking new pwd matches with confirm pwd
                if (password.Equals(confirmpassword))
                {
                    var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = confirmpassword;
                    //change old pwd to new pwd
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
