using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
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
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
       

        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
           
        }
       
        [Authorize]
        [HttpPost("CreateLabel")]
        public IActionResult AddLabel(string labelName, long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = labelBL.AddLabel(labelName, userId, noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Successfully Label Added", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "Label Not Added" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPost("UpdateLabel")]
        public IActionResult UpdateLabel(string labelName, long LabelId, long userId)
        {
            try
            {
                var result = labelBL.UpdateLabel(labelName, LabelId, userId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Successfully Label Updated", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "label not Updated" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPost("DeleteLabel")]
        public IActionResult DeleteLabel(long LabelId)
        {
            try
            {
                var result = labelBL.DeleteLabel( LabelId);
                if (result)
                    return this.Ok(new { Success = true, message = "Successfully Label Deleted", data = result });
                else
                    return this.BadRequest(new { Success = false, message = "label not Deleted" });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
