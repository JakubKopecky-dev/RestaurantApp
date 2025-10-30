using MenuService.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Interfaces
{
    public interface IMenuRepository
    {
        Task<Menu?> FindByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<Menu>> GetAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<Menu>> SearchByRestaurantNameAsync(string restaurantName, CancellationToken ct);
    }
}
