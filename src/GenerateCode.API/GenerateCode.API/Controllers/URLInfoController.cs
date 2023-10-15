using GenerateCode.Infrastucture;
using GenerateCode.Infrastucture.DTOs;
using GenerateCode.Service;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace GenerateCode.API.Controllers
{
    public class URLInfoController : Controller
    {
        private readonly IURLInfoService _urlInfoService;
        public URLInfoController(IURLInfoService urlInfoService)
        {
            _urlInfoService = urlInfoService;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("GetCode")]
        public Guid GetCode(string url)
        {
            var result = _urlInfoService.PrepareURLInfoByURL(url);
            return result.Code;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("GetURL")]
        public ResultItem<URLInfoDTO> GetURL(Guid code)
        {
            var result = _urlInfoService.PrepareURLInfoByCode(code);
            return result;
        }
    }
}
