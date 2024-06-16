﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.PartnerServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PartnerServiceReference.PartnerWebServicesSoap")]
    public interface PartnerWebServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEvent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddEvent(string eventid, string event_name, string ticket_price, string email, string date, string time, string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddEvent", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AddEventAsync(string eventid, string event_name, string ticket_price, string email, string date, string time, string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEventsByUserEmail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetEventsByUserEmail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEventsByUserEmail", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetEventsByUserEmailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteEvent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DeleteEvent(string eventid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteEvent", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DeleteEventAsync(string eventid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateEvent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateEvent(string eventId, string eventName, string ticketPrice, string date, string time, string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateEvent", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateEventAsync(string eventId, string eventName, string ticketPrice, string date, string time, string location);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PartnerWebServicesSoapChannel : WebApplication1.PartnerServiceReference.PartnerWebServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PartnerWebServicesSoapClient : System.ServiceModel.ClientBase<WebApplication1.PartnerServiceReference.PartnerWebServicesSoap>, WebApplication1.PartnerServiceReference.PartnerWebServicesSoap {
        
        public PartnerWebServicesSoapClient() {
        }
        
        public PartnerWebServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PartnerWebServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PartnerWebServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PartnerWebServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string AddEvent(string eventid, string event_name, string ticket_price, string email, string date, string time, string location) {
            return base.Channel.AddEvent(eventid, event_name, ticket_price, email, date, time, location);
        }
        
        public System.Threading.Tasks.Task<string> AddEventAsync(string eventid, string event_name, string ticket_price, string email, string date, string time, string location) {
            return base.Channel.AddEventAsync(eventid, event_name, ticket_price, email, date, time, location);
        }
        
        public System.Data.DataSet GetEventsByUserEmail(string email) {
            return base.Channel.GetEventsByUserEmail(email);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetEventsByUserEmailAsync(string email) {
            return base.Channel.GetEventsByUserEmailAsync(email);
        }
        
        public string DeleteEvent(string eventid) {
            return base.Channel.DeleteEvent(eventid);
        }
        
        public System.Threading.Tasks.Task<string> DeleteEventAsync(string eventid) {
            return base.Channel.DeleteEventAsync(eventid);
        }
        
        public string UpdateEvent(string eventId, string eventName, string ticketPrice, string date, string time, string location) {
            return base.Channel.UpdateEvent(eventId, eventName, ticketPrice, date, time, location);
        }
        
        public System.Threading.Tasks.Task<string> UpdateEventAsync(string eventId, string eventName, string ticketPrice, string date, string time, string location) {
            return base.Channel.UpdateEventAsync(eventId, eventName, ticketPrice, date, time, location);
        }
    }
}
