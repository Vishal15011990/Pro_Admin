﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pro_Admin {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource1 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource1() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Pro_Admin.Resource1", typeof(Resource1).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to vishalkumar4931@gmail.com.
        /// </summary>
        public static string Email_Account {
            get {
                return ResourceManager.GetString("Email Account", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to kumar@342.
        /// </summary>
        public static string Email_Password {
            get {
                return ResourceManager.GetString("Email Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Email Notification].
        /// </summary>
        public static string Email_Subject {
            get {
                return ResourceManager.GetString("Email_Subject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to smtp.gmail.com.
        /// </summary>
        public static string Smtp_Gmail {
            get {
                return ResourceManager.GetString("Smtp_Gmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 587.
        /// </summary>
        public static string Smtp_Port {
            get {
                return ResourceManager.GetString("Smtp_Port", resourceCulture);
            }
        }
    }
}