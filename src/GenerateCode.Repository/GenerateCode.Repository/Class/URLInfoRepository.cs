using GenerateCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repository
{
    public class URLInfoRepository : IURLInfoRepository
    {
        #region CTOR
        private readonly ApplicationDbContext _context;
        public URLInfoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion CTOR

        #region Methods
        public bool SaveObject(URLInfo dataModel)
        {
            bool result = false;
            try
            {
                _context.URLInfo.Add(new URLInfo
                {
                    URL = dataModel.URL,
                    Code = dataModel.Code
                });
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public URLInfo? GetInfoByURL(string url)
        {
            var record=_context.URLInfo.FirstOrDefault(item=> item.URL==url);
            return record;
        }
        public URLInfo? GetInfoByCode(Guid code)
        {
            var record = _context.URLInfo.FirstOrDefault(item => item.Code == code);
            return record;
        }
        #endregion Methods

    }
}
