﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OdontoSysBusiness.tratamientoWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wa.odontosys.com/", ConfigurationName="tratamientoWS.Tratamientos")]
    public interface Tratamientos {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/ListarTratamientosRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/ListarTratamientosResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse ListarTratamientos(OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/ListarTratamientosRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/ListarTratamientosResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse> ListarTratamientosAsync(OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/InsertarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/InsertarTratamientoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse InsertarTratamiento(OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/InsertarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/InsertarTratamientoResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse> InsertarTratamientoAsync(OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/EliminarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/EliminarTratamientoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse EliminarTratamiento(OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/EliminarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/EliminarTratamientoResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse> EliminarTratamientoAsync(OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/ModificarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/ModificarTratamientoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse ModificarTratamiento(OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wa.odontosys.com/Tratamientos/ModificarTratamientoRequest", ReplyAction="http://wa.odontosys.com/Tratamientos/ModificarTratamientoResponse")]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse> ModificarTratamientoAsync(OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.odontosys.com/")]
    public partial class tratamiento : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double costoField;
        
        private string descripcionField;
        
        private especialidad especialidadField;
        
        private int idTratamientoField;
        
        private string nombreField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public double costo {
            get {
                return this.costoField;
            }
            set {
                this.costoField = value;
                this.RaisePropertyChanged("costo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public especialidad especialidad {
            get {
                return this.especialidadField;
            }
            set {
                this.especialidadField = value;
                this.RaisePropertyChanged("especialidad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public int idTratamiento {
            get {
                return this.idTratamientoField;
            }
            set {
                this.idTratamientoField = value;
                this.RaisePropertyChanged("idTratamiento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("nombre");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wa.odontosys.com/")]
    public partial class especialidad : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idEspecialidadField;
        
        private string nombreField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int idEspecialidad {
            get {
                return this.idEspecialidadField;
            }
            set {
                this.idEspecialidadField = value;
                this.RaisePropertyChanged("idEspecialidad");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("nombre");
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
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListarTratamientos", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class ListarTratamientosRequest {
        
        public ListarTratamientosRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListarTratamientosResponse", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class ListarTratamientosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.tratamientoWS.tratamiento[] @return;
        
        public ListarTratamientosResponse() {
        }
        
        public ListarTratamientosResponse(OdontoSysBusiness.tratamientoWS.tratamiento[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarTratamiento", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class InsertarTratamientoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.tratamientoWS.tratamiento tratamiento;
        
        public InsertarTratamientoRequest() {
        }
        
        public InsertarTratamientoRequest(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            this.tratamiento = tratamiento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertarTratamientoResponse", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class InsertarTratamientoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public InsertarTratamientoResponse() {
        }
        
        public InsertarTratamientoResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EliminarTratamiento", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class EliminarTratamientoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.tratamientoWS.tratamiento tratamiento;
        
        public EliminarTratamientoRequest() {
        }
        
        public EliminarTratamientoRequest(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            this.tratamiento = tratamiento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EliminarTratamientoResponse", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class EliminarTratamientoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public EliminarTratamientoResponse() {
        }
        
        public EliminarTratamientoResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModificarTratamiento", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class ModificarTratamientoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OdontoSysBusiness.tratamientoWS.tratamiento tratamiento;
        
        public ModificarTratamientoRequest() {
        }
        
        public ModificarTratamientoRequest(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            this.tratamiento = tratamiento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ModificarTratamientoResponse", WrapperNamespace="http://wa.odontosys.com/", IsWrapped=true)]
    public partial class ModificarTratamientoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wa.odontosys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public ModificarTratamientoResponse() {
        }
        
        public ModificarTratamientoResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TratamientosChannel : OdontoSysBusiness.tratamientoWS.Tratamientos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TratamientosClient : System.ServiceModel.ClientBase<OdontoSysBusiness.tratamientoWS.Tratamientos>, OdontoSysBusiness.tratamientoWS.Tratamientos {
        
        public TratamientosClient() {
        }
        
        public TratamientosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TratamientosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TratamientosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TratamientosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse OdontoSysBusiness.tratamientoWS.Tratamientos.ListarTratamientos(OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest request) {
            return base.Channel.ListarTratamientos(request);
        }
        
        public OdontoSysBusiness.tratamientoWS.tratamiento[] ListarTratamientos() {
            OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest inValue = new OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest();
            OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse retVal = ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).ListarTratamientos(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse> OdontoSysBusiness.tratamientoWS.Tratamientos.ListarTratamientosAsync(OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest request) {
            return base.Channel.ListarTratamientosAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ListarTratamientosResponse> ListarTratamientosAsync() {
            OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest inValue = new OdontoSysBusiness.tratamientoWS.ListarTratamientosRequest();
            return ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).ListarTratamientosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse OdontoSysBusiness.tratamientoWS.Tratamientos.InsertarTratamiento(OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest request) {
            return base.Channel.InsertarTratamiento(request);
        }
        
        public int InsertarTratamiento(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse retVal = ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).InsertarTratamiento(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse> OdontoSysBusiness.tratamientoWS.Tratamientos.InsertarTratamientoAsync(OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest request) {
            return base.Channel.InsertarTratamientoAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.InsertarTratamientoResponse> InsertarTratamientoAsync(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.InsertarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            return ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).InsertarTratamientoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse OdontoSysBusiness.tratamientoWS.Tratamientos.EliminarTratamiento(OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest request) {
            return base.Channel.EliminarTratamiento(request);
        }
        
        public int EliminarTratamiento(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse retVal = ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).EliminarTratamiento(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse> OdontoSysBusiness.tratamientoWS.Tratamientos.EliminarTratamientoAsync(OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest request) {
            return base.Channel.EliminarTratamientoAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.EliminarTratamientoResponse> EliminarTratamientoAsync(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.EliminarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            return ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).EliminarTratamientoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse OdontoSysBusiness.tratamientoWS.Tratamientos.ModificarTratamiento(OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest request) {
            return base.Channel.ModificarTratamiento(request);
        }
        
        public int ModificarTratamiento(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse retVal = ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).ModificarTratamiento(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse> OdontoSysBusiness.tratamientoWS.Tratamientos.ModificarTratamientoAsync(OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest request) {
            return base.Channel.ModificarTratamientoAsync(request);
        }
        
        public System.Threading.Tasks.Task<OdontoSysBusiness.tratamientoWS.ModificarTratamientoResponse> ModificarTratamientoAsync(OdontoSysBusiness.tratamientoWS.tratamiento tratamiento) {
            OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest inValue = new OdontoSysBusiness.tratamientoWS.ModificarTratamientoRequest();
            inValue.tratamiento = tratamiento;
            return ((OdontoSysBusiness.tratamientoWS.Tratamientos)(this)).ModificarTratamientoAsync(inValue);
        }
    }
}
