/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dev2.Common.Interfaces;
using Dev2.Studio.Interfaces.DataList;
using Dev2.Studio.ViewModels.WorkSurface;
using Microsoft.Practices.Prism.Mvvm;
using Dev2.Instrumentation;
using Dev2.Instrumentation.Factory;

namespace Dev2.Studio.Views.DataList
{
    /// <summary>
    /// Interaction logic for DataListView.xaml
    /// </summary>
    public partial class DataListView : IView,ICheckControlEnabledView
    {
        private IApplicationTracker _applicationTracker;
        public DataListView()
        {
            InitializeComponent();
            _applicationTracker = ApplicationTrackerFactory.GetApplicationTrackerProvider();
            KeyboardNavigation.SetTabNavigation(ScalarExplorer, KeyboardNavigationMode.Cycle);
        }

        #region Events

        private void NametxtTextChanged(object sender, RoutedEventArgs e)
        {
            IDataListViewModel vm = DataContext as IDataListViewModel;
            if(vm != null)
            {
                TextBox txtbox = sender as TextBox;
                IDataListItemModel itemThatChanged = txtbox?.DataContext as IDataListItemModel;
                if (itemThatChanged != null)
                {
                    itemThatChanged.IsExpanded = true;
                }
                vm.AddBlankRow(null);
            }
        }

        private void Inputcbx_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null || !checkBox.IsEnabled)
            {
                return;
            }
            _applicationTracker.TrackApplicationEvent(ApplicationTrackerConstants.TrackerEventName.VariablesInputClicked);
            WriteToResourceModel();
        }

        private void Outputcbx_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null || !checkBox.IsEnabled)
            {
                return;
            }
            _applicationTracker.TrackApplicationEvent(ApplicationTrackerConstants.TrackerEventName.VariablesOutputClicked);
            WriteToResourceModel();
        }

        private void NametxtFocusLost(object sender, RoutedEventArgs e)
        {
            DoDataListValidation(sender);
        }

        void DoDataListValidation(object sender)
        {
            IDataListViewModel vm = DataContext as IDataListViewModel;
            if(vm != null)
            {
                TextBox txtbox = sender as TextBox;
                if(txtbox != null)
                {
                    IDataListItemModel itemThatChanged = txtbox.DataContext as IDataListItemModel;
                    vm.RemoveBlankRows(itemThatChanged);
                    vm.ValidateNames(itemThatChanged);
                    // code to log errors to revulytics
                    if (vm.HasErrors && vm.DataListErrorMessage.Length!=0)
                    {
                        _applicationTracker.TrackCustomEvent(ApplicationTrackerConstants.TrackerEventGroup.VariablesUsed, ApplicationTrackerConstants.TrackerEventName.RedBracketsSyntax, vm.DataListErrorMessage);

                    }
                }
            }
        }

        private void UserControlLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            WriteToResourceModel();
        }

        #endregion Events

        #region Private Methods

        private void WriteToResourceModel()
        {
            IDataListViewModel vm = DataContext as IDataListViewModel;
            if (vm != null && !vm.IsSorting)
            {
                vm.WriteToResourceModel();
            }
        }

        #endregion Private Methods

        private void UIElement_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var vm = DataContext as IDataListViewModel;
            var model = vm?.Parent as WorkSurfaceContextViewModel;
            model?.FindMissing();
        }

        #region Implementation of ICheckControlEnabledView

        public bool GetControlEnabled(string controlName)
        {
            switch (controlName)
            {
                case "Delete Variables":
                    return DeleteButton.Command.CanExecute(null);
                case "Sort Variables":
                    return SortButton.Command.CanExecute(null);
                case "Variables":
                    return ScalarExplorer.IsEnabled;
            }
            
            return false;
        }

        #endregion
    }
}
