using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.Menu.SearchMenusByRestaurantName
{
    public sealed class SearchMenusByRestaurantNameHandler(IMenuRepository menuRepository) : IQueryHandler<SearchMenusByRestaurantNameQuery, IReadOnlyList<MenuDto>>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;



        public async Task<IReadOnlyList<MenuDto>> Handle(SearchMenusByRestaurantNameQuery query, CancellationToken ct)
        {
            var menus = await _menuRepository.SearchByRestaurantNameAsync(query.RestaurantName,ct);

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
