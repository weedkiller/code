    [Route("user/v1/[controller]")]
    public class UserLoginController : Controller {
        [HttpGet]
        public async Task<ActionResult<UserLogin>> Get(int userId) {
            var userLoginLogic = new UserLoginLogic();
            var model = await userLoginLogic.GetUserLogin(userId);
            return Ok(model);
        }
    }
