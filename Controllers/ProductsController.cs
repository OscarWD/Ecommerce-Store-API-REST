using System;
using System.Collections.Generic;
using EcommerceStoreAPI.Data;
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
            var product = _repository.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Products> AddProduct([FromBody] Products product)
        {
            _repository.CreateProduct(product);
            _repository.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new Products { Id = product.Id }, product);
        }

        [HttpPut]
        public ActionResult PutProduct(Products product)
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

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productDelete = _repository.GetProductById(id);
            if (productDelete == null)
                return NotFound();
            _repository.DeleteProduct(productDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}