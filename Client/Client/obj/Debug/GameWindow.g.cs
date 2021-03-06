#pragma checksum "..\..\GameWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5C640EF60F877336A318D8B1BE57B502F961F51AB57E38CFCA569FF20E400B74"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client;
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


namespace Client {
    
    
    /// <summary>
    /// GameWindow
    /// </summary>
    public partial class GameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBTurn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBWrongMove;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BQuit;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c2;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c3;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c4;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c5;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas c6;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse ConnIndicator;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/gamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameWindow.xaml"
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
            
            #line 8 "..\..\GameWindow.xaml"
            ((Client.GameWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBTurn = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TBWrongMove = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BQuit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\GameWindow.xaml"
            this.BQuit.Click += new System.Windows.RoutedEventHandler(this.BQuit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.c1 = ((System.Windows.Controls.Canvas)(target));
            
            #line 52 "..\..\GameWindow.xaml"
            this.c1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.c2 = ((System.Windows.Controls.Canvas)(target));
            
            #line 54 "..\..\GameWindow.xaml"
            this.c2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C2);
            
            #line default
            #line hidden
            return;
            case 7:
            this.c3 = ((System.Windows.Controls.Canvas)(target));
            
            #line 56 "..\..\GameWindow.xaml"
            this.c3.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C3);
            
            #line default
            #line hidden
            return;
            case 8:
            this.c4 = ((System.Windows.Controls.Canvas)(target));
            
            #line 58 "..\..\GameWindow.xaml"
            this.c4.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C4);
            
            #line default
            #line hidden
            return;
            case 9:
            this.c5 = ((System.Windows.Controls.Canvas)(target));
            
            #line 60 "..\..\GameWindow.xaml"
            this.c5.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C5);
            
            #line default
            #line hidden
            return;
            case 10:
            this.c6 = ((System.Windows.Controls.Canvas)(target));
            
            #line 62 "..\..\GameWindow.xaml"
            this.c6.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.C6);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ConnIndicator = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

