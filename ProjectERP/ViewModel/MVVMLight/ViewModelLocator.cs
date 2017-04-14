using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.Database;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository;
using ProjectERP.Model.Repository.Interfaces;
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

            SimpleIoc.Default.Register<ICounterpartyRepository, CounterpartyRepository>();
            SimpleIoc.Default.Register<IErpDatabaseContext, ErpDatabaseEntities>();


            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainTabViewModel>();
         
            SimpleIoc.Default.Register<CounterpartyViewModel>();
            SimpleIoc.Default.Register<CounterpartyTableViewModel>();
        }


        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MainTabViewModel MainTabControl => ServiceLocator.Current.GetInstance<MainTabViewModel>();

        public CounterpartyTableViewModel CounterpartyTable
            => ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}