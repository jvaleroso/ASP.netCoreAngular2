using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoomFinance.Data;
using Microsoft.EntityFrameworkCore;
using BoomFinance.Core;

namespace BoomFinance.Web
{
	[Route("api/[controller]")]
	public class Bank2Controller : Controller
	{
		readonly FinanceContext _dbContext;

		public Bank2Controller(FinanceContext financeContext)
		{
			_dbContext = financeContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var banks = await _dbContext.Banks.ToListAsync();
			return new ObjectResult(banks);
		}

		[HttpGet("{id}", Name = "GetBank2")]
		public async Task<IActionResult> GetByIdAsync(string id)
		{
			var bank = await _dbContext.FindAsync<Bank>(id);
			return new ObjectResult(bank);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(string id, [FromBody]Bank updatedBank)
		{
			if (updatedBank == null || updatedBank.Id != id)
			{
				return BadRequest();
			}

			var bank =  await _dbContext.FindAsync<Bank>(id);
			if (bank == null)
			{
				return NotFound();
			}

			 _dbContext.Banks.Update(updatedBank);
			return new NoContentResult();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody]Bank bank)
		{
			if (bank == null)
			{
				return BadRequest();
			}

			await _dbContext.Banks.AddAsync(bank);
			return CreatedAtRoute("GetBank2", new { id = bank.Id }, bank);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAsync(string id)
		{
			var bank = await _dbContext.Banks.FindAsync(id);
			if (bank == null)
			{
				return NotFound();
			}

			_dbContext.Banks.Remove(bank);
			return new NoContentResult();
		}
	}
}
