using Microsoft.AspNetCore.Mvc;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Domain.Base;
using WalletService.Domain.Models.Users.Responses;

namespace WalletService.Presenter.Controllers
{
    [ApiController]
    [Route("services/users")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IVisitorServiceCommand _serviceCommand;

        public UserController(IVisitorServiceCommand serviceCommand)
        {
            _serviceCommand = serviceCommand;
        }


        [HttpPost("create-visitor")]
        public async Task<ActionResult<BaseResponse<VisitorDTO>>> CreateUserTemp()
        {
            var visitor = await _serviceCommand.CreateVisitor();
            var baseResponse = new BaseResponse<VisitorDTO> { Data = visitor };
            return Ok(baseResponse);
        }
    }
}
