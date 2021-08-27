using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Dtos;
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
            var PlateList = _plateRepo.GetPlates();

            var plateDto = new List<PlateDto>();

            foreach (var plate in PlateList)
            {
                plateDto.Add(_mapper.Map<PlateDto>(plate));
            }
            return Ok(plateDto);
        }

        [HttpGet("{plateId:int}")]
        public IActionResult GetPlateById(int plateId)
        {
            var plate = _plateRepo.GetPlate(plateId);
            if (plate is null)
            {
                return NotFound();
            }
             
            var plateDto = _mapper.Map<PlateDto>(plate);
            return Ok(plateDto);

        }

        public IActionResult CreatePlate([FromBody] PlateDto plateDto)
        {
            if (plateDto is null)
            {
                return BadRequest(ModelState);
            }

            if (_plateRepo.PlateExists(plateDto.Name))
            {
                ModelState.AddModelError("", "Plate already Exists!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plateObj = _mapper.Map<Plate>(plateDto);

            if (!_plateRepo.CreatePlate(plateObj))
            {
                ModelState.AddModelError("", $"Error when saving record {plateObj.Name}");
                return StatusCode(500,ModelState);
            }

            return Ok(plateObj);
        }








    }
}
