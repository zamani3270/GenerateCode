using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Data
{
    public class URLInfoMapper
    {
        public URLInfoMapper(EntityTypeBuilder<URLInfo> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(item => item.Id);
            entityTypeBuilder.Property(item=> item.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(item => item.URL).IsRequired();
            entityTypeBuilder.Property(item => item.Code).IsRequired();
        }
    }
}
