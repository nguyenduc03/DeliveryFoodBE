using Server.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService CategoryService { get; set; }
        public CategoryController(CategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }
        //[Authorize(Roles = "Admin,Guest")]
        [HttpGet("get-category-list")]
        public async Task<ActionResult> GetStudentList() {
            try
            {
                List<Category> list = CategoryService.GetCategoryList();
                if (list.Count == 0)
                {

                    return Ok(new { status = true, data = "Null" });
                }
                return Ok(new { status = true, data = list });
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpPost("insert-category")]
        public async Task<ActionResult> InsertCategory(CategoryInsertModel category) {
            try
            {
                Category st = new Category();
                st.Name_Category = category.Name;
                st.Description = category.Description;
                st.Picture = category.Picture;
                CategoryService.InsertCategory(st);
                return Ok(new { status = true, message = "" });
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
