/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ProjectERP"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.Database;
using ProjectERP.ViewModel.Controls.MainTab;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Tables;
using CounterpartyView = ProjectERP.Views.Details.CounterpartyView;

namespace ProjectERP.ViewModel.MVVMLight
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CounterpartyTableViewModel>();
            SimpleIoc.Default.Register<MainTabViewModel>();
            SimpleIoc.Default.Register<CounterpartyViewModel>();
            SimpleIoc.Default.Register<MainTabContentViewModel>();
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainTabViewModel MainTabControl
        {
            get { return ServiceLocator.Current.GetInstance<MainTabViewModel>(); }
        }

        public CounterpartyTableViewModel CounterpartyTable
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();
            }
        }

        public static CounterpartyView CreateCounterpartyView(Counterparty counterparty)
        {
            var uniqueKey = Guid.NewGuid().ToString();
            var counterpartyViewModel = SimpleIoc.Default.GetInstance<CounterpartyViewModel>(uniqueKey);
            counterpartyViewModel.Init(counterparty);

            var counterpartyView = new CounterpartyView()
            {
                DataContext = counterpartyViewModel
            };

            return counterpartyView;
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}