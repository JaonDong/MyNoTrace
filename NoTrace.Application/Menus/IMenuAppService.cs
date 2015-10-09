using System.Collections.Generic;
using Abp.Application.Services;
using NoTrace.Menus.Dtos;

namespace NoTrace.Menus
{
    public interface IMenuAppService:IApplicationService
    {
        void CreateMenu(MenuDto menu);
        void ChangeMenu(MenuDto menu);
      // void  CreateMenu(string MenuName, string Url, string PictureUrl, int? ParentId);
        IList<MenuDto> GetMenus();
        MenuDto GetMenu(int id);
        IList<MenuDto> GetMenuAndChilds(int id);

        void SelectMenu(MenuDto menu);
    }
}