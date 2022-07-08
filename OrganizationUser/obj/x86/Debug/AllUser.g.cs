﻿#pragma checksum "D:\OrganizationUsers\OrganizationUser\AllUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55F535F46FC7400F8A25A597E7A1DAA40DE0653BC2D2BEB0E254BE9AAB50F124"
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
    partial class AllUser : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class AllUser_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAllUser_Bindings
        {
            private global::OrganizationUser.AllUser dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj16;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj16ItemsSourceDisabled = false;

            private AllUser_obj1_BindingsTracking bindingsTracking;

            public AllUser_obj1_Bindings()
            {
                this.bindingsTracking = new AllUser_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 120 && columnNumber == 108)
                {
                    isobj16ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 16: // AllUser.xaml line 120
                        this.obj16 = (global::Windows.UI.Xaml.Controls.GridView)target;
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

            // IAllUser_Bindings

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
                    this.dataRoot = (global::OrganizationUser.AllUser)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::OrganizationUser.AllUser obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel(obj.viewModel, phase);
                    }
                }
            }
            private void Update_viewModel(global::OrganizationUser.ViewModel.AllUserViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_viewModel_Employees(obj.Employees, phase);
                    }
                }
            }
            private void Update_viewModel_Employees(global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_viewModel_Employees(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AllUser.xaml line 120
                    if (!isobj16ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj16, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class AllUser_obj1_BindingsTracking
            {
                private global::System.WeakReference<AllUser_obj1_Bindings> weakRefToBindingObj; 

                public AllUser_obj1_BindingsTracking(AllUser_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<AllUser_obj1_Bindings>(obj);
                }

                public AllUser_obj1_Bindings TryGetBindingObject()
                {
                    AllUser_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_viewModel_Employees(null);
                }

                public void PropertyChanged_viewModel_Employees(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    AllUser_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_viewModel_Employees(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    AllUser_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel> cache_viewModel_Employees = null;
                public void UpdateChildListeners_viewModel_Employees(global::System.Collections.ObjectModel.ObservableCollection<global::OrganizationUser.Model.BusinessPeopleModel> obj)
                {
                    if (obj != cache_viewModel_Employees)
                    {
                        if (cache_viewModel_Employees != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_viewModel_Employees).PropertyChanged -= PropertyChanged_viewModel_Employees;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_viewModel_Employees).CollectionChanged -= CollectionChanged_viewModel_Employees;
                            cache_viewModel_Employees = null;
                        }
                        if (obj != null)
                        {
                            cache_viewModel_Employees = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_viewModel_Employees;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_viewModel_Employees;
                        }
                    }
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
            case 15: // AllUser.xaml line 109
                {
                    this.SearchResult = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // AllUser.xaml line 120
                {
                    this.AllUserGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)this.AllUserGridView).ItemClick += this.AllUserGridView_ItemClick;
                }
                break;
            case 18: // AllUser.xaml line 128
                {
                    global::OrganizationUser.OrgUserControl element18 = (global::OrganizationUser.OrgUserControl)(target);
                    ((global::OrganizationUser.OrgUserControl)element18).InfoEmployeeClicked += this.OrgUsersUC_EmployeeClicked;
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
            case 1: // AllUser.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    AllUser_obj1_Bindings bindings = new AllUser_obj1_Bindings();
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

