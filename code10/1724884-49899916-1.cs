    [Route("api/v1/Admin")]
    public class AdminController : Controller {
    
        [HttpGet("GetAllKeys")]
        public async Task<IActionResult> GetAllKeys()
        {
            var data = await _manager.GetAllKeyTypes();
            return Ok(data);
        }    
    }
