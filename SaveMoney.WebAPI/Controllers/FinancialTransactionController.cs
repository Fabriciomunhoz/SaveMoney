
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveMoney.Application.Interfaces;

namespace SaveMoney.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IFinancialTransactionService _financialTransactionSerivce;

        public FinancialTransactionController(IFinancialTransactionService financialTransactionSerivce)
        {
            _financialTransactionSerivce = financialTransactionSerivce;
        }

        [HttpGet("GetFinancialTransaction")]
        public async Task<IActionResult> GetFinancialTransaction()
        {
            var result = await _financialTransactionSerivce.GetFinancialTransactions();
            return Ok(result);
        }
    }
}
