﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgianFoodReviewAPI.Presentation
{

    [Route("api/categories")]
    [ApiController]
    public  class CategoryController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
            
        }
        [HttpGet("{id:guid}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category =await _service.CategoryService.GetCategoryAsync(id, trackChanges:false);
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryToCreateDto category)
        {
            if (category == null)
                return BadRequest("CategoryToCreateDto is null");

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
              
            

            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.CategoryId},createdCategory);

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _service.CategoryService.DeleteCategoryAsync(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
        {

            if (category is null)
                return BadRequest("CategoryForUpdate Dto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.CategoryService.UpdateCatgeoryAsync(id, category, trackChanges:true);
            return NoContent();
        }


    }
}
