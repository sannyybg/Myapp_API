using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbProvider.Abstractions;
using DbProvider.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using tt1ap.Models;

namespace tt1ap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return "Post Username and password on this method";
        }


        [HttpPost]
        public async Task<IActionResult> Post(AccountRequest request)
        {
            var serviceModel = request.Adapt<AccountServiceModel>();

            var authResult = await _service.Authenticate(serviceModel);

            return StatusCode(200, authResult.token);
        }

    }
}