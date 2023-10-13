using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Data
{
    public class RequestLogMapper
    {
        public RequestLogMapper(EntityTypeBuilder<RequestLog> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(item => item.Id);
            entityTypeBuilder.Property(item => item.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(item => item.IsURLRequested).IsRequired();
            entityTypeBuilder.Property(item => item.RequestContent).IsRequired();
            entityTypeBuilder.Property(item => item.RequestCount).IsRequired();
        }
    }
}
