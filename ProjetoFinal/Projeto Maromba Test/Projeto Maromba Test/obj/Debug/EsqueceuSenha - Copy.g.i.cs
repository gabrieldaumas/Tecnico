﻿#pragma checksum "..\..\EsqueceuSenha - Copy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CC410313E01A40CA097881346DBDEB71"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Projeto_Maromba_Test {
    
    
    /// <summary>
    /// EsqueceuSenha
    /// </summary>
    public partial class EsqueceuSenha : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\EsqueceuSenha - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NomeText;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EsqueceuSenha - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailText;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EsqueceuSenha - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataNascText;
        
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
            System.Uri resourceLocater = new System.Uri("/Projeto Maromba Test;component/esqueceusenha%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EsqueceuSenha - Copy.xaml"
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
            
            #line 6 "..\..\EsqueceuSenha - Copy.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute_1);
            
            #line default
            #line hidden
            
            #line 6 "..\..\EsqueceuSenha - Copy.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 7 "..\..\EsqueceuSenha - Copy.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute_1);
            
            #line default
            #line hidden
            
            #line 7 "..\..\EsqueceuSenha - Copy.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_3);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NomeText = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\EsqueceuSenha - Copy.xaml"
            this.NomeText.LostFocus += new System.Windows.RoutedEventHandler(this.NomeText_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EmailText = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\EsqueceuSenha - Copy.xaml"
            this.EmailText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.EmailText_Leave);
            
            #line default
            #line hidden
            
            #line 18 "..\..\EsqueceuSenha - Copy.xaml"
            this.EmailText.LostFocus += new System.Windows.RoutedEventHandler(this.EmailText_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataNascText = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            
            #line 24 "..\..\EsqueceuSenha - Copy.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

