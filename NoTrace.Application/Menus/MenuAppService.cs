using System;
using System.Collections.Generic;
using Abp;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using NoTrace.Menus.Dtos;

namespace NoTrace.Menus
{
    public class MenuAppService:ApplicationService,IMenuAppService
    {
        private readonly IRepository<Menu> _menuRepository;
        
        public MenuAppService(IRepository<Menu> menuRepository )
        {
            _menuRepository = menuRepository;
        }


        public void ChangeMenu(MenuDto dto)
        {

        }

        public void CreateMenu(MenuDto dto)
        {
            var id = dto.ParentId;

        }
        public MenuDto GetMenu(int id) { throw  new Exception();}

        public IList<MenuDto> GetMenus()
        {
            return _menuRepository.GetAllList().MapTo<List<MenuDto>>();
        }
        public IList<MenuDto> GetMenuAndChilds(int id) { throw new Exception();}

        public void SelectMenu(MenuDto menu)
        {
            //。。。。。。。
        }
    }
}