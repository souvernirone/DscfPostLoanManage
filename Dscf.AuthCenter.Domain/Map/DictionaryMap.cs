using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain.Map
{
    public class DictionaryMap : EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMap()
        {
            ToTable("T_Dictionary");
            HasKey(dict => dict.DictId);
        }
    }
}
