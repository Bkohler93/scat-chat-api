using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scat_chat_api.Models;
using scat_chat_api.Services.ScatService;
using scat_chat_api.Dtos.Scat;
using AutoMapper;

namespace scat_chat_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScatController : ControllerBase
    {
        private readonly IScatService _scatService;
        private readonly IMapper _mapper;
       public ScatController(IScatService scatService, IMapper mapper)
       {
           _scatService = scatService;
           _mapper = mapper;
       }

        [HttpGet("GetAll")]
       public async Task<ActionResult<ServiceResponse<List<GetScatDto>>>> Get()
       {
           return Ok(await _scatService.GetAllScats()); //sends status code 200 (OK) and scat object
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<ServiceResponse<GetScatDto>>> GetSingle(int id)
        {
            return Ok(await  _scatService.GetScatById(id)); //Default will return a null if no character with id is found
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetScatDto>>>> AddScat(Scat newScat)
        {
            return Ok(await _scatService.AddScat(_mapper.Map<AddScatDto>(newScat)));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetScatDto>>> UpdateScat(UpdateScatDto updatedScat)
        {
            var response = await _scatService.UpdateScat(updatedScat);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetScatDto>>>> Delete(int id)
        {
            var response = await _scatService.DeleteScat(id);

            if (response.Data == null)
            {
                return Ok(null);
            }
            return NotFound(response);
        }
    }
}