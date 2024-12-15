using Application.Common.Model;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.Application_Layer.Repositories;
using BlazorASG.VitsModel.Auth;

namespace BlazorASG.Application_Layer.Use_Cases.Auth
{
    public class CreateLogin
    {
        private readonly IRAuth _irauth;
        private readonly ILoggerService _logger;

        public CreateLogin(IRAuth rAuth, ILoggerService consoleLogger)
        {
            _irauth = rAuth;
            _logger = consoleLogger;
        }
        public async Task<ResponseModel<OutputLogin>>Create(LoginRequest loginRequest)
        {
            try
            {

                _logger.Logg("CreateLogin class", "info");
               
                return await  _irauth.Login(loginRequest);
               // return ResponseModel<OutputLogin>.SuccessResponse("OutputLogin", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("CreateLogin  class" + ex.Message, "error");
                throw new NotImplementedException(ex.Message);
            }
        }

    }
}
