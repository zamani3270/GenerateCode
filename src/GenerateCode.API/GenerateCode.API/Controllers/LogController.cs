using GenerateCode.Service;
using Microsoft.AspNetCore.Mvc;

namespace GenerateCode.API.Controllers
{
    public class LogController : Controller
    {
        #region CTOR
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        #endregion CTOR

        [Microsoft.AspNetCore.Mvc.HttpGet("GetRequestCount")]
        public int? GetRequestCount(string content)
        {
            if (string.IsNullOrEmpty(content) == false)
            {
              return  _logService.GetContentSerachCount(content);
            }
            return 0;
        }
    }
}
