using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoomFinance.Web.Controllers
{
	[Route("api/[controller]")]
	public class BankController : Controller
	{
		readonly IRepository<Bank> _repository;

		public BankController(IRepository<Bank> repository)
		{
			_repository = repository;
		}

		public async Task<IActionResult> GetAll()
		{
			var banks = await _repository.GetListAsync();
			return new ObjectResult(banks);
		}

		[HttpGet("{id}", Name = "GetBank")]
		public async Task<IActionResult> GetById(string id)
		{
			var banks = await _repository.FindOne(id);
			return new ObjectResult(banks);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody]Bank bank)
		{
			if(bank == null)
			{
				return BadRequest();
			}

			await _repository.Add(bank);
			return CreatedAtRoute("GetBank", new { id = bank.Id }, bank);
		}
	} 
}
