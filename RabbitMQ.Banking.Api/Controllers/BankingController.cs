using Microsoft.AspNetCore.Mvc;
using Rabbit.Banking.Domain;
using RabbitMQ.Banking.Application;

namespace RabbitMQ.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly AccountService _accountService;public BankingController(AccountService accountService, ILogger<BankingController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        private readonly ILogger<BankingController> _logger;

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }


    }
}
