using Microsoft.AspNetCore.Mvc;

namespace RobBiancoBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpGet("binturong")]
        public bool GetBinturong(string psw)
        {
            return psw.ToLower().Trim() == "yaya";
        }
    }
}
