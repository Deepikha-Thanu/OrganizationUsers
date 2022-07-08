﻿using OrganizationUser.Manager;
using OrganizationUser.Model;
using OrganizationUser.Usecase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace OrganizationUser.ViewModel
{
    public class PeopleDataUserControlViewModel : INotifyPropertyChanged
    {
        public BusinessPeopleModel _EmployeeToShow;
        public BusinessPeopleModel EmployeeToShow
        {
            get { return _EmployeeToShow; }
            set
            {
                _EmployeeToShow = value;
                RaisePropertyChanged("EmployeeToShow");
            }
        }

        //internal EventManager NotifyInstance { get => _NotifyInstance; set => _NotifyInstance = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void ChangeEmployeeToShow()
        {
            if(EmployeeToShow.ReportingToId!=1)
            { 
                RequestEmployeeChange request = new RequestEmployeeChange();
                ICallBack presenterCallBack = new PresenterCallBack(this);
                request.EmployeeId = EmployeeToShow.ReportingToId;
                new GetEmployeeWithId(presenterCallBack,request).Execute();
            }
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string message)
        {
            throw new NotImplementedException();
        }
        private class PresenterCallBack :ICallBack
        {
            public PeopleDataUserControlViewModel viewModel;
            public PresenterCallBack(PeopleDataUserControlViewModel obj)
            {
                viewModel = obj;
            }

            public void OnError()
            {
                throw new NotImplementedException();
            }

            public void OnFailure(string message)
            {
                throw new NotImplementedException();
            }

            public async void OnSuccess<T>(T response)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                 {
                     viewModel.EmployeeToShow = (response as ResponseEmployeeChange).EmployeeFromId;
                 });
            }
        }
    }
}
