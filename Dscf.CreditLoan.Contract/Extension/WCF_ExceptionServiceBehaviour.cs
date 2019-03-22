using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Contract.Extension
{
    public class WCF_ExceptionServiceBehaviour : BehaviorExtensionElement, IServiceBehavior
    {
        public override Type BehaviorType
        {
            get { return typeof(WCF_ExceptionServiceBehaviour); }
        }
        protected override object CreateBehavior()
        {
            return new WCF_ExceptionServiceBehaviour();
        }

        #region IServiceBehavior Members

        public void Validate(ServiceDescription description,
        ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription description,
        ServiceHostBase serviceHostBase,
        Collection<ServiceEndpoint> endpoints,
        BindingParameterCollection parameters)
        {
            //AutomapBootstrap.InitializeMap();
        }

        public void ApplyDispatchBehavior(ServiceDescription description,
        ServiceHostBase serviceHostBase)
        {
            var handler = new WCF_ExceptionHandler();

            foreach (ChannelDispatcherBase dispatcherBase in
            serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = dispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                    channelDispatcher.ErrorHandlers.Add(handler);
            }
        }

        #endregion
    }
}
