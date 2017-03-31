using System.Collections.ObjectModel;
using System.Data.Entity;
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

        }

        public void DeleteToDatabase()
        {
          // var dbEnity = _erpDatabase.
        }

        public void AddToDatabase()
        {
            var counterparty = new Counterparty
            {
                Name1 = Name1,
                Name2 = Name2,
                Name3 = Name3,
                Code = Code,
                PESEL = PESEL,
                REGON = REGON,
                NIP = NIP,
                Address = new Address
                {
                    Street = Street,
                    House = House,
                    Flat = Flat,
                    PostalCode = PostalCode,
                    City = City,
                    Telephone = Telephone,
                    Telephone2 = Telephone2,
                    Email = Email,
                    Fax = Fax,
                    Url = Url,
                    Province = new Province
                    {
                        Name = Province
                    }
                }
            };

            if (_newContent)
            {
                _erpDatabase.Counterparty.Add(counterparty);
            }
            else
            {
                var dbFoo = _erpDatabase.Counterparty.
                    Include(x => x.Address).
                    Include(x => x.Address.Province).
                    Include(x => x).Where(c => c.Id == _counterparty.Id).Select(d => d).Single();

                counterparty.Id = _counterparty.Id;
                _erpDatabase.Entry(dbFoo).CurrentValues.SetValues(counterparty);
                _erpDatabase.Entry(dbFoo.Address).CurrentValues.SetValues(counterparty.Address);
                _erpDatabase.Entry(dbFoo.Address.Province).CurrentValues.SetValues(counterparty.Address.Province);

            }

            _erpDatabase.SaveChanges();
        }

        public void Init(Counterparty counterparty, bool newContent)
        {
            _newContent = newContent;

            if (newContent)
                return;

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
        private bool _newContent;

        public bool CanAddItem { get; set; } = false;
        public bool CanDeleteItem { get; set; } = false;
        public bool CanSaveItem { get; set; } = true;

      

        #endregion
    }
}
 