using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace NoTrace.Menus
{
    [Table("Menus")]
    public class Menu:Entity<int>
    {
         public string MenuName { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }
        public bool IsTop { get; set; }
        public Menu ParentMenu { get; set; }
        public ICollection<Menu> ChildMenus { get; set; }
    }
}