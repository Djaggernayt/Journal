﻿#pragma checksum "..\..\user.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "887A882AC9055B62DB8729F450CB2E1DAD8E91B74FA288841A4310449D7C407F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using JR;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace JR {
    
    
    /// <summary>
    /// user
    /// </summary>
    public partial class user : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid use;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ex;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exc;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button word;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JR;component/user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\user.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.use = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ex = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\user.xaml"
            this.ex.Click += new System.Windows.RoutedEventHandler(this.ex_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.exc = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\user.xaml"
            this.exc.Click += new System.Windows.RoutedEventHandler(this.exc_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.word = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\user.xaml"
            this.word.Click += new System.Windows.RoutedEventHandler(this.word_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\user.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
