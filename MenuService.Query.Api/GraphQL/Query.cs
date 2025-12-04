using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using MenuService.Query.Application.DTOs.MenuItems;
using MenuService.Query.Application.Features.Menu.GetAllMenus;
using MenuService.Query.Application.Features.Menu.GetMenuById;
using MenuService.Query.Application.Features.Menu.SearchMenusByRestaurantName;
using MenuService.Query.Application.Features.MenuItem.GetAllMenuItems;
using MenuService.Query.Application.Features.MenuItem.GetMenuItemById;
using MenuService.Query.Application.Features.MenuItem.SearchMenuItemsByTitle;

namespace MenuService.Query.Api.GraphQL
{
    public class Query(IQueryExecutor executor)
    {
        private readonly IQueryExecutor _executor = executor;




        public async Task<MenuDto?> GetMenuById(Guid id, CancellationToken ct)
        {
            GetMenuByIdQuery query = new(id);

            return await _executor.Execute<GetMenuByIdQuery, MenuDto?>(query, ct);
        }



        public async Task<IReadOnlyList<MenuDto>> GetAllMenus(CancellationToken ct)
        {
            GetAllMenusQuery query = new();

            return await _executor.Execute<GetAllMenusQuery, IReadOnlyList<MenuDto>>(query, ct);
        }



        public async Task<IReadOnlyList<MenuDto>> SearchMenusByRestaurantName(string restaurantName, CancellationToken ct)
        {
            SearchMenusByRestaurantNameQuery query = new(restaurantName);

            return await _executor.Execute<SearchMenusByRestaurantNameQuery,IReadOnlyList<MenuDto>>(query, ct);
        }



        public async Task<MenuItemDto?> GetMenuItemById(Guid id, CancellationToken ct)
        {
            GetMenuItemByIdQuery query = new(id);

            return await _executor.Execute<GetMenuItemByIdQuery, MenuItemDto?>(query, ct);
        }



        public async Task<IReadOnlyList<MenuItemDto>> GetAllMenuItems(CancellationToken ct)
        {
            GetAllMenuItemsQuery query = new();

            return await _executor.Execute<GetAllMenuItemsQuery,IReadOnlyList<MenuItemDto>>(query, ct);
        }



        public async Task<IReadOnlyList<MenuItemDto>> SearchMenuItemsByTitle(string title, CancellationToken ct)
        {
            SearchMenuItemsByTitleQuery query = new(title);

            return await _executor.Execute<SearchMenuItemsByTitleQuery, IReadOnlyList<MenuItemDto>>(query, ct);
        }




    }
}
