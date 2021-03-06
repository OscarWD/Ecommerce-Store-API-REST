using System;
using System.Collections.Generic;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetProducts()
        {
            try
            {
                var products = _repository.GetProducts();
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetProduct(int id)
        {
            try
            {
                var product = _repository.GetProductById(id);
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
        public ActionResult<Products> AddProduct([FromBody] Products product)
        {
            try
            {
                _repository.CreateProduct(product);
                _repository.SaveChanges();
                return CreatedAtAction(nameof(GetProduct), new Products { Id = product.Id }, product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult PutProduct(Products product)
        {
            try
            {
                var productEdit = _repository.GetProductById(product.Id);
                if (productEdit == null)
                    return NotFound();

                productEdit.Name = product.Name;
                productEdit.Description = product.Description;
                productEdit.UnitPrice = product.UnitPrice;
                productEdit.BuyPrice = product.BuyPrice;
                productEdit.Quantity = product.Quantity;

                _repository.UpdateProduct(productEdit);
                _repository.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var productDelete = _repository.GetProductById(id);
                if (productDelete == null)
                    return NotFound();
                _repository.DeleteProduct(productDelete);
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