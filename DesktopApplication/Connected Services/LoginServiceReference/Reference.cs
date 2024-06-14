﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopApplication.LoginServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServiceReference.LoginWebServiceSoap")]
    public interface LoginWebServiceSoap {
        
        // CODEGEN: Generating message contract since element name email from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login", ReplyAction="*")]
        DesktopApplication.LoginServiceReference.LoginResponse Login(DesktopApplication.LoginServiceReference.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Login", ReplyAction="*")]
        System.Threading.Tasks.Task<DesktopApplication.LoginServiceReference.LoginResponse> LoginAsync(DesktopApplication.LoginServiceReference.LoginRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Login", Namespace="http://tempuri.org/", Order=0)]
        public DesktopApplication.LoginServiceReference.LoginRequestBody Body;
        
        public LoginRequest() {
        }
        
        public LoginRequest(DesktopApplication.LoginServiceReference.LoginRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string email;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string password;
        
        public LoginRequestBody() {
        }
        
        public LoginRequestBody(string email, string password) {
            this.email = email;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class LoginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="LoginResponse", Namespace="http://tempuri.org/", Order=0)]
        public DesktopApplication.LoginServiceReference.LoginResponseBody Body;
        
        public LoginResponse() {
        }
        
        public LoginResponse(DesktopApplication.LoginServiceReference.LoginResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class LoginResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string LoginResult;
        
        public LoginResponseBody() {
        }
        
        public LoginResponseBody(string LoginResult) {
            this.LoginResult = LoginResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LoginWebServiceSoapChannel : DesktopApplication.LoginServiceReference.LoginWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginWebServiceSoapClient : System.ServiceModel.ClientBase<DesktopApplication.LoginServiceReference.LoginWebServiceSoap>, DesktopApplication.LoginServiceReference.LoginWebServiceSoap {
        
        public LoginWebServiceSoapClient() {
        }
        
        public LoginWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DesktopApplication.LoginServiceReference.LoginResponse DesktopApplication.LoginServiceReference.LoginWebServiceSoap.Login(DesktopApplication.LoginServiceReference.LoginRequest request) {
            return base.Channel.Login(request);
        }
        
        public string Login(string email, string password) {
            DesktopApplication.LoginServiceReference.LoginRequest inValue = new DesktopApplication.LoginServiceReference.LoginRequest();
            inValue.Body = new DesktopApplication.LoginServiceReference.LoginRequestBody();
            inValue.Body.email = email;
            inValue.Body.password = password;
            DesktopApplication.LoginServiceReference.LoginResponse retVal = ((DesktopApplication.LoginServiceReference.LoginWebServiceSoap)(this)).Login(inValue);
            return retVal.Body.LoginResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DesktopApplication.LoginServiceReference.LoginResponse> DesktopApplication.LoginServiceReference.LoginWebServiceSoap.LoginAsync(DesktopApplication.LoginServiceReference.LoginRequest request) {
            return base.Channel.LoginAsync(request);
        }
        
        public System.Threading.Tasks.Task<DesktopApplication.LoginServiceReference.LoginResponse> LoginAsync(string email, string password) {
            DesktopApplication.LoginServiceReference.LoginRequest inValue = new DesktopApplication.LoginServiceReference.LoginRequest();
            inValue.Body = new DesktopApplication.LoginServiceReference.LoginRequestBody();
            inValue.Body.email = email;
            inValue.Body.password = password;
            return ((DesktopApplication.LoginServiceReference.LoginWebServiceSoap)(this)).LoginAsync(inValue);
        }
    }
}
