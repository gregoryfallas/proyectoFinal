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
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace BLL.WCF {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IBD", Namespace="http://tempuri.org/")]
    public partial class BD : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CrearDTParametrosOperationCompleted;
        
        private System.Threading.SendOrPostCallback ListarFiltrarDatosOperationCompleted;
        
        private System.Threading.SendOrPostCallback Ins_Mod_Eli_DatosOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BD() {
            this.Url = global::BLL.Properties.Settings.Default.BLL_WCF_BD;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CrearDTParametrosCompletedEventHandler CrearDTParametrosCompleted;
        
        /// <remarks/>
        public event ListarFiltrarDatosCompletedEventHandler ListarFiltrarDatosCompleted;
        
        /// <remarks/>
        public event Ins_Mod_Eli_DatosCompletedEventHandler Ins_Mod_Eli_DatosCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IBD/CrearDTParametros", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataTable CrearDTParametros() {
            object[] results = this.Invoke("CrearDTParametros", new object[0]);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void CrearDTParametrosAsync() {
            this.CrearDTParametrosAsync(null);
        }
        
        /// <remarks/>
        public void CrearDTParametrosAsync(object userState) {
            if ((this.CrearDTParametrosOperationCompleted == null)) {
                this.CrearDTParametrosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCrearDTParametrosOperationCompleted);
            }
            this.InvokeAsync("CrearDTParametros", new object[0], this.CrearDTParametrosOperationCompleted, userState);
        }
        
        private void OnCrearDTParametrosOperationCompleted(object arg) {
            if ((this.CrearDTParametrosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CrearDTParametrosCompleted(this, new CrearDTParametrosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IBD/ListarFiltrarDatos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataTable ListarFiltrarDatos([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string sNombreSP, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Data.DataTable DT_Parametros, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] ref string sMsjError) {
            object[] results = this.Invoke("ListarFiltrarDatos", new object[] {
                        sNombreSP,
                        DT_Parametros,
                        sMsjError});
            sMsjError = ((string)(results[1]));
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void ListarFiltrarDatosAsync(string sNombreSP, System.Data.DataTable DT_Parametros, string sMsjError) {
            this.ListarFiltrarDatosAsync(sNombreSP, DT_Parametros, sMsjError, null);
        }
        
        /// <remarks/>
        public void ListarFiltrarDatosAsync(string sNombreSP, System.Data.DataTable DT_Parametros, string sMsjError, object userState) {
            if ((this.ListarFiltrarDatosOperationCompleted == null)) {
                this.ListarFiltrarDatosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarFiltrarDatosOperationCompleted);
            }
            this.InvokeAsync("ListarFiltrarDatos", new object[] {
                        sNombreSP,
                        DT_Parametros,
                        sMsjError}, this.ListarFiltrarDatosOperationCompleted, userState);
        }
        
        private void OnListarFiltrarDatosOperationCompleted(object arg) {
            if ((this.ListarFiltrarDatosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarFiltrarDatosCompleted(this, new ListarFiltrarDatosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IBD/Ins_Mod_Eli_Datos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Ins_Mod_Eli_Datos([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string sNombreSP, bool bBandera, [System.Xml.Serialization.XmlIgnoreAttribute()] bool bBanderaSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Data.DataTable DT_Parametros, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] ref string sMsjError) {
            object[] results = this.Invoke("Ins_Mod_Eli_Datos", new object[] {
                        sNombreSP,
                        bBandera,
                        bBanderaSpecified,
                        DT_Parametros,
                        sMsjError});
            sMsjError = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Ins_Mod_Eli_DatosAsync(string sNombreSP, bool bBandera, bool bBanderaSpecified, System.Data.DataTable DT_Parametros, string sMsjError) {
            this.Ins_Mod_Eli_DatosAsync(sNombreSP, bBandera, bBanderaSpecified, DT_Parametros, sMsjError, null);
        }
        
        /// <remarks/>
        public void Ins_Mod_Eli_DatosAsync(string sNombreSP, bool bBandera, bool bBanderaSpecified, System.Data.DataTable DT_Parametros, string sMsjError, object userState) {
            if ((this.Ins_Mod_Eli_DatosOperationCompleted == null)) {
                this.Ins_Mod_Eli_DatosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIns_Mod_Eli_DatosOperationCompleted);
            }
            this.InvokeAsync("Ins_Mod_Eli_Datos", new object[] {
                        sNombreSP,
                        bBandera,
                        bBanderaSpecified,
                        DT_Parametros,
                        sMsjError}, this.Ins_Mod_Eli_DatosOperationCompleted, userState);
        }
        
        private void OnIns_Mod_Eli_DatosOperationCompleted(object arg) {
            if ((this.Ins_Mod_Eli_DatosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Ins_Mod_Eli_DatosCompleted(this, new Ins_Mod_Eli_DatosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void CrearDTParametrosCompletedEventHandler(object sender, CrearDTParametrosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CrearDTParametrosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CrearDTParametrosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void ListarFiltrarDatosCompletedEventHandler(object sender, ListarFiltrarDatosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarFiltrarDatosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarFiltrarDatosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string sMsjError {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void Ins_Mod_Eli_DatosCompletedEventHandler(object sender, Ins_Mod_Eli_DatosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Ins_Mod_Eli_DatosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Ins_Mod_Eli_DatosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string sMsjError {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591