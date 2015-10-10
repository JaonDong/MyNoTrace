using System.Threading.Tasks;
using AutoMapper;
using NoTrace.Menus;
using NoTrace.Menus.Dtos;

namespace NoTrace
{
    internal static class DtoMappings
    {
        public static void Map()
        {
            Mapper.CreateMap<Menu, MenuDto>()
                .ForMember(t => t.ParentId, opts => opts.MapFrom(d => d.ParentMenu.Id));

            Mapper.CreateMap<MenuDto, Menu>();
        }
    }
}