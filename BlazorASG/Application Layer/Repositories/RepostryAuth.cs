using Application.Common.Model;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.VitsModel.Auth;

namespace BlazorASG.Application_Layer.Repositories
{
    public class RepostryAuth :IRAuth
    {
        private readonly ILoggerService _logger;

       
        public RepostryAuth(ILoggerService logger)
        {
            /* _logger = logger*/
            ;
            _logger = logger;
        }

        public async Task<ResponseModel<OutputLogin>> Login(LoginRequest loginRequest)
        {
            try
            {
             
                _logger.Logg("RepostryAuth Insert login", "info");
                var request = new OutputLogin()
                {
                    Token = "ddddd", ReturnUrl = "/"
                };

                return ResponseModel<OutputLogin>.SuccessResponse("OutputLogin", request);
                 
                 
            }
            catch(Exception ex)
            {
                _logger.Logg("Error RepostryAuth Login"+ ex.Message,"error");
                 throw new NotImplementedException(ex.Message);
            }
           

        }

        public async Task<ResponseModel<OutputLogout>>Logout(string Token)
        {
            try
            {
                _logger.Logg("RepostryAuth Insert login", "info");
                var request = new OutputLogout()
                {
                   
                    ReturnUrl = ""
                };

                return ResponseModel<OutputLogout>.SuccessResponse("OutputLogin", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("Error RepostryAuth Login"+ex.Message,"error");
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<ResponseModel<OutputRigister>> Rigister(RegisterRequest registerRequest)
        {
            try
            {
                _logger.Logg("RepostryAuth Insert OutputRigister", "info");
                var request = new OutputRigister()
                {
                     
                    ReturnUrl = ""
                };


                return ResponseModel<OutputRigister>.SuccessResponse("Rigister", request);


            }
            catch (Exception ex)
            {
                _logger.Logg("Error RepostryAuth OutputRigister"+ex.Message,"error");
                throw new NotImplementedException(ex.Message);
            }
        }

         
    }
}
