using Microsoft.AspNetCore.Mvc;
using Rabbit.Banking.Domain;
using RabbitMQ.Banking.Application;


namespace RabbitMQ.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
         public BankingController(IAccountService accountService, ILogger<BankingController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        private readonly ILogger<BankingController> _logger;

        [HttpGet("Deneme")]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
