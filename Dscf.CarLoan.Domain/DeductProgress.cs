using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class DeductProgress
    {

        public int DeductId { get; set; }

        public int? OrderId { get; set; }

        public int? RepayPeriod { get; set; }

        public DateTime? PlanDeductDate { get; set; }

        public DateTime? ActualDeductDate { get; set; }

        public decimal? PlanDeductAmount { get; set; }

        public decimal? ActualDeductAmount { get; set; }

        public int? DeductCount { get; set; }

        public string IsDeductSucess { get; set; }

        public int? DeductOptId { get; set; }

        public string ReqSn { get; set; }

        public string Code { get; set; }

        public string SN { get; set; }

        public string Result { get; set; }

        public int? IsResult { get; set; }

        public int? RepayId { get; set; }

        public Guid DeductGuid { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? OperateId { get; set; }

        public int? LastOperateId { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public int? IsEnable { get; set; }

        public int? IsDelete { get; set; }

        public int? StatusId { get; set; }

        public int? PaymentType { get; set; }

        public int? ApplyId { get; set; }

    }
}
