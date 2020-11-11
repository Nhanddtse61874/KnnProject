using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace RecommenceService.Models.Config
{
    public class ResultConfig :  EntityTypeConfiguration<Result>
    {
        public ResultConfig()
        {
            ToTable("Result").HasKey(x => x.Id);

            Property(x => x.userId).IsRequired();

            Property(x => x.Name).IsRequired().HasMaxLength(255);


        }
    }
}
