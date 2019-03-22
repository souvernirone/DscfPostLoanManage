using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain.Map
{
    public class CollectionInfoMap : EntityTypeConfiguration<CollectionInfo>
    {
        public CollectionInfoMap()
        {
            ToTable("T_CollectionInfo");
            HasKey(colection => colection.Id);

            HasMany(colection => colection.UpFileList).WithMany().Map(m =>
            {
                m.ToTable("T_CollectionFile");      //中间关系表表名
                m.MapLeftKey("CollectionId");        //设置T_CollectionInfo表在中间表主键名
                m.MapRightKey("FileId");   //设置T_File表在中间表主键名
            });
        }
    }
}
