using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.Menu.GetMenuById
{
    public sealed class GetMenuByIdHandler(IMenuRepository menuRepository) : IQueryHandler<GetMenuByIdQuery,MenuDto?>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;



        public async Task<MenuDto?> Handle(GetMenuByIdQuery query, CancellationToken ct)
        {
            Domain.Models.Menu? menu = await _menuRepository.FindByIdAsync(query.Id, ct);
            if(menu is null)
                return null;

            return new() { Id = menu.Id, RestaurantName = menu.RestaurantName, CreatedAt = menu.CreatedAt ,UpdatedAt = menu.UpdatedAt };
        }



    }
}
