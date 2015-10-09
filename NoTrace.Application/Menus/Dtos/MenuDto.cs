using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace NoTrace.Menus.Dtos
{
    public class MenuDto:IInputDto
    {
         public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }
    }
}