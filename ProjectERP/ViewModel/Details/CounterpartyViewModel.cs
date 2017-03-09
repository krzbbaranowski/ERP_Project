using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Services;

namespace ProjectERP.ViewModel.Details
{
    public class CounterpartyViewModel : ViewModelBase, IContentView
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();

        public CounterpartyViewModel()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; private set; }
      

        public void Init(Counterparty counterparty)
        {
            //TODO Przemyśleć sprawę dla nowego kontrahenta(nulle) - fabryka
            try
            {
                _counterparty = counterparty;
                Name1 = _counterparty.Name1;
                Name2 = _counterparty.Name2;
                Name3 = _counterparty.Name3;
                Code = _counterparty.Code;
                PESEL = _counterparty.PESEL;
                REGON = _counterparty.REGON;
                NIP = _counterparty.NIP;

                //Dane teleadresowe
                Street = counterparty.Address.Street;
                House = counterparty.Address.House;
                Flat = counterparty.Address.Flat;
                PostalCode = counterparty.Address.PostalCode;
                City = counterparty.Address.City;
                Telephone = counterparty.Address.Telephone;
                Telephone2 = counterparty.Address.Telephone2;
                Email = counterparty.Address.Email;
                Fax = counterparty.Address.Fax;
                Url = counterparty.Address.Url;
                Province = counterparty.Address.Province.Name;
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        #region Model properties

        public string Name1
        {
            get { return _counterpartyName; }
            set { Set(Name1PropertyName, ref _counterpartyName, value); }
        }

        public string Name3
        {
            get { return _name3; }
            set { Set(Name3PropertyName, ref _name3, value); }
        }

        public string Code
        {
            get { return _code; }
            set { Set(CodePropertyName, ref _code, value); }
        }

        public string NIP
        {
            get { return _nip; }
            set { Set(NipPropertyName, ref _nip, value); }
        }

        public string PESEL
        {
            get { return _pesel; }
            set { Set(PeselPropertyName, ref _pesel, value); }
        }

        public string REGON
        {
            get { return _regon; }
            set { Set(RegonPropertyName, ref _regon, value); }
        }

        public string Name2
        {
            get { return _name2; }
            set { Set(Name2PropertyName, ref _name2, value); }
        }

        public string Street
        {
            get { return _street; }

            set
            {
                if (_street == value)
                    return;

                _street = value;
                RaisePropertyChanged(StreetPropertyName);
            }
        }

        public int House
        {
            get { return _house; }

            set
            {
                if (_house == value)
                    return;

                _house = value;
                RaisePropertyChanged(HousePropertyName);
            }
        }

        public int Flat
        {
            get { return _flat; }

            set
            {
                if (_flat == value)
                    return;

                _flat = value;
                RaisePropertyChanged(FlatPropertyName);
            }
        }

        public string PostalCode
        {
            get { return _postalCode; }

            set
            {
                if (_postalCode == value)
                    return;

                _postalCode = value;
                RaisePropertyChanged(PostalCodePropertyName);
            }
        }

        public string City
        {
            get { return _city; }

            set
            {
                if (_city == value)
                    return;

                _city = value;
                RaisePropertyChanged(CityPropertyName);
            }
        }

        public string Telephone
        {
            get { return _telephone; }

            set
            {
                if (_telephone == value)
                    return;

                _telephone = value;
                RaisePropertyChanged(TelephonePropertyName);
            }
        }

        public string Telephone2
        {
            get { return _telephone2; }

            set
            {
                if (_telephone2 == value)
                    return;

                _telephone2 = value;
                RaisePropertyChanged(Telephone2PropertyName);
            }
        }

        public string Email
        {
            get { return _email; }

            set
            {
                if (_email == value)
                    return;

                _email = value;
                RaisePropertyChanged(EmailPropertyName);
            }
        }

        public string Fax
        {
            get { return _fax; }

            set
            {
                if (_fax == value)
                    return;

                _fax = value;
                RaisePropertyChanged(FaxPropertyName);
            }
        }

        public string Url
        {
            get { return _url; }

            set
            {
                if (_url == value)
                    return;

                _url = value;
                RaisePropertyChanged(UrlPropertyName);
            }
        }

        public string Province
        {
            get { return _province; }

            set
            {
                if (_province == value)
                    return;

                _province = value;
                RaisePropertyChanged(ProvincePropertyName);
            }
        }

        #endregion

        #region Properties Names

        public const string Name1PropertyName = "Name1";

        public const string Name3PropertyName = "Name3";

        public const string CodePropertyName = "Code";

        public const string NipPropertyName = "NIP";

        public const string PeselPropertyName = "PESEL";

        public const string RegonPropertyName = "REGON";

        public const string Name2PropertyName = "Name2";


        public const string StreetPropertyName = "Street";

        public const string HousePropertyName = "House";

        public const string FlatPropertyName = "Flat";

        public const string PostalCodePropertyName = "PostalCode";

        public const string CityPropertyName = "City";

        public const string TelephonePropertyName = "Telephone";

        public const string Telephone2PropertyName = "Telephone2";

        public const string EmailPropertyName = "Email";

        public const string FaxPropertyName = "Fax";

        public const string UrlPropertyName = "Url";

        public const string ProvincePropertyName = "Province";

        #endregion

        #region Private model fields

        private Counterparty _counterparty;
        private string _city;
        private string _code;
        private string _counterpartyName;
        private string _email;
        private string _fax;
        private int _flat;
        private int _house;
        private string _name2;
        private string _name3;
        private string _nip;
        private string _pesel;
        private string _postalCode;
        private string _province;
        private string _regon;
        private string _street;
        private string _telephone;
        private string _telephone2;
        private string _url;
        public bool CanAddItem => false;
        public bool CanDeleteItem => false;

        #endregion
    }
}