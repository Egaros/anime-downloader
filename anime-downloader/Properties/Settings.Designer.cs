﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace anime_downloader.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sortedrating")]
        public string SortBy {
            get {
                return ((string)(this["SortBy"]));
            }
            set {
                this["SortBy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FilterBy {
            get {
                return ((string)(this["FilterBy"]));
            }
            set {
                this["FilterBy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<anime_downloader.Models.Anime> Animes {
            get {
                return ((global::System.Collections.Generic.List<anime_downloader.Models.Anime>)(this["Animes"]));
            }
            set {
                this["Animes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<System.String> Subgroups {
            get {
                return ((global::System.Collections.Generic.List<System.String>)(this["Subgroups"]));
            }
            set {
                this["Subgroups"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::anime_downloader.Models.Configurations.MyAnimesListConfiguration MyAnimeListConfiguration {
            get {
                return ((global::anime_downloader.Models.Configurations.MyAnimesListConfiguration)(this["MyAnimeListConfiguration"]));
            }
            set {
                this["MyAnimeListConfiguration"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::anime_downloader.Models.Configurations.PathConfiguration PathConfiguration {
            get {
                return ((global::anime_downloader.Models.Configurations.PathConfiguration)(this["PathConfiguration"]));
            }
            set {
                this["PathConfiguration"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::anime_downloader.Models.Configurations.FlagConfiguration FlagConfiguration {
            get {
                return ((global::anime_downloader.Models.Configurations.FlagConfiguration)(this["FlagConfiguration"]));
            }
            set {
                this["FlagConfiguration"] = value;
            }
        }
    }
}
