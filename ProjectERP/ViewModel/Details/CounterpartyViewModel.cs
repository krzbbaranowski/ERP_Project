using AutoMapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;
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

        public RelayCommand SaveItemCommand => _saveItemCommand
                                               ?? (_saveItemCommand = new RelayCommand(
                                                   () =>
                                                   {
                                                       var config = new MapperConfiguration(cfg => {
                                                           cfg.CreateMap<CounterpartyViewModel, Counterparty>();

                                                       });

                                                       IMapper mapper = config.CreateMapper();
                                                       mapper.Map<CounterpartyViewModel, Counterparty>(this, _dbCounterparty);

                                                       _counterpartyRepository.Update(_dbCounterparty);
                                                       _counterpartyRepository.Save();
                                                   }));

        public void Initialize(int entityId)
        {
            _dbCounterparty = _counterpartyRepository.GetById(entityId);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Counterparty, CounterpartyViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            mapper.Map<Counterparty, CounterpartyViewModel>(_dbCounterparty, this);
        }

        public void DeleteToDatabase()
        {
            // var dbEnity = _erpDatabase.
        }

       
        
        #region Model properties

        public string Name1
        {
            get { return _counterpartyName; }
            set { Set(nameof(Name1), ref _counterpartyName, value); }
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

        public string NIP
        {
            get { return _nip; }
            set { Set(nameof(NIP), ref _nip, value); }
        }

        public string PESEL
        {
            get { return _pesel; }
            set { Set(nameof(PESEL), ref _pesel, value); }
        }

        public string REGON
        {
            get { return _regon; }
            set { Set(nameof(REGON), ref _regon, value); }
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
        private string _counterpartyName = string.Empty;
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


        public string Header { get; set; } = "Kontrahent";
        public bool IsMultiply { get; set; } = true;

        #endregion
    }
}