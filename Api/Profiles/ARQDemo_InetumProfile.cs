using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDGen.Profiles
{
    public class ARQDemo_InetumProfile : Profile
    {
        public ARQDemo_InetumProfile()
        {
            CreateMap<Models.ARQDemo_Inetum, Dtos.ARQDemo_InetumDto>();
            CreateMap<Dtos.ARQDemo_InetumDto, Models.ARQDemo_Inetum>();


            CreateMap<Models.ARQDemo_Inetum_Idioma, Dtos.ARQDemo_Inetum_IdiomaDto>();
            CreateMap<Dtos.ARQDemo_Inetum_IdiomaDto, Models.ARQDemo_Inetum_Idioma>();
        }
    }
}
