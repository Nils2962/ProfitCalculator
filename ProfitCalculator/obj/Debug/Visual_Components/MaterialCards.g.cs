#pragma checksum "..\..\..\Visual_Components\MaterialCards.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6F11047499DF9C6938DABF310634A300F8BAF198E47686658B04782B015D241A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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


namespace ProfitCalculator.Visual_Components {
    
    
    /// <summary>
    /// MaterialCards
    /// </summary>
    public partial class MaterialCards : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\Visual_Components\MaterialCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ProfitCalculator.Visual_Components.MaterialCards userControl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Visual_Components\MaterialCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard Grow_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Visual_Components\MaterialCards.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart chart;
        
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
            System.Uri resourceLocater = new System.Uri("/ProfitCalculator;component/visual_components/materialcards.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Visual_Components\MaterialCards.xaml"
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
            this.userControl = ((ProfitCalculator.Visual_Components.MaterialCards)(target));
            return;
            case 2:
            this.Grow_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.chart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

