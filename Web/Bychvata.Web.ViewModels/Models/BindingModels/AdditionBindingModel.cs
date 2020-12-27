﻿using AutoMapper;
using Bychvata.Common.Extensions;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System.Linq;
using System.Runtime.Serialization;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class AdditionBindingModel : IMapFrom<Addition>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsIncluded { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Addition, AdditionBindingModel>()
                .ForMember(x => x.IsIncluded, opt =>
                    opt.MapFrom(a => a.ReservationAdditions.Any(reservationAddition => reservationAddition.Id == a.Id)))
                .ForMember(x => x.Name, opt =>
                    opt.MapFrom(x => x.Name.GetName<EnumMemberAttribute>()));
        }
    }
}