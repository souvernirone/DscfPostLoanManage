using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Dscf.LoanAfter.Contract.Extension
{
    public class WCF_ExceptionHandler : IErrorHandler
    {
        #region IErrorHandler Members

        /// <summary> 
        /// HandleError 
        /// </summary> 
        /// <param name="ex">ex</param> 
        /// <returns>true</returns> 
        public bool HandleError(Exception ex)
        {
            return true;
        }

        /// <summary> 
        /// ProvideFault 
        /// </summary> 
        /// <param name="ex">ex</param> 
        /// <param name="version">version</param> 
        /// <param name="msg">msg</param> 
        public void ProvideFault(Exception ex, MessageVersion version, ref Message msg)
        {

            log4net.ILog log = log4net.LogManager.GetLogger(typeof(WCF_ExceptionHandler));
            log.Error("Error", ex);

            string err = string.Format("调用WCF接口 '{0}' 出错", ex.TargetSite.Name + ",详情：\r\n" + ex.Message);
            var newEx = new FaultException(err);

            MessageFault msgFault = newEx.CreateMessageFault();
            msg = Message.CreateMessage(version, msgFault, newEx.Action);
        }

        #endregion
    }
}
