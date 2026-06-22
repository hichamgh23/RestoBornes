using Microsoft.AspNetCore.Mvc;
using RestoBorne.Application.Interfaces; // N'oublie pas cet import !

namespace RestoBorne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        // Le constructeur reçoit le repository injecté par .NET
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // La méthode qui répond aux requêtes GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products); // Retourne la liste en JSON
        }
    }
}

