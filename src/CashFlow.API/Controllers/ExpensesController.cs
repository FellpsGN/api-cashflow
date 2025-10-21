using Microsoft.AspNetCore.Mvc;
using CashFlow.Communication.Requests;

namespace CashFlow.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            return Created();
        }
    }

