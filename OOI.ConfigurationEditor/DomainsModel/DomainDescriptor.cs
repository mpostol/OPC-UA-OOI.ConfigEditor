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
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://commsvr.com/CAS/CommServer/UA/OOI/ConfigurationEditor/DomainsModel/DomainD" +
        "escriptor.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://commsvr.com/CAS/CommServer/UA/OOI/ConfigurationEditor/DomainsModel/DomainD" +
        "escriptor.xsd", IsNullable=true)]
    public partial class DomainDescriptor {
        
        private string universalDomainNameField;
        
        private string universalAddressSpaceLocatorField;
        
        private string universalDiscoveryServiceLocatorField;
        
        private string universalAuthorizationServerLocatorField;
        
        private string descriptionField;
        
        /// <remarks/>
        public string UniversalDomainName {
            get {
                return this.universalDomainNameField;
            }
            set {
                this.universalDomainNameField = value;
            }
        }
        
        /// <remarks/>
        public string UniversalAddressSpaceLocator {
            get {
                return this.universalAddressSpaceLocatorField;
            }
            set {
                this.universalAddressSpaceLocatorField = value;
            }
        }
        
        /// <remarks/>
        public string UniversalDiscoveryServiceLocator {
            get {
                return this.universalDiscoveryServiceLocatorField;
            }
            set {
                this.universalDiscoveryServiceLocatorField = value;
            }
        }
        
        /// <remarks/>
        public string UniversalAuthorizationServerLocator {
            get {
                return this.universalAuthorizationServerLocatorField;
            }
            set {
                this.universalAuthorizationServerLocatorField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
}