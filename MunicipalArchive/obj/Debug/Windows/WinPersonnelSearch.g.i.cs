﻿#pragma checksum "..\..\..\Windows\WinPersonnelSearch.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D0E249178D912A9BBE5B20138E85D3163A54EEC4"
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


namespace MunicipalArchive.Windows {
    
    
    /// <summary>
    /// WinPersonSearch
    /// </summary>
    public partial class WinPersonSearch : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblTitle;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClose;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnMinimize;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblPerName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblPerLastName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblPerNationalCode;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblMobile;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtSearch;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNew;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelect;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\WinPersonnelSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgdPerson;
        
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
            System.Uri resourceLocater = new System.Uri("/MunicipalArchive;component/windows/winpersonnelsearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\WinPersonnelSearch.xaml"
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
            
            #line 7 "..\..\..\Windows\WinPersonnelSearch.xaml"
            ((MunicipalArchive.Windows.WinPersonSearch)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\Windows\WinPersonnelSearch.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DragMove);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LblTitle = ((System.Windows.Controls.Label)(target));
            
            #line 22 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.LblTitle.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DragMove);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnClose = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.BtnClose.Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.BtnMinimize.Click += new System.Windows.RoutedEventHandler(this.Minimize);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LblPerName = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.LblPerLastName = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.LblPerNationalCode = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.LblMobile = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.TxtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.TxtSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnNew = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.BtnSelect = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.DgdPerson = ((System.Windows.Controls.DataGrid)(target));
            
            #line 43 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.DgdPerson.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dataGrid_LoadingRow);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\Windows\WinPersonnelSearch.xaml"
            this.DgdPerson.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DgdPersonnel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

