using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.Database;
using ProjectERP.ViewModel.Controls.MainTab;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Tables;
using ProjectERP.Views.Details;

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
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MainTabViewModel MainTabControl => ServiceLocator.Current.GetInstance<MainTabViewModel>();

        public CounterpartyTableViewModel CounterpartyTable
            => ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();


        public static CounterpartyView CreateCounterpartyView(Counterparty counterparty, bool newContent)
        {
            //return ServiceLocator.Current.GetInstance<CounterpartyView>(Guid.NewGuid().ToString());

            var uniqueKey = Guid.NewGuid().ToString();
            var counterpartyViewModel = SimpleIoc.Default.GetInstance<CounterpartyViewModel>(uniqueKey);
            counterpartyViewModel.Init(counterparty, newContent);

            var counterpartyView = new CounterpartyView
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