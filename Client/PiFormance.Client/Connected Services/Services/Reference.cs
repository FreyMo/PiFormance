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
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.27428.1
// 
namespace PiFormance.Client.Services {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Services.ISystemService")]
    public interface ISystemService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISystemService/GetCpuSample", ReplyAction="http://tempuri.org/ISystemService/GetCpuSampleResponse")]
        System.Threading.Tasks.Task<PiFormance.ServiceContracts.Cpu.CpuSample> GetCpuSampleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISystemService/GetRamSample", ReplyAction="http://tempuri.org/ISystemService/GetRamSampleResponse")]
        System.Threading.Tasks.Task<PiFormance.ServiceContracts.Memory.RamSample> GetRamSampleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISystemService/GetGpuSample", ReplyAction="http://tempuri.org/ISystemService/GetGpuSampleResponse")]
        System.Threading.Tasks.Task<PiFormance.ServiceContracts.Gpu.GpuSample> GetGpuSampleAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISystemServiceChannel : PiFormance.Client.Services.ISystemService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SystemServiceClient : System.ServiceModel.ClientBase<PiFormance.Client.Services.ISystemService>, PiFormance.Client.Services.ISystemService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SystemServiceClient() : 
                base(SystemServiceClient.GetDefaultBinding(), SystemServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.NetTcpBinding_ISystemService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SystemServiceClient.GetBindingForEndpoint(endpointConfiguration), SystemServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SystemServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SystemServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SystemServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<PiFormance.ServiceContracts.Cpu.CpuSample> GetCpuSampleAsync() {
            return base.Channel.GetCpuSampleAsync();
        }
        
        public System.Threading.Tasks.Task<PiFormance.ServiceContracts.Memory.RamSample> GetRamSampleAsync() {
            return base.Channel.GetRamSampleAsync();
        }
        
        public System.Threading.Tasks.Task<PiFormance.ServiceContracts.Gpu.GpuSample> GetGpuSampleAsync() {
            return base.Channel.GetGpuSampleAsync();
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
                return new System.ServiceModel.EndpointAddress(new System.Uri("net.tcp://localhost:8749/PiFormance/"), new System.ServiceModel.DnsEndpointIdentity("localhost"));
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return SystemServiceClient.GetBindingForEndpoint(EndpointConfiguration.NetTcpBinding_ISystemService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return SystemServiceClient.GetEndpointAddress(EndpointConfiguration.NetTcpBinding_ISystemService);
        }
        
        public enum EndpointConfiguration {
            
            NetTcpBinding_ISystemService,
        }
    }
}
