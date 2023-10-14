using AutoMapper;
using GenerateCode.Data;
using GenerateCode.Infrastucture;
using GenerateCode.Infrastucture.DTOs;
using GenerateCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Service
{
    public class URLInfoService : IURLInfoService
    {
        #region CTOR
        private readonly IURLInfoRepository _urlInfoRepository;
        private readonly IMapper _mapper;
        public URLInfoService(IURLInfoRepository urlInfoRepository, IMapper mapper)
        {
            _urlInfoRepository = urlInfoRepository;
            _mapper = mapper;
        }

        #endregion CTOR

        #region Methods
        public URLInfoDTO PrepareURLInfoByURL(string url)
        {
            URLInfoDTO result = null;
            result = GetInfoByURL(url);
            if (result == null)
            {
                result = SaveInfo(url);
            }
            return result;
        }
        public ResultItem<URLInfoDTO> PrepareURLInfoByCode(Guid code)
        {
            ResultItem<URLInfoDTO> result = new ResultItem<URLInfoDTO>();
            var urlInfo = GetInfoByCode(code);
            if (urlInfo==null)
            {
                result.Successed = false;
                result.Message = "Not Exist!!";
                return result;
            }
            result.Data = urlInfo;
            result.Successed = true;
            return result;
        }

        private URLInfoDTO? GetInfoByCode(Guid code)
        {
            throw new NotImplementedException();
        }

        private URLInfoDTO? GetInfoByURL(string url)
        {
            var recordExist = _urlInfoRepository.GetInfoByURL(url);
            if (recordExist != null)
            {
                return _mapper.Map<URLInfoDTO>(recordExist);
            }
            return null;
        }
        private URLInfoDTO? SaveInfo(string url)
        {
            URLInfo modelToInsert = new URLInfo
            {
                URL = url,
                Code = Guid.NewGuid()
            };
            var insertResult = _urlInfoRepository.SaveObject(modelToInsert);
            if (insertResult)
            {
                return _mapper.Map<URLInfoDTO>(modelToInsert);
            }
            return null;
        }
        #endregion Methods
    }
}
