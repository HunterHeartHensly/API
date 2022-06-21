using Application.Dtos.Auth;
using Application.Dtos.StudentManagement;
using AutoMapper;
using Domain.Entities.Models.Auth;
using Domain.Entities.Models.StudentManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // ----------AUTH---Login---Reister---------
            CreateMap<RegisterModel, RegisterDto>();

            CreateMap<LoginModel, LoginDto>();

            CreateMap<RegisterDto, RegisterModel>();

            CreateMap<LoginDto, LoginModel>();


            // ----------StudentManagement---------
            CreateMap<AcadamiaProgramDto,AcadamicProgram>();

            CreateMap<StatusModelDto, StatusModel>();

            CreateMap<StudentModelDto, StudentModel>();

            CreateMap<EditStudentDto, StudentModel>();



        }
    }
}
