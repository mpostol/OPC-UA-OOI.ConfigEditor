﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://raw.githubusercontent.com/mpostol/OPC-UA-OOI/master/DataDiscovery/Tests/D" +
            "iscoveryServices.UnitTest/TestData/root.zone/DomainDescriptor.xml")]
        public string DataDiscoveryRootServiceUrl {
            get {
                return ((string)(this["DataDiscoveryRootServiceUrl"]));
            }
            set {
                this["DataDiscoveryRootServiceUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://commsvr.com/UA/Examples/BoilersSet")]
        public string DefaultInformationModelUri {
            get {
                return ((string)(this["DefaultInformationModelUri"]));
            }
            set {
                this["DefaultInformationModelUri"] = value;
            }
        }
    }
}
