using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain.Map
{
    public class FileEntityMap:EntityTypeConfiguration<FileEntity>
    {
        public FileEntityMap()
        {
            ToTable("T_File");
            HasKey(file =>file.FileId);
        }
    }
}
