﻿using AutoMapper;
using Bychvata.Common.Extensions;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class AdditionViewModel : IMapFrom<Addition>, IHaveCustomMappings
    {
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        public decimal Value { get; set; }

        [Display(Name = "Забележка")]
        public string Notes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Addition, AdditionViewModel>()
                .ForMember(x => x.Name, opt =>
                    opt.MapFrom(x => x.Name.GetName<EnumMemberAttribute>()));
        }
    }
}