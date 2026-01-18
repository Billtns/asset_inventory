using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssetInventory.Api.Data;
using AssetInventory.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace AssetInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssetsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await (from asset in _context.Assets
                                    join category in _context.Categories on asset.CategoryId equals category.CategoryId
                                    join status in _context.Status on asset.StatusId equals status.StatusId
                                    where asset.IsDelete == false
                                    select new AssetsModelDTO
                                    {
                                        AssetId = asset.AssetId,
                                        AssetName = asset.AssetName,
                                        AssetCode = asset.AssetCode,
                                        Brand = asset.Brand,
                                        Model = asset.Model,
                                        SerialNumber = asset.SerialNumber,

                                        CategoryId = category.CategoryId,
                                        CategoryName = category.CategoryName,

                                        StatusId = status.StatusId,
                                        StatusName = status.StatusName
                                    }).ToListAsync();
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

        [HttpGet, Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await (from asset in _context.Assets
                                    join category in _context.Categories on asset.CategoryId equals category.CategoryId
                                    join status in _context.Status on asset.StatusId equals status.StatusId
                                    where asset.IsDelete == false && asset.AssetId == id
                                    select new AssetsModelDTO
                                    {
                                        AssetId = asset.AssetId,
                                        AssetName = asset.AssetName,
                                        AssetCode = asset.AssetCode,
                                        Brand = asset.Brand,
                                        Model = asset.Model,
                                        SerialNumber = asset.SerialNumber,

                                        CategoryId = category.CategoryId,
                                        CategoryName = category.CategoryName,

                                        StatusId = status.StatusId,
                                        StatusName = status.StatusName
                                    }).FirstOrDefaultAsync();
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


        [HttpPost, Route("Create")]
        public async Task<ResponseModel> Create(AssetsModelDTO input)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var entity = new AssetsModel
                {
                    AssetName = input.AssetName,
                    AssetCode = input.AssetCode,
                    Brand = input.Brand,
                    Model = input.Model,
                    SerialNumber = input.SerialNumber,
                    CategoryId = input.CategoryId,
                    StatusId = input.StatusId,
                    CreatedAt = DateTime.Now
                };
                _context.Assets.Add(entity);
                await _context.SaveChangesAsync();

                response.status = true;
                response.message = "Create Asset Success";
                return response;
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Error" + ex.ToString();
                return response;
            }
        }

        [HttpPut, Route("Update")]
        public async Task<ResponseModel> Update(AssetsModelDTO input)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var data = _context.Assets.Where(a => a.IsDelete == false && a.AssetId == input.AssetId).FirstOrDefault();
                if (data != null)
                {

                    data.AssetName = input.AssetName;
                    data.AssetCode = input.AssetCode;
                    data.Brand = input.Brand;
                    data.Model = input.Model;
                    data.SerialNumber = input.SerialNumber;
                    data.CategoryId = input.CategoryId;
                    data.StatusId = input.StatusId;
                    data.UpdatedAt = DateTime.Now;

                    _context.Assets.Update(data);
                    await _context.SaveChangesAsync();

                    response.status = true;
                    response.message = "Update Asset Success";
                    return response;
                }
                else
                {
                    response.status = false;
                    response.message = "Asset Not Found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Error" + ex.ToString();
                return response;
            }
        }


        [HttpDelete, Route("Delete/{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var data = _context.Assets.Where(a => a.CategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    data.IsDelete = true;
                    data.UpdatedAt = DateTime.Now;

                    _context.Assets.Update(data);
                    await _context.SaveChangesAsync();

                    response.status = true;
                    response.message = "Delete Asset Success";
                    return response;
                }
                else
                {
                    response.status = false;
                    response.message = "Asset Not Found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Error" + ex.ToString();
                return response;
            }
        }



    }
}
