﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.AdminServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdminServiceReference.AdminWebServicesSoap")]
    public interface AdminWebServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllEvents", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetAllEvents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllEvents", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetAllEventsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateCommissionRate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateCommissionRate(string eventId, decimal newCommissionRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateCommissionRate", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateCommissionRateAsync(string eventId, decimal newCommissionRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteEvent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DeleteEvent(string eventid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteEvent", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DeleteEventAsync(string eventid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetPartners", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPartners();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetPartners", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPartnersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeletePartnerByEmail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool DeletePartnerByEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeletePartnerByEmail", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> DeletePartnerByEmailAsync(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AdminWebServicesSoapChannel : WebApplication1.AdminServiceReference.AdminWebServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminWebServicesSoapClient : System.ServiceModel.ClientBase<WebApplication1.AdminServiceReference.AdminWebServicesSoap>, WebApplication1.AdminServiceReference.AdminWebServicesSoap {
        
        public AdminWebServicesSoapClient() {
        }
        
        public AdminWebServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdminWebServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminWebServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminWebServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetAllEvents() {
            return base.Channel.GetAllEvents();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetAllEventsAsync() {
            return base.Channel.GetAllEventsAsync();
        }
        
        public string UpdateCommissionRate(string eventId, decimal newCommissionRate) {
            return base.Channel.UpdateCommissionRate(eventId, newCommissionRate);
        }
        
        public System.Threading.Tasks.Task<string> UpdateCommissionRateAsync(string eventId, decimal newCommissionRate) {
            return base.Channel.UpdateCommissionRateAsync(eventId, newCommissionRate);
        }
        
        public string DeleteEvent(string eventid) {
            return base.Channel.DeleteEvent(eventid);
        }
        
        public System.Threading.Tasks.Task<string> DeleteEventAsync(string eventid) {
            return base.Channel.DeleteEventAsync(eventid);
        }
        
        public System.Data.DataSet GetPartners() {
            return base.Channel.GetPartners();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPartnersAsync() {
            return base.Channel.GetPartnersAsync();
        }
        
        public bool DeletePartnerByEmail(string email) {
            return base.Channel.DeletePartnerByEmail(email);
        }
        
        public System.Threading.Tasks.Task<bool> DeletePartnerByEmailAsync(string email) {
            return base.Channel.DeletePartnerByEmailAsync(email);
        }
    }
}
