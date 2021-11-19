using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Api.Services;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;

namespace MovieLibrary.Api.Controllers
{
    [Route("api/v1/CategoryManagement")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetCategoryById([FromRoute] int id)
        {
            var categoryDTO = _categoryService.GetCategoryById(id);
            if (categoryDTO is null)
            {
                return NotFound();
            }

            return Ok(categoryDTO);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetAll()
        {
            var categoryDTOList = _categoryService.GetAll();
            if (categoryDTOList is null)
            {
                return NotFound();
            }

            return Ok(categoryDTOList);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] CreateCategoryDTO cCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = _categoryService.AddCategory(cCategoryDTO);
            return Created($"/api/vi/MovieManagement/{newCategory}", null);
        }

        [HttpPut("{id}")]
        public ActionResult ChangeCategory([FromRoute] int id, [FromBody] UpdateCategoryDTO uCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var changeCategory = _categoryService.ChangeCategoryById(id, uCategoryDTO);

            if (changeCategory is false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategoryById(int id)
        {
            var isDelete = _categoryService.DeleteCategoryById(id);
            if (isDelete)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}
