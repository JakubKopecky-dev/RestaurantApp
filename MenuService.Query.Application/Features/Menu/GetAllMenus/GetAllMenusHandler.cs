using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using MenuService.Query.Application.Features.Menu.SearchMenusByRestaurantName;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.Menu.GetAllMenus
{
    public sealed class GetAllMenusHandler(IMenuRepository menuRepository) : IQueryHandler<GetAllMenusQuery, IReadOnlyList<MenuDto>>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;



        public async Task<IReadOnlyList<MenuDto>> Handle(GetAllMenusQuery query, CancellationToken ct)
        {
            var menus = await _menuRepository.GetAllAsync(ct);

            return [.. menus.Select(m => new MenuDto
            {
                Id = m.Id,
                RestaurantName = m.RestaurantName,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
            })];
        }
    }
}
