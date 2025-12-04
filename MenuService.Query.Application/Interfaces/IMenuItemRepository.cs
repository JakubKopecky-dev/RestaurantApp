using MenuService.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<MenuItem?> FindByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<MenuItem>> GetAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<MenuItem>> GetMenuItemsByMenuIdAsync(Guid menuId, CancellationToken ct = default);
        Task<IReadOnlyList<MenuItem>> SearchByTitleAsync(string title, CancellationToken ct);
    }
}
