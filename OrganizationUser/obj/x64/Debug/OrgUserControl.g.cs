﻿#pragma checksum "D:\Organization\OrganizationUser\OrganizationUser\OrgUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8FF4245F9BC509CBB33D2B118ACFFCB3F75005AA58D91B836246F945DBC5884F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizationUser
{
    partial class OrgUserControl : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_OrganizationUser_StatusComparisonTrigger_DataValue(global::OrganizationUser.StatusComparisonTrigger obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.DataValue = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(global::Windows.UI.Xaml.DependencyObject obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                global::Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(obj, value);
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class OrgUserControl_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IOrgUserControl_Bindings
        {
            private global::OrganizationUser.OrgUserControl dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::OrganizationUser.StatusComparisonTrigger obj3;
            private global::OrganizationUser.StatusComparisonTrigger obj4;
            private global::Windows.UI.Xaml.Controls.Image obj6;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3DataValueDisabled = false;
            private static bool isobj4DataValueDisabled = false;
            private static bool isobj6SourceDisabled = false;
            private static bool isobj8TextDisabled = false;
            private static bool isobj8ToolTipDisabled = false;
            private static bool isobj9TextDisabled = false;
            private static bool isobj9ToolTipDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj10ToolTipDisabled = false;
            private static bool isobj16TextDisabled = false;
            private static bool isobj16ToolTipDisabled = false;
            private static bool isobj17TextDisabled = false;

            private OrgUserControl_obj1_BindingsTracking bindingsTracking;

            public OrgUserControl_obj1_Bindings()
            {
                this.bindingsTracking = new OrgUserControl_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 35 && columnNumber == 56)
                {
                    isobj3DataValueDisabled = true;
                }
                else if (lineNumber == 25 && columnNumber == 56)
                {
                    isobj4DataValueDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 93)
                {
                    isobj6SourceDisabled = true;
                }
                else if (lineNumber == 55 && columnNumber == 99)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 55 && columnNumber == 160)
                {
                    isobj8ToolTipDisabled = true;
                }
                else if (lineNumber == 56 && columnNumber == 121)
                {
                    isobj9TextDisabled = true;
                }
                else if (lineNumber == 56 && columnNumber == 185)
                {
                    isobj9ToolTipDisabled = true;
                }
                else if (lineNumber == 57 && columnNumber == 122)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 57 && columnNumber == 186)
                {
                    isobj10ToolTipDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 90)
                {
                    isobj16TextDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 180)
                {
                    isobj16ToolTipDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 85)
                {
                    isobj17TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // OrgUserControl.xaml line 35
                        this.obj3 = (global::OrganizationUser.StatusComparisonTrigger)target;
                        break;
                    case 4: // OrgUserControl.xaml line 25
                        this.obj4 = (global::OrganizationUser.StatusComparisonTrigger)target;
                        break;
                    case 6: // OrgUserControl.xaml line 44
                        this.obj6 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 8: // OrgUserControl.xaml line 55
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 9: // OrgUserControl.xaml line 56
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // OrgUserControl.xaml line 57
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 16: // OrgUserControl.xaml line 51
                        this.obj16 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 17: // OrgUserControl.xaml line 53
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IOrgUserControl_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::OrganizationUser.OrgUserControl)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::OrganizationUser.OrgUserControl obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_People(obj.People, phase);
                    }
                }
            }
            private void Update_People(global::OrganizationUser.Model.People obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_People_CheckinStatus_Text(obj.CheckinStatus_Text, phase);
                        this.Update_People_ImageUrl(obj.ImageUrl, phase);
                        this.Update_People_Email_id(obj.Email_id, phase);
                        this.Update_People_Depart(obj.Depart, phase);
                        this.Update_People_Design(obj.Design, phase);
                        this.Update_People_Fullname(obj.Fullname, phase);
                    }
                }
            }
            private void Update_People_CheckinStatus_Text(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 53
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // OrgUserControl.xaml line 35
                    if (!isobj3DataValueDisabled)
                    {
                        XamlBindingSetters.Set_OrganizationUser_StatusComparisonTrigger_DataValue(this.obj3, obj, null);
                    }
                    // OrgUserControl.xaml line 25
                    if (!isobj4DataValueDisabled)
                    {
                        XamlBindingSetters.Set_OrganizationUser_StatusComparisonTrigger_DataValue(this.obj4, obj, null);
                    }
                }
            }
            private void Update_People_ImageUrl(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 44
                    if (!isobj6SourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj6, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
            private void Update_People_Email_id(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 55
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, obj, null);
                    }
                    // OrgUserControl.xaml line 55
                    if (!isobj8ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj8, obj, null);
                    }
                }
            }
            private void Update_People_Depart(global::OrganizationUser.Model.Department obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_People_Depart_Name(obj.Name, phase);
                    }
                }
            }
            private void Update_People_Depart_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 56
                    if (!isobj9TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj9, obj, null);
                    }
                    // OrgUserControl.xaml line 56
                    if (!isobj9ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj9, obj, null);
                    }
                }
            }
            private void Update_People_Design(global::OrganizationUser.Model.Designation obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_People_Design_Name(obj.Name, phase);
                    }
                }
            }
            private void Update_People_Design_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 57
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                    }
                    // OrgUserControl.xaml line 57
                    if (!isobj10ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj10, obj, null);
                    }
                }
            }
            private void Update_People_Fullname(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 51
                    if (!isobj16TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj16, obj, null);
                    }
                    // OrgUserControl.xaml line 51
                    if (!isobj16ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj16, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class OrgUserControl_obj1_BindingsTracking
            {
                private global::System.WeakReference<OrgUserControl_obj1_Bindings> weakRefToBindingObj; 

                public OrgUserControl_obj1_BindingsTracking(OrgUserControl_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<OrgUserControl_obj1_Bindings>(obj);
                }

                public OrgUserControl_obj1_Bindings TryGetBindingObject()
                {
                    OrgUserControl_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // OrgUserControl.xaml line 13
                {
                    this.AllUserDataGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.AllUserDataGrid).PointerEntered += this.AllUserDataGrid_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.AllUserDataGrid).PointerExited += this.AllUserDataGrid_PointerExited;
                }
                break;
            case 5: // OrgUserControl.xaml line 43
                {
                    global::Windows.UI.Xaml.Shapes.Rectangle element5 = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                    ((global::Windows.UI.Xaml.Shapes.Rectangle)element5).Tapped += this.AllUserDataGrid_Tapped;
                }
                break;
            case 6: // OrgUserControl.xaml line 44
                {
                    global::Windows.UI.Xaml.Controls.Image element6 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element6).Tapped += this.AllUserDataGrid_Tapped;
                }
                break;
            case 7: // OrgUserControl.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.Grid element7 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)element7).Tapped += this.AllUserDataGrid_Tapped;
                }
                break;
            case 8: // OrgUserControl.xaml line 55
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element8 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element8).Tapped += this.AllUserDataGrid_Tapped;
                }
                break;
            case 9: // OrgUserControl.xaml line 56
                {
                    this.DepartmentText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // OrgUserControl.xaml line 57
                {
                    this.DesignationText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // OrgUserControl.xaml line 58
                {
                    this.TaskStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 12: // OrgUserControl.xaml line 59
                {
                    this.CallButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 13: // OrgUserControl.xaml line 60
                {
                    this.VideoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 14: // OrgUserControl.xaml line 61
                {
                    this.MessageButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 15: // OrgUserControl.xaml line 62
                {
                    this.InfoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.InfoButton).Click += this.InfoButton_Click;
                }
                break;
            case 17: // OrgUserControl.xaml line 53
                {
                    this.StatusText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // OrgUserControl.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)target;
                    OrgUserControl_obj1_Bindings bindings = new OrgUserControl_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
