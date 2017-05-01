using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjectERP.Services
{
    public class AppDictionary
    {
        private static AppDictionary _instance;
        private static readonly object _lockObject = new object();

        private static Dictionary<string, ResourceDictionary> _resources = new Dictionary<string, ResourceDictionary>();

        public static AppDictionary Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = new AppDictionary();
                    return _instance;
                }
            }
        }

        public ResourceDictionary GetResourceDictionary(string name)
        {
            ResourceDictionary resources = _resources[name];

            if(resources==null)
            {
                throw new Exception($"Słownik o kluczu {name} nie został zarejestrowany!");
            }

            return resources;
        }

        public string GetString(string resourceRegisteredName, string resourceKey)
        {
            ResourceDictionary resources = _resources[resourceRegisteredName];

            if (resources == null)
            {
                throw new Exception($"Słownik o kluczu {resourceRegisteredName} nie został zarejestrowany!");
            }

            string resValue = resources[resourceKey].ToString();
           

            return resValue;
        }

        public void RegisterDictionary(string url, string name)
        {
            if (_resources.ContainsKey(name))
            {
                throw new Exception($"Słownik o kluczu {name} został już zarejestrowany!");
            }

            var resource = new ResourceDictionary
            {
                Source = new Uri(url,
                    UriKind.RelativeOrAbsolute)
            };

            _resources.Add(name, resource);

        }
    }
}