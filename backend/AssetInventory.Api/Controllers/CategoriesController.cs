using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssetInventory.Api.Data;
using AssetInventory.Api.Models;

namespace AssetInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Get")]
        public ActionResult Get()
        {
            try
            {
                var result = _context.Categories.Where(c => c.IsDelete == false).Select(c => new CategoriesModelDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
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


        [HttpGet, Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var result = _context.Categories.Where(c => c.IsDelete == false && c.CategoryId == id).Select(c => new CategoriesModelDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).FirstOrDefault();
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
        public async Task<ResponseModel> Create(CategoriesModelDTO input)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var entity = new CategoriesModel
                {
                    CategoryName = input.CategoryName,
                    CreatedAt = DateTime.Now
                };

                _context.Categories.Add(entity);
                await _context.SaveChangesAsync();

                response.status = true;
                response.message = "Create Category Success";
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
        public async Task<ResponseModel> Update(CategoriesModelDTO input)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var data = _context.Categories.Where(c => c.IsDelete == false && c.CategoryId == input.CategoryId).FirstOrDefault();
                if (data != null)
                {

                    data.CategoryName = input.CategoryName;
                    data.UpdatedAt = DateTime.Now;

                    _context.Categories.Update(data);
                    await _context.SaveChangesAsync();

                    response.status = true;
                    response.message = "Update Category Success";
                    return response;
                }
                else
                {
                    response.status = false;
                    response.message = "Category Not Found";
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
                var data = _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    data.IsDelete = true;
                    data.UpdatedAt = DateTime.Now;

                    _context.Categories.Update(data);
                    await _context.SaveChangesAsync();

                    response.status = true;
                    response.message = "Delete Category Success";
                    return response;
                }
                else
                {
                    response.status = false;
                    response.message = "Category Not Found";
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
