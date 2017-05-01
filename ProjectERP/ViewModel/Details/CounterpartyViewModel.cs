using System;
using AutoMapper;
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

namespace ProjectERP.ViewModel.Details
{
    public class CounterpartyViewModel : ViewModelBase, IMainTabDetailsItem
    {
        private readonly ICounterpartyRepository _counterpartyRepository;


        private RelayCommand _saveItemCommand;

        public CounterpartyViewModel(ICounterpartyRepository counterpartyRepository)
        {
            _counterpartyRepository = counterpartyRepository;
            
        }

        public RelayCommand CloseCommand => _closeCommand
                                            ?? (_closeCommand = new RelayCommand(
                                                () =>
                                                {
                                                    var newItemMessage = new MainTabItemMessage
                                                    {
                                                        MainTabItem = this
                                                    };

                                                    Messenger.Default.Send(newItemMessage, MessengerTokens.CloseTab);
                                                }));


        public RelayCommand SaveItemCommand => _saveItemCommand
                                               ?? (_saveItemCommand = new RelayCommand(
                                                   () =>
                                                   {
                                                       var config = new MapperConfiguration(cfg =>
                                                       {
                                                           cfg.CreateMap<CounterpartyViewModel, Address>();
                                                           cfg.CreateMap<CounterpartyViewModel, Counterparty>();
                                                       });

                                                       var mapper = config.CreateMapper();

                                                       if (_dbCounterparty == null)
                                                           _dbCounterparty = new Counterparty
                                                           {
                                                               Address = new Address()
                                                           };

                                                       mapper.Map(this,
                                                           _dbCounterparty.Address);

                                                       mapper.Map(this,
                                                           _dbCounterparty);

                                                       if (_isNew)
                                                           _counterpartyRepository.Add(_dbCounterparty);
                                                       else
                                                           _counterpartyRepository.Update(_dbCounterparty);

                                                       _counterpartyRepository.Save();
                                                   }));

        public void Initialize(int entityId)
        {
            _isNew = false;
            _dbCounterparty = _counterpartyRepository.GetById(entityId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Counterparty, CounterpartyViewModel>();
                cfg.CreateMap<Address, CounterpartyViewModel>();
            });

            var mapper = config.CreateMapper();

            mapper.Map(_dbCounterparty, this);
            mapper.Map(_dbCounterparty.Address, this);

            Header = $"{AppDictionary.Instance.GetString("StringLocs","Counterparty")} {Code}";
        }

       

        #region Model properties

        public string Name1
        {
            get { return _name1; }
            set { Set(nameof(Name1), ref _name1, value); }
        }

        public string Name3
        {
            get { return _name3; }
            set { Set(nameof(Name3), ref _name3, value); }
        }

        public string Code
        {
            get { return _code; }
            set { Set(nameof(Code), ref _code, value); }
        }

        public string Nip
        {
            get { return _nip; }
            set { Set(nameof(Nip), ref _nip, value); }
        }

        public string Pesel
        {
            get { return _pesel; }
            set { Set(nameof(Pesel), ref _pesel, value); }
        }

        public string Regon
        {
            get { return _regon; }
            set { Set(nameof(Regon), ref _regon, value); }
        }

        public string Name2
        {
            get { return _name2; }
            set { Set(nameof(Name2), ref _name2, value); }
        }

        public string Street
        {
            get { return _street; }

            set { Set(nameof(Street), ref _street, value); }
        }

        public int House
        {
            get { return _house; }

            set { Set(nameof(House), ref _house, value); }
        }

        public int Flat
        {
            get { return _flat; }

            set { Set(nameof(Flat), ref _flat, value); }
        }

        public string PostalCode
        {
            get { return _postalCode; }

            set { Set(nameof(PostalCode), ref _postalCode, value); }
        }

        public string City
        {
            get { return _city; }

            set { Set(nameof(City), ref _city, value); }
        }

        public string Telephone
        {
            get { return _telephone; }

            set { Set(nameof(Telephone), ref _telephone, value); }
        }

        public string Telephone2
        {
            get { return _telephone2; }

            set { Set(nameof(Telephone2), ref _telephone2, value); }
        }

        public string Email
        {
            get { return _email; }

            set { Set(nameof(Email), ref _email, value); }
        }

        public string Fax
        {
            get { return _fax; }

            set { Set(nameof(Fax), ref _fax, value); }
        }

        public string Url
        {
            get { return _url; }

            set { Set(nameof(Street), ref _url, value); }
        }

        public string Province
        {
            get { return _province; }

            set { Set(nameof(Province), ref _province, value); }
        }

        #endregion

        #region Private model fields

        private string _city = string.Empty;
        private string _code = string.Empty;
        private string _name1 = string.Empty;
        private string _email = string.Empty;
        private string _fax = string.Empty;
        private int _flat;
        private int _house;
        private string _name2 = string.Empty;
        private string _name3 = string.Empty;
        private string _nip = string.Empty;
        private string _pesel = string.Empty;
        private string _postalCode = string.Empty;
        private string _province = string.Empty;
        private string _regon = string.Empty;
        private string _street = string.Empty;
        private string _telephone = string.Empty;
        private string _telephone2 = string.Empty;
        private string _url = string.Empty;
        private Counterparty _dbCounterparty;
        private bool _isNew = true;
        private RelayCommand _closeCommand;


        public string Header { get; set; }
        public bool IsMultiply { get; set; } = true;

        #endregion
    }
}