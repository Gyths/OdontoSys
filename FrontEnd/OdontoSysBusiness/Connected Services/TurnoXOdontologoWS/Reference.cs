﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OdontoSysBusiness.TurnoXOdontologoWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", ConfigurationName="TurnoXOdontologoWS.TurnoXOdontologoWA")]
    public interface TurnoXOdontologoWA {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_m" +
            "odificarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_m" +
            "odificarResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse turnoXOdontologo_modificar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_m" +
            "odificarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_m" +
            "odificarResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse> turnoXOdontologo_modificarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_e" +
            "liminarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_e" +
            "liminarResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse turnoXOdontologo_eliminar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_e" +
            "liminarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_e" +
            "liminarResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse> turnoXOdontologo_eliminarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_i" +
            "nsertarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_i" +
            "nsertarResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse turnoXOdontologo_insertar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_i" +
            "nsertarRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_i" +
            "nsertarResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse> turnoXOdontologo_insertarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_l" +
            "istarTodosRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_l" +
            "istarTodosResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse turnoXOdontologo_listarTodos(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_l" +
            "istarTodosRequest", ReplyAction="http://webapplication.odontosys.edu.pucp.pe/TurnoXOdontologoWA/turnoXOdontologo_l" +
            "istarTodosResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse> turnoXOdontologo_listarTodosAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/")]
    public partial class turnoXOdontologo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idOdontologoField;
        
        private bool idOdontologoFieldSpecified;
        
        private int idTurnoField;
        
        private bool idTurnoFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int idOdontologo {
            get {
                return this.idOdontologoField;
            }
            set {
                this.idOdontologoField = value;
                this.RaisePropertyChanged("idOdontologo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idOdontologoSpecified {
            get {
                return this.idOdontologoFieldSpecified;
            }
            set {
                this.idOdontologoFieldSpecified = value;
                this.RaisePropertyChanged("idOdontologoSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int idTurno {
            get {
                return this.idTurnoField;
            }
            set {
                this.idTurnoField = value;
                this.RaisePropertyChanged("idTurno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idTurnoSpecified {
            get {
                return this.idTurnoFieldSpecified;
            }
            set {
                this.idTurnoFieldSpecified = value;
                this.RaisePropertyChanged("idTurnoSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_modificar", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_modificarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo;
        
        public turnoXOdontologo_modificarRequest() {
        }
        
        public turnoXOdontologo_modificarRequest(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            this.turnoXOdontologo = turnoXOdontologo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_modificarResponse", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_modificarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public turnoXOdontologo_modificarResponse() {
        }
        
        public turnoXOdontologo_modificarResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_eliminar", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_eliminarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo;
        
        public turnoXOdontologo_eliminarRequest() {
        }
        
        public turnoXOdontologo_eliminarRequest(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            this.turnoXOdontologo = turnoXOdontologo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_eliminarResponse", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_eliminarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public turnoXOdontologo_eliminarResponse() {
        }
        
        public turnoXOdontologo_eliminarResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_insertar", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_insertarRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo;
        
        public turnoXOdontologo_insertarRequest() {
        }
        
        public turnoXOdontologo_insertarRequest(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            this.turnoXOdontologo = turnoXOdontologo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_insertarResponse", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_insertarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public turnoXOdontologo_insertarResponse() {
        }
        
        public turnoXOdontologo_insertarResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_listarTodos", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_listarTodosRequest {
        
        public turnoXOdontologo_listarTodosRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="turnoXOdontologo_listarTodosResponse", WrapperNamespace="http://webapplication.odontosys.edu.pucp.pe/", IsWrapped=true)]
    public partial class turnoXOdontologo_listarTodosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webapplication.odontosys.edu.pucp.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo[] @return;
        
        public turnoXOdontologo_listarTodosResponse() {
        }
        
        public turnoXOdontologo_listarTodosResponse(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TurnoXOdontologoWAChannel : OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TurnoXOdontologoWAClient : System.ServiceModel.ClientBase<OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA>, OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA {
        
        public TurnoXOdontologoWAClient() {
        }
        
        public TurnoXOdontologoWAClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TurnoXOdontologoWAClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TurnoXOdontologoWAClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TurnoXOdontologoWAClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_modificar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest request) {
            return base.Channel.turnoXOdontologo_modificar(request);
        }
        
        public int turnoXOdontologo_modificar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse retVal = ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_modificar(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse> OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_modificarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest request) {
            return base.Channel.turnoXOdontologo_modificarAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarResponse> turnoXOdontologo_modificarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_modificarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            return ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_modificarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_eliminar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest request) {
            return base.Channel.turnoXOdontologo_eliminar(request);
        }
        
        public int turnoXOdontologo_eliminar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse retVal = ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_eliminar(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse> OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_eliminarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest request) {
            return base.Channel.turnoXOdontologo_eliminarAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarResponse> turnoXOdontologo_eliminarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_eliminarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            return ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_eliminarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_insertar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest request) {
            return base.Channel.turnoXOdontologo_insertar(request);
        }
        
        public int turnoXOdontologo_insertar(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse retVal = ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_insertar(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse> OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_insertarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest request) {
            return base.Channel.turnoXOdontologo_insertarAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarResponse> turnoXOdontologo_insertarAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo turnoXOdontologo) {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_insertarRequest();
            inValue.turnoXOdontologo = turnoXOdontologo;
            return ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_insertarAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_listarTodos(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest request) {
            return base.Channel.turnoXOdontologo_listarTodos(request);
        }
        
        public OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo[] turnoXOdontologo_listarTodos() {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest();
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse retVal = ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_listarTodos(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse> OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA.turnoXOdontologo_listarTodosAsync(OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest request) {
            return base.Channel.turnoXOdontologo_listarTodosAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosResponse> turnoXOdontologo_listarTodosAsync() {
            OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest inValue = new OdontoSysBusiness.TurnoXOdontologoWS.turnoXOdontologo_listarTodosRequest();
            return ((OdontoSysBusiness.TurnoXOdontologoWS.TurnoXOdontologoWA)(this)).turnoXOdontologo_listarTodosAsync(inValue);
        }
    }
}
