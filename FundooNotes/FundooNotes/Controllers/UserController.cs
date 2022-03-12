using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost ("Register")]
        public IActionResult Registration(UserRegistration user)
        {
            try
            {
                var result = userBL.Registration(user);
                if (result != null)
                    return this.Ok(new { success = true, message = "Registration successfull", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Registration unsuccessfull" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var result = userBL.Login(userLogin);
                if(result!=null)
                    return this.Ok(new { success = true, message = "Login successfull", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Login unsuccessfull" });

            }
            catch (Exception)
            {

                
                throw;
            }
        }
        //Forget Password
        [HttpPost("ForgetPassword")]
        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var user = userBL.ForgetPassword(email);
                if (user != null)
                    return this.Ok(new { Success = true, message = " Email sent Successfully ", data = user });
                else
                    return this.BadRequest(new { Success = false, message = "Email not sent" });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
