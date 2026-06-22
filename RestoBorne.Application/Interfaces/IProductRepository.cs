using System;
using System.Collections.Generic;
using System.Text;
using RestoBorne.Domain.Entities;
using System.Threading.Tasks;

namespace RestoBorne.Application.Interfaces
{
    public interface IProductRepository
    {
        // On utilise IEnumerable pour la lecture seule (plus performant)
        Task<IEnumerable<Product>> GetAllAsync();

        // On utilise le '?' pour gérer les produits inexistants en toute sécurité
        Task<Product?> GetByIdAsync(Guid id);
    }
}
