using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectERP.Model
{
    public class Counterparty: ObservableObject
    {
        private int id;
        private string name;
        private int age;
        private decimal salary;

        public const string MyPropertyPropertyName = "MyProperty";

        private bool _myProperty = false;

        public bool MyProperty
        {
            get
            {
                return _myProperty;
            }
            
            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
                RaisePropertyChanged(MyPropertyPropertyName);
            }
        }
    }

}
