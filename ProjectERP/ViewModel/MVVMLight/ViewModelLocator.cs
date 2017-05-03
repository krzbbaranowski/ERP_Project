using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.Database;
using ProjectERP.Model.Database.Interfaces;
using ProjectERP.Model.Repository;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.ViewModel.Controls.MainTab;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Tables;
using System;
using ProjectERP.ViewModel.Settings;

namespace ProjectERP.ViewModel.MVVMLight
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ICounterpartyRepository, CounterpartyRepository>();
            SimpleIoc.Default.Register<ITaxRepository, TaxRepository>();
            SimpleIoc.Default.Register<IArticleTypeRepository, ArticleTypeRepository>();
            SimpleIoc.Default.Register<IArticleRepository, ArticleRepository>();
            SimpleIoc.Default.Register<IMeasureRepository, MeasureRepository>();
            SimpleIoc.Default.Register<IArticlePriceTypeRepository, ArticlePriceTypeRepository>();

            SimpleIoc.Default.Register<IErpDatabaseContext, ErpDatabaseEntities>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainTabViewModel>();
         
            SimpleIoc.Default.Register<CounterpartyViewModel>();
            SimpleIoc.Default.Register<ArticleViewModel>();

            SimpleIoc.Default.Register<CounterpartyTableViewModel>();
            SimpleIoc.Default.Register<ArticleTableViewModel>();

            SimpleIoc.Default.Register<SettingsDictionariesViewModel>();
        }


        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MainTabViewModel MainTabControl => ServiceLocator.Current.GetInstance<MainTabViewModel>();

        public CounterpartyTableViewModel CounterpartyTable
            => ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();

        public ArticleTableViewModel ArticleTable
            => ServiceLocator.Current.GetInstance<ArticleTableViewModel>();

        public SettingsDictionariesViewModel SettingsDictionaries
            => ServiceLocator.Current.GetInstance<SettingsDictionariesViewModel>();

        public ArticleViewModel ArticleView
            => ServiceLocator.Current.GetInstance<ArticleViewModel>(Guid.NewGuid().ToString());

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}