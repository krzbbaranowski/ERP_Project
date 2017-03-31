using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Interfaces;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;

namespace ProjectERP.ViewModel.Toolbar
{
    public class ViewsManagmentToolbarViewModel : ViewModelBase
    {
        private const string AddButtonVisiblePropertyName = "AddButtonVisible";
        private const string DeleteButtonVisiblePropertyName = "DeleteButtonVisible";
        private const string SaveButtonVisiblePropertyName = "SaveButtonVisible";

        private bool _addButtonVisible;

        private RelayCommand _addItemCommand;
        private IContentView _currentActiveTab;

        private bool _deleteButtonVisible;

        private RelayCommand<MainTabItem> _deleteItemCommand;

        public bool _saveButtonVisible;


        private RelayCommand _saveItemCommand;

        public ViewsManagmentToolbarViewModel()
        {
            Messenger.Default.Register<ContentViewMessage>(this, SetCurrentContentView);
        }

        public bool AddButtonVisible
        {
            get { return _addButtonVisible; }
            private set { Set(AddButtonVisiblePropertyName, ref _addButtonVisible, value); }
        }

        public bool DeleteButtonVisible
        {
            get { return _deleteButtonVisible; }
            private set { Set(DeleteButtonVisiblePropertyName, ref _deleteButtonVisible, value); }
        }

        public bool SaveButtonVisible
        {
            get { return _saveButtonVisible; }
            private set { Set(SaveButtonVisiblePropertyName, ref _saveButtonVisible, value); }
        }

        public RelayCommand SaveItemCommand
        {
            get
            {
                return _saveItemCommand
                       ?? (_saveItemCommand = new RelayCommand(
                           () => { _currentActiveTab.AddToDatabase(); }));
            }
        }

        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand
                       ?? (_addItemCommand = new RelayCommand(
                           () =>
                           {
                               var newItem =
                                   TabItemFactory.CreateClearMainTabItem(
                                       TabNameFactory.GeTabNameByType(TabName.CounterpartyTab));
                               var newItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = newItem,
                                   IsNewContent = true
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public RelayCommand<MainTabItem> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand
                       ?? (_deleteItemCommand = new RelayCommand<MainTabItem>(
                           tab => { }));
            }
        }

        private void SetCurrentContentView(ContentViewMessage contentViewMessage)
        {
            _currentActiveTab = contentViewMessage.ContentView;

            AddButtonVisible = _currentActiveTab.CanAddItem;
            DeleteButtonVisible = _currentActiveTab.CanDeleteItem;
            SaveButtonVisible = _currentActiveTab.CanSaveItem;
        }
    }
}