using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Repository.IRepository;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateController : Controller
    {
        private  IPlatesRepository _plateRepo;
        private readonly IMapper _mapper;

        public PlateController(IPlatesRepository plateRepo, IMapper mapper)
        {
            _plateRepo = plateRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlates()
        {
            var objList = _plateRepo.GetPlates();
            return Ok(objList);
        }
    }
}
