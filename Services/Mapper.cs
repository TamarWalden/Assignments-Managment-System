using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<AssignmentDto, Assignment>().ReverseMap();
            //    .formember(dest => dest.id, opt => opt.ignore());
            //createmap<assignment, assignmentdto>();
            CreateMap<AssignmentTypeDto, AssignmentType>().ReverseMap();
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());
            //CreateMap<AssignmentType, AssignmentTypeDto>();
        }
    }
}
