using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Messages;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.Services;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Interfaces;

namespace ProjectERP.ViewModel.Settings
{
    public class SettingsDictionariesViewModel : ViewModelBase, IUpdateView, IMainTabItem
    {
        private readonly IArticlePriceTypeRepository _priceTypeRepository;
        private RelayCommand<string> _addArticlePriceTypeCommand;

        public ObservableCollection<ArticlePriceType> ArticlePriceTypes { get; protected set; } =
            new ObservableCollection<ArticlePriceType>();

        public SettingsDictionariesViewModel(IArticlePriceTypeRepository priceTypeRepository)
        {
            _priceTypeRepository = priceTypeRepository;
            Header = $"{AppDictionary.Instance.GetString("StringLocs", "SettingsDictionariesHeader")}";

        }

        public RelayCommand<string> AddArticlePriceTypeCommand
        {
            get
            {
                return _addArticlePriceTypeCommand
                       ?? (_addArticlePriceTypeCommand = new RelayCommand<string>(
                           (name) =>
                           {
                               ArticlePriceType articlePriceType = new ArticlePriceType
                               {
                                   ArticlePriceName = name
                               };
                               _priceTypeRepository.Add(articlePriceType);
                               _priceTypeRepository.Save();

                               UpdateView();

                           }));
            }
        }


        public void UpdateView()
        {
            var articlePriceTypes = _priceTypeRepository.GetEntities();

            ArticlePriceTypes.Clear();

            foreach (var type in articlePriceTypes)
            {
                ArticlePriceTypes.Add(type);
            }
        }

        public string Header { get; set; } 
        public bool IsMultiply { get; set; } = false;
    }
}