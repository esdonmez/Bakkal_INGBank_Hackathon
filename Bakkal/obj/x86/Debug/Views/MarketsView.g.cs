﻿#pragma checksum "C:\Users\onurcelikeng\Documents\Visual Studio 2015\Projects\Bakkal\Bakkal\Views\MarketsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8AE14B9058FA13360F52CD33D6739C4F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bakkal.Views
{
    partial class MarketsView : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.map = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                    #line 40 "..\..\..\Views\MarketsView.xaml"
                    ((global::Windows.UI.Xaml.Controls.Maps.MapControl)this.map).MapElementClick += this.map_MapElementClick;
                    #line default
                }
                break;
            case 2:
                {
                    this.progress = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
