﻿#pragma checksum "..\..\Start.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F499CE13B7EBCE48A65AAE9C15CDF83C365F53D06CB4C4570FDDFBF94CF073EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ConnectFour;
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


namespace ConnectFour {
    
    
    /// <summary>
    /// Start
    /// </summary>
    public partial class Start : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPlayer1Nought;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPlayer2Nought;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxPlayer1Name;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxPlayer2Name;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayer1Previous;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayer1Next;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayer2Previous;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Start.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayer2Next;
        
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
            System.Uri resourceLocater = new System.Uri("/ConnectFour;component/start.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Start.xaml"
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
            this.imgPlayer1Nought = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.imgPlayer2Nought = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.tbxPlayer1Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\Start.xaml"
            this.tbxPlayer1Name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbxPlayer1Name_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxPlayer2Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\Start.xaml"
            this.tbxPlayer2Name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbxPlayer2Name_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnPlayer1Previous = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Start.xaml"
            this.btnPlayer1Previous.Click += new System.Windows.RoutedEventHandler(this.btnPlayer1Previous_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPlayer1Next = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\Start.xaml"
            this.btnPlayer1Next.Click += new System.Windows.RoutedEventHandler(this.btnPlayer1Next_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPlayer2Previous = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\Start.xaml"
            this.btnPlayer2Previous.Click += new System.Windows.RoutedEventHandler(this.btnPlayer2Previous_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnPlayer2Next = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Start.xaml"
            this.btnPlayer2Next.Click += new System.Windows.RoutedEventHandler(this.btnPlayer2Next_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
