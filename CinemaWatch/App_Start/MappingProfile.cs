﻿using AutoMapper;
using CinemaWatch.Dtos;
using CinemaWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWatch.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}