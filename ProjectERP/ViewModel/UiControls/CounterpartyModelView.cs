#region

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Database;
using ProjectERP.Model.Messages;
using ProjectERP.Services;

#endregion

namespace ProjectERP.ViewModel
{
    public class CounterpartyModelView : ViewModelBase
    {
        private RelayCommand<UserControl> _closeCommand;

        public CounterpartyModelView()
        {
            var db = ConnectionHelper.CreateConnection();

            var list = from cp in db.Counterparty
                select cp;

            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; }

        /// <summary>
        ///     Gets the MyCommand.
        /// </summary>
        public RelayCommand<UserControl> CloseCommand
        {
            get
            {
                return _closeCommand
                       ?? (_closeCommand = new RelayCommand<UserControl>(
                           userControl =>
                           {
                               Messenger.Default.Send(new RemoveMainTabItemMessage
                               {
                                   Content = userControl
                               });
                           }));
            }
        }
    }
}