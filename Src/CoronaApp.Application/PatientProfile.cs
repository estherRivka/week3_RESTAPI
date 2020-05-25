using AutoMapper;
using CoronaApp.Models;
using CoronaApp.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoronaApp.Api
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
           // this.CreateMap<string, DateTime>();
            this.CreateMap<Patient, PatientModel>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(m => m.Id))
                //.ForMember(dest=>dest.Paths, )
                .ReverseMap()
                .ForMember(dest => dest.Moniker, opt => opt.Ignore());

            this.CreateMap<Path, PathModel>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(m => m.StartDate.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(m => m.EndDate.ToString("dd/MM/yyyy")))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
               // .ForMember(dest => dest.StartDate, opt => opt.MapFrom(m => DateTime.ParseExact(m.StartDate, "dd/mm/yyyy", null)))
                //.ForMember(dest => dest.EndDate, opt => opt.MapFrom(m => DateTime.ParseExact(m.EndDate, "dd/mm/yyyy", null)));

            // .ForMember(dest => dest.EndDate, opt => opt.MapFrom(m => Convert.ToDateTime(m.EndDate)));
            this.CreateMap<PathSearch, PathSearchModel>().ReverseMap();

        }
    }
}
