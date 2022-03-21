using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
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
    public class CollaboratController : ControllerBase
    {
        private readonly ICollaboratBL collabratorBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;

        public CollaboratController(ICollaboratBL collabratorBL , IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.collabratorBL = collabratorBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        [Authorize]
        [HttpPost("AddCollaborator")]
        public IActionResult AddCollab(string email, long noteId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = collabratorBL.AddCollab(email, userId, noteId);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = " Successfully Collaborator Added", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Collaborator Not Added" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("RemoveCollaborator")]
        public IActionResult DeleteCollab(long collabId)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = collabratorBL.DeleteCollab(userId, collabId);
                if (result)
                {
                    return this.Ok(new { Success = true, message = "Successfully Collaborator Remove", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Collaborator Not Removed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetAllCollaborator")]
        public IEnumerable<CollaboratEntity> GetAllCollab()
        {
            try
            {
                var result = collabratorBL.GetAllCollab();
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
        public async Task<IActionResult> GetAllCollabUsingRedisCache()
        {
            var cacheKey = "collabList";
            string serializedcollabList;
            var collabList = new List<CollaboratEntity>();
            var redisCollabList = await distributedCache.GetAsync(cacheKey);
            if (redisCollabList != null)
            {
                serializedcollabList = Encoding.UTF8.GetString(redisCollabList);
                collabList = JsonConvert.DeserializeObject<List<CollaboratEntity>>(serializedcollabList);
            }
            else
            {
                collabList = (List<CollaboratEntity>)collabratorBL.GetAllCollab();
                serializedcollabList = JsonConvert.SerializeObject(collabList);
                redisCollabList = Encoding.UTF8.GetBytes(serializedcollabList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(15))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisCollabList, options);
            }
            return Ok(collabList);
        }
    }
}

   