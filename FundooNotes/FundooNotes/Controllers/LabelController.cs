using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL labelBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;


        public LabelController(ILabelBL labelBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.labelBL = labelBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
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
        [Authorize]
        [HttpGet("{ID}/Get")]
        public IEnumerable<LabelEntity> labelsbyUserid()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = labelBL.GetAllLabelbyUserid(userId);
                if (result != null)
                    return result;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("redis")]
        public async Task<IActionResult> GetAllLabelUsingRedisCache()
        {
            var cacheKey = "LabelList";
            string serializedNotesList;
            var LabelList = new List<LabelEntity>();
            var redisLabelList = await distributedCache.GetAsync(cacheKey);
            if (redisLabelList != null)
            {
                serializedNotesList = Encoding.UTF8.GetString(redisLabelList);
                LabelList = JsonConvert.DeserializeObject<List<LabelEntity>>(serializedNotesList);
            }
            else
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                LabelList = (List<LabelEntity>) this.labelBL.GetAllLabelbyUserid(userId);
                serializedNotesList = JsonConvert.SerializeObject(LabelList);
                redisLabelList = Encoding.UTF8.GetBytes(serializedNotesList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisLabelList, options);
            }
            return Ok(LabelList);
        }

    }
}
