using Framework.DTOs;
using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CVmanager.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CVController : ControllerBase
	{
		private readonly ICVManagerService _cvManagerService;
        public CVController(ICVManagerService cvManagerService)
        {
            _cvManagerService = cvManagerService;
        }
        
		[HttpGet]
		public async Task<IList<CVDto>> Get()
		{
			return await _cvManagerService.GetCVListAsync();
		}

		[HttpGet("{id}")]
		public async Task<CVDto> Get(int id)
		{
			return await _cvManagerService.GetCVAsync(id);
		}
		[HttpPost]
		public async Task Post([FromBody] CVDto dto)
		{
			await _cvManagerService.CreateCVAsync(dto);
		}

		// PUT api/<CVController>/5
		[HttpPut]
		public async Task Put([FromBody] CVDto dto)
		{
			await _cvManagerService.UpdateCVAsync(dto);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _cvManagerService.DeleteCVAsync(id);
		}
	}
}
