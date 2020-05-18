using System;
using System.Collections.Generic;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categories>> GetCategories()
        {
            try
            {
                var categories = _repository.GetCategories();
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Categories> GetCategorieById(int id)
        {
            try
            {
                var product = _repository.GetCategorieById(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<Categories> AddCategorie([FromBody] Categories categorie)
        {
            try
            {
                _repository.CreateCategorie(categorie);
                _repository.SaveChanges();

                return CreatedAtAction(nameof(GetCategorieById), new Categories { Id = categorie.Id }, categorie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult PutCategorie(Categories categorie)
        {
            try
            {
                var categorieEdit = _repository.GetCategorieById(categorie.Id);
                if (categorieEdit == null)
                    return NotFound();

                categorieEdit.Name = categorie.Name;
                categorieEdit.Description = categorie.Description;

                _repository.UpdateCategorie(categorieEdit);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategorie (int id)
        {
            try
            {
                var categorieDelete = _repository.GetCategorieById(id);
                if (categorieDelete == null)
                    return NotFound();

                _repository.DeleteCategorie(categorieDelete);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}