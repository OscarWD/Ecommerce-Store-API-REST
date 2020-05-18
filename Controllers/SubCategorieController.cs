using System;
using System.Collections.Generic;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategorieController : ControllerBase
    {
        private readonly ISubCategorieRepository _repository;

        public SubCategorieController(ISubCategorieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubCategorie>> GetSubCategories()
        {
            try
            {
                var subCatogires = _repository.GetSubCategories();
                return Ok(subCatogires);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SubCategorie> GetSubCategorieById(int id)
        {
            try
            {
                var subCategorie = _repository.GetSubCategorieById(id);
                if (subCategorie == null)
                    return NotFound();

                return Ok(subCategorie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<SubCategorie> AddSubCategorie([FromBody] SubCategorie subCategorie)
        {
            try
            {
                _repository.CreateSubCategorie(subCategorie);
                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetSubCategorieById), new SubCategorie { Id = subCategorie.Id }, subCategorie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult PutSubCategorie(int id, [FromBody] SubCategorie subCategorie)
        {
            try
            {
                if (subCategorie.Id != id)
                    return NotFound();

                _repository.UpdateSubCategorie(subCategorie);
                _repository.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSubCategorie(int id)
        {
            try
            {
                var subCategorieDelete = _repository.GetSubCategorieById(id);
                if (subCategorieDelete == null)
                    return NotFound();

                _repository.DeleteSubCategorie(subCategorieDelete);
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