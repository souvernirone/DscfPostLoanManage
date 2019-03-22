using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class LobbyInfoMap : EntityTypeConfiguration<LobbyInfo>
    {
        public LobbyInfoMap()
        {
            ToTable("T_LobbyInfo");
            HasKey(lInfo => lInfo.LobbyId);
            HasOptional(lInfo => lInfo.SignedInfo).WithMany().HasForeignKey(lInfo => lInfo.SignedId);

            HasOptional(fInfo => fInfo.FaceTrialInfo).WithMany().HasForeignKey(fInfo => fInfo.FaceTrialId);

            HasOptional(cInfo => cInfo.CarInfo).WithMany().HasForeignKey(cInfo => cInfo.CarInfoId);            
        }
    }
}
