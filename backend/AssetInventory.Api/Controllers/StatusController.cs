using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssetInventory.Api.Data;
using AssetInventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Get")]
        public ActionResult Get()
        {
            try
            {
                var result = _context.Status.Where(s => s.IsDelete == false).Select(s => new StatusModelDTO
                {
                    StatusId = s.StatusId,
                    StatusName = s.StatusName,
                }).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }



    }
}
