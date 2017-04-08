using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BoomFinance.Core.Repository;
using BoomFinance.Core;

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

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var banks = await _repository.GetListAsync();
			return new ObjectResult(banks);
		}

		[HttpGet("{id}", Name = "GetBank")]
		public async Task<IActionResult> GetByIdAsync(string id)
		{
			var bank = await _repository.FindOneAsync(id);
			return new ObjectResult(bank);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(string id, [FromBody]Bank updatedBank)
		{
			if (updatedBank == null || updatedBank.Id != id)
			{
				return BadRequest();
			}

			var bank = await _repository.FindOneAsync(id);
			if (bank == null)
			{
				return NotFound();
			}

			await _repository.UpdateAsync(id, updatedBank);
			return new NoContentResult();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody]Bank bank)
		{
			if (bank == null)
			{
				return BadRequest();
			}

			await _repository.AddAsync(bank);
			return CreatedAtRoute("GetBank", new { id = bank.Id }, bank);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(string id)
		{
			var bank = await _repository.FindOneAsync(id);
			if (bank == null)
			{
				return NotFound();
			}

			await _repository.DeleteAsync(id);
			return new NoContentResult();
		}
	}
}
