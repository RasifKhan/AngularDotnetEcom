
using System;
using System.Net.Http.Headers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]

//public class ProductsController(IProductRepository repo) : ControllerBase   
public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
{
   

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>>GetProducts(string? brand, string? type, string? sort)
    {
        var spec=new ProductSpecification(brand,type,sort);
        var products=await repo.ListAsync(spec);
        //return Ok(await repo.ListAllAsync(brand,type,sort));
        //return Ok(await repo.ListAllAsync());
        return Ok(products);
    }

    [HttpGet ("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        //var product =await repo.GetProductAsyncById(id);
         var product =await repo.GetByIdAsync(id);

        if (product==null ) return NotFound();

        return product;
    }
   

    [HttpPost]
     public async Task<ActionResult<Product>> CreateProduct(Product product)
     {
        //repo.AddProduct(product);
        repo.Add(product);


        //if (await repo.SaveChangesAsync())
        if (await repo.SaveAllAsync())
        {
            return CreatedAtAction("GetProduct", new {id=product.Id},product);
        }
        return BadRequest("Problem Creating product");
     }


     
    [HttpPut("{id:int}")]
    public async Task<ActionResult>UpdateProduct (int id,Product product)
    {
        if (product.Id!=id  || !ProductExists(id))
           return BadRequest ("Can't Update this Product");

          // repo.UpdateProduct(product);
           repo.Update(product);
          //if (await repo.SaveChangesAsync())

           if (await repo.SaveAllAsync())
           {
            return NoContent();
           }

           return BadRequest("Problem Updating the product");
    }


     [HttpDelete("{id:int}")]
     public async Task<ActionResult>DeleteProduct (int id)
     {
        //var product =await repo.GetProductAsyncById(id);
        var product =await repo.GetByIdAsync(id);

        if(product==null) return NotFound();

        //repo.DeleteProduct(product);
        repo.Remove(product);

        //if (await repo.SaveChangesAsync())
        if (await repo.SaveAllAsync())
           {
            return NoContent();
           }

           return BadRequest("Problem deleting the product");
     }
     

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>>GetBrands()
    { 
        
        //return Ok(await repo.GetBrandsAsync());
        var spec=new BrandListSpecification();
        return Ok(await repo.ListAsync(spec));
    }

     [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>>GetTypes()
    { 

      
       // return Ok(await repo.GetTypesAsync());
       var spec =new TypeListSpecification();
        return Ok(await repo.ListAsync(spec));
    }

    private bool ProductExists(int id)
    {
      //return repo.ProductExists(id);  
      return repo.Exists(id);  
    }

}
