using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using MenuService.Query.Application.DTOs.MenuItems;
using MenuService.Query.Application.Features.MenuItem.GetMenuItemsByMenuId;

namespace MenuService.Query.Api.Types
{
    public class MenuType:ObjectType<MenuDto>
    {
        protected override void Configure(IObjectTypeDescriptor<MenuDto> descriptor)
        {
            descriptor.Field(f => f.Id).Type<NonNullType<UuidType>>();
            descriptor.Field(f => f.RestaurantName).Type<StringType>();
            descriptor.Field(f => f.CreatedAt).Type<DateTimeType>();
            descriptor.Field(f => f.UpdatedAt).Type<DateTimeType>();

            descriptor
                .Field("items")
                .Type<ListType<ObjectType<MenuItemDto>>>()
                .Resolve(async ctx =>
                {
                    var menu = ctx.Parent<MenuDto>();
                    var executor = ctx.Service<IQueryExecutor>();

                    GetMenuItemsByMenuIdQuery query = new(menu.Id);

                    return await executor.Execute<GetMenuItemsByMenuIdQuery, IReadOnlyList<MenuItemDto>>(query, ctx.RequestAborted);
                });


        }



    }
}
