﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.26919.1
// 
namespace PiFormance.Client.SystemService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SystemService.ISystemService", CallbackContract=typeof(PiFormance.Client.SystemService.ISystemServiceCallback))]
    public interface ISystemService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceBaseOf_ISystemCallback/Acknowledge")]
        System.Threading.Tasks.Task AcknowledgeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISystemService/GetCpuSample", ReplyAction="http://tempuri.org/ISystemService/GetCpuSampleResponse")]
        System.Threading.Tasks.Task<PiFormance.ServiceContracts.Cpu.CpuSample> GetCpuSampleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISystemService/GetRamSample", ReplyAction="http://tempuri.org/ISystemService/GetRamSampleResponse")]
        System.Threading.Tasks.Task<PiFormance.ServiceContracts.Memory.RamSample> GetRamSampleAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISystemServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISystemService/CpuSampleAcquired")]
        void CpuSampleAcquired(PiFormance.ServiceContracts.Cpu.CpuSample cpuSample);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISystemService/RamSampleAcquired")]
        void RamSampleAcquired(PiFormance.ServiceContracts.Memory.RamSample ramSample);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISystemServiceChannel : PiFormance.Client.SystemService.ISystemService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SystemServiceClientBase : System.ServiceModel.DuplexClientBase<PiFormance.Client.SystemService.ISystemService>, PiFormance.Client.SystemService.ISystemService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SystemServiceClientBase(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance, SystemServiceClientBase.GetDefaultBinding(), SystemServiceClientBase.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.NetTcpBinding_ISystemService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClientBase(System.ServiceModel.InstanceContext callbackInstance, EndpointConfiguration endpointConfiguration) : 
                base(callbackInstance, SystemServiceClientBase.GetBindingForEndpoint(endpointConfiguration), SystemServiceClientBase.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClientBase(System.ServiceModel.InstanceContext callbackInstance, EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(callbackInstance, SystemServiceClientBase.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClientBase(System.ServiceModel.InstanceContext callbackInstance, EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, SystemServiceClientBase.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClientBase(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task AcknowledgeAsync() {
            return base.Channel.AcknowledgeAsync();
        }
        
        public System.Threading.Tasks.Task<PiFormance.ServiceContracts.Cpu.CpuSample> GetCpuSampleAsync() {
            return base.Channel.GetCpuSampleAsync();
        }
        
        public System.Threading.Tasks.Task<PiFormance.ServiceContracts.Memory.RamSample> GetRamSampleAsync() {
            return base.Channel.GetRamSampleAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetTcpBinding_ISystemService)) {
                System.ServiceModel.NetTcpBinding result = new System.ServiceModel.NetTcpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.Security.Mode = System.ServiceModel.SecurityMode.None;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetTcpBinding_ISystemService)) {
                return new System.ServiceModel.EndpointAddress(new System.Uri("net.tcp://localhost:8733/PiFormance/"), new System.ServiceModel.DnsEndpointIdentity("localhost"));
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return SystemServiceClientBase.GetBindingForEndpoint(EndpointConfiguration.NetTcpBinding_ISystemService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return SystemServiceClientBase.GetEndpointAddress(EndpointConfiguration.NetTcpBinding_ISystemService);
        }
        
        public enum EndpointConfiguration {
            
            NetTcpBinding_ISystemService,
        }
    }
    
    public class CpuSampleAcquiredReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CpuSampleAcquiredReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public PiFormance.ServiceContracts.Cpu.CpuSample cpuSample {
            get {
                base.RaiseExceptionIfNecessary();
                return ((PiFormance.ServiceContracts.Cpu.CpuSample)(this.results[0]));
            }
        }
    }
    
    public class RamSampleAcquiredReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public RamSampleAcquiredReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public PiFormance.ServiceContracts.Memory.RamSample ramSample {
            get {
                base.RaiseExceptionIfNecessary();
                return ((PiFormance.ServiceContracts.Memory.RamSample)(this.results[0]));
            }
        }
    }
    
    public partial class SystemServiceClient : SystemServiceClientBase {
        
        public SystemServiceClient(EndpointConfiguration endpointConfiguration) : 
                this(new SystemServiceClientCallback(), endpointConfiguration) {
        }
        
        private SystemServiceClient(SystemServiceClientCallback callbackImpl, EndpointConfiguration endpointConfiguration) : 
                base(new System.ServiceModel.InstanceContext(callbackImpl), endpointConfiguration) {
            callbackImpl.Initialize(this);
        }
        
        public SystemServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new SystemServiceClientCallback(), binding, remoteAddress) {
        }
        
        private SystemServiceClient(SystemServiceClientCallback callbackImpl, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(new System.ServiceModel.InstanceContext(callbackImpl), binding, remoteAddress) {
            callbackImpl.Initialize(this);
        }
        
        public SystemServiceClient() : 
                this(new SystemServiceClientCallback()) {
        }
        
        private SystemServiceClient(SystemServiceClientCallback callbackImpl) : 
                base(new System.ServiceModel.InstanceContext(callbackImpl)) {
            callbackImpl.Initialize(this);
        }
        
        public event System.EventHandler<CpuSampleAcquiredReceivedEventArgs> CpuSampleAcquiredReceived;
        
        public event System.EventHandler<RamSampleAcquiredReceivedEventArgs> RamSampleAcquiredReceived;
        
        private void OnCpuSampleAcquiredReceived(object state) {
            if ((this.CpuSampleAcquiredReceived != null)) {
                object[] results = ((object[])(state));
                this.CpuSampleAcquiredReceived(this, new CpuSampleAcquiredReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnRamSampleAcquiredReceived(object state) {
            if ((this.RamSampleAcquiredReceived != null)) {
                object[] results = ((object[])(state));
                this.RamSampleAcquiredReceived(this, new RamSampleAcquiredReceivedEventArgs(results, null, false, null));
            }
        }
        
        private class SystemServiceClientCallback : object, ISystemServiceCallback {
            
            private SystemServiceClient proxy;
            
            public void Initialize(SystemServiceClient proxy) {
                this.proxy = proxy;
            }
            
            public void CpuSampleAcquired(PiFormance.ServiceContracts.Cpu.CpuSample cpuSample) {
                this.proxy.OnCpuSampleAcquiredReceived(new object[] {
                            cpuSample});
            }
            
            public void RamSampleAcquired(PiFormance.ServiceContracts.Memory.RamSample ramSample) {
                this.proxy.OnRamSampleAcquiredReceived(new object[] {
                            ramSample});
            }
        }
    }
}
