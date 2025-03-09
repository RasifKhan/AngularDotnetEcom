
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

//public class ProductsController(IProductRepository repo) : ControllerBase   
public class ProductsController(IGenericRepository<Product> repo) : BaseApiController
{
   

    [HttpGet]
    //public async Task<ActionResult<IReadOnlyList<Product>>>GetProducts(string? brand, string? type, string? sort)
    public async Task<ActionResult<IReadOnlyList<Product>>>GetProducts(
       [FromQuery]ProductSpecParams specParams)
    {
       // var spec=new ProductSpecification(brand,type,sort);

        var spec=new ProductSpecification(specParams);
       
        return await CreatePagedResult(repo,spec,specParams.PageIndex,specParams.PageSize);
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
