using AutoMapper;
using CRUDGen.Models;
using CRUDGen.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUDGen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESC2ARQDemo_InetumController : BaseCRUDController<ARQDemo_Inetum, ARQDemo_InetumDto>
    {
        public ESC2ARQDemo_InetumController(DbCtx dbCtx, IMapper mapper) :
            base(dbCtx, mapper, primaryKeyName: "ARQ_Id", isIdiomEntity: true)
        {
        }
    }
}