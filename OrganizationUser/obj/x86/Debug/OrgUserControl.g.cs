﻿#pragma checksum "D:\Organization\OrganizationUser\OrganizationUser\OrgUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67FCCFD6A4B9B8E29B73E51E6436D74148029171A2C01F022710C9F023306AD2"
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
            private global::OrganizationUser.StatusComparisonTrigger obj5;
            private global::OrganizationUser.StatusComparisonTrigger obj6;
            private global::Windows.UI.Xaml.Controls.Image obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;
            private global::Windows.UI.Xaml.Controls.TextBlock obj19;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj5DataValueDisabled = false;
            private static bool isobj6DataValueDisabled = false;
            private static bool isobj8SourceDisabled = false;
            private static bool isobj10TextDisabled = false;
            private static bool isobj10ToolTipDisabled = false;
            private static bool isobj11TextDisabled = false;
            private static bool isobj11ToolTipDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj12ToolTipDisabled = false;
            private static bool isobj18TextDisabled = false;
            private static bool isobj18ToolTipDisabled = false;
            private static bool isobj19TextDisabled = false;

            private OrgUserControl_obj1_BindingsTracking bindingsTracking;

            public OrgUserControl_obj1_Bindings()
            {
                this.bindingsTracking = new OrgUserControl_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 42 && columnNumber == 56)
                {
                    isobj5DataValueDisabled = true;
                }
                else if (lineNumber == 32 && columnNumber == 56)
                {
                    isobj6DataValueDisabled = true;
                }
                else if (lineNumber == 71 && columnNumber == 116)
                {
                    isobj8SourceDisabled = true;
                }
                else if (lineNumber == 82 && columnNumber == 120)
                {
                    isobj10TextDisabled = true;
                }
                else if (lineNumber == 82 && columnNumber == 183)
                {
                    isobj10ToolTipDisabled = true;
                }
                else if (lineNumber == 83 && columnNumber == 121)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 83 && columnNumber == 187)
                {
                    isobj11ToolTipDisabled = true;
                }
                else if (lineNumber == 84 && columnNumber == 122)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 84 && columnNumber == 188)
                {
                    isobj12ToolTipDisabled = true;
                }
                else if (lineNumber == 78 && columnNumber == 90)
                {
                    isobj18TextDisabled = true;
                }
                else if (lineNumber == 78 && columnNumber == 180)
                {
                    isobj18ToolTipDisabled = true;
                }
                else if (lineNumber == 80 && columnNumber == 85)
                {
                    isobj19TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 5: // OrgUserControl.xaml line 42
                        this.obj5 = (global::OrganizationUser.StatusComparisonTrigger)target;
                        break;
                    case 6: // OrgUserControl.xaml line 32
                        this.obj6 = (global::OrganizationUser.StatusComparisonTrigger)target;
                        break;
                    case 8: // OrgUserControl.xaml line 71
                        this.obj8 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 10: // OrgUserControl.xaml line 82
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 11: // OrgUserControl.xaml line 83
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // OrgUserControl.xaml line 84
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18: // OrgUserControl.xaml line 78
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 19: // OrgUserControl.xaml line 80
                        this.obj19 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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
                    // OrgUserControl.xaml line 80
                    if (!isobj19TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // OrgUserControl.xaml line 42
                    if (!isobj5DataValueDisabled)
                    {
                        XamlBindingSetters.Set_OrganizationUser_StatusComparisonTrigger_DataValue(this.obj5, obj, null);
                    }
                    // OrgUserControl.xaml line 32
                    if (!isobj6DataValueDisabled)
                    {
                        XamlBindingSetters.Set_OrganizationUser_StatusComparisonTrigger_DataValue(this.obj6, obj, null);
                    }
                }
            }
            private void Update_People_ImageUrl(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 71
                    if (!isobj8SourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj8, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
            private void Update_People_Email_id(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 82
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
                    }
                    // OrgUserControl.xaml line 82
                    if (!isobj10ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj10, obj, null);
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
                    // OrgUserControl.xaml line 83
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                    // OrgUserControl.xaml line 83
                    if (!isobj11ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj11, obj, null);
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
                    // OrgUserControl.xaml line 84
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                    // OrgUserControl.xaml line 84
                    if (!isobj12ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj12, obj, null);
                    }
                }
            }
            private void Update_People_Fullname(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // OrgUserControl.xaml line 78
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj, null);
                    }
                    // OrgUserControl.xaml line 78
                    if (!isobj18ToolTipDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ToolTipService_ToolTip(this.obj18, obj, null);
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
            case 2: // OrgUserControl.xaml line 20
                {
                    this.AllUserDataGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)this.AllUserDataGrid).PointerEntered += this.AllUserDataGrid_PointerEntered;
                    ((global::Windows.UI.Xaml.Controls.Grid)this.AllUserDataGrid).PointerExited += this.AllUserDataGrid_PointerExited;
                }
                break;
            case 3: // OrgUserControl.xaml line 50
                {
                    this.NarrowWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4: // OrgUserControl.xaml line 59
                {
                    this.WiderWindow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 7: // OrgUserControl.xaml line 70
                {
                    this.TransRectangle = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 8: // OrgUserControl.xaml line 71
                {
                    this.EmployeeImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9: // OrgUserControl.xaml line 72
                {
                    this.DataGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 10: // OrgUserControl.xaml line 82
                {
                    this.EmailIDText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // OrgUserControl.xaml line 83
                {
                    this.DepartmentText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // OrgUserControl.xaml line 84
                {
                    this.DesignationText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // OrgUserControl.xaml line 85
                {
                    this.TaskStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 14: // OrgUserControl.xaml line 86
                {
                    this.CallButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 15: // OrgUserControl.xaml line 87
                {
                    this.VideoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 16: // OrgUserControl.xaml line 88
                {
                    this.MessageButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 17: // OrgUserControl.xaml line 89
                {
                    this.InfoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.InfoButton).Click += this.InfoButton_Click;
                }
                break;
            case 19: // OrgUserControl.xaml line 80
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
