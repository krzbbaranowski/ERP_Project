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

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.Database;
using ProjectERP.ViewModel.Counterparties;
using ProjectERP.ViewModel.UiControls;
using System;
using ProjectERP.Views;
using System.Diagnostics.CodeAnalysis;

namespace ProjectERP.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CounterpartyTableModelView>();
            SimpleIoc.Default.Register<MainTabControlModelView>();
            SimpleIoc.Default.Register<CounterpartyViewModel>();
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

        public MainTabControlModelView MainTabControl
        {
            get { return ServiceLocator.Current.GetInstance<MainTabControlModelView>(); }
        }

        public CounterpartyTableModelView CounterpartyTable
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CounterpartyTableModelView>();
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