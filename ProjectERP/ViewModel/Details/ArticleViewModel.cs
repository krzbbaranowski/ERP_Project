using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Messages;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.Services;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Interfaces;

namespace ProjectERP.ViewModel.Details
{
    public class ArticleViewModel : ViewModelBase, IMainTabDetailsItem, IUpdateView
    {
        private readonly IArticlePriceTypeRepository _articlePriceTypeRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleTypeRepository _articleTypeRepository;
        private readonly IMeasureRepository _measureRepository;
        private readonly ITaxRepository _taxRepository;

        private RelayCommand _saveItemCommand;

        public ArticleViewModel(IArticleRepository articleRepository, ITaxRepository taxRepository,
            IMeasureRepository measureRepository, IArticleTypeRepository articleTypeRepository,
            IArticlePriceTypeRepository articlePriceTypeRepository)
        {
            _articleRepository = articleRepository;
            _taxRepository = taxRepository;
            _measureRepository = measureRepository;
            _articleTypeRepository = articleTypeRepository;
            _articlePriceTypeRepository = articlePriceTypeRepository;

            Header = $"{_measureRepository.GetEntities().Count()}";
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
                                                           cfg.CreateMap<ArticleViewModel, Article>();
                                                           cfg.CreateMap<ArticleViewModel, Tax>();
                                                           cfg.CreateMap<ArticleViewModel, ArticleType>();
                                                           cfg.CreateMap<ArticleViewModel, ArticleMeasure>();
                                                           cfg.CreateMap<ArticleViewModel, ArticlePrice>();
                                                       });

                                                       var mapper = config.CreateMapper();

                                                       if (_dbArticle == null)
                                                           _dbArticle = new Article
                                                           {
                                                               ArticlePrice = new List<ArticlePrice>(),
                                                               DefaultArticlePrice = new ArticlePrice(),
                                                               ArticleType = new ArticleType(),
                                                               ArticleMeasure = new ArticleMeasure()
                                                           };

                                                       mapper.Map(this,
                                                           _dbArticle);


                                                       if (_isNew)
                                                           _articleRepository.Add(_dbArticle);
                                                       else
                                                           _articleRepository.Update(_dbArticle);

                                                       _articleRepository.Save();
                                                   }));

        public void Initialize(int entityId)
        {
            _isNew = false;

            var articlePricesTypes = _articlePriceTypeRepository.GetEntities();

            _dbArticle = _articleRepository.GetById(entityId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleViewModel>();
                cfg.CreateMap<Tax, ArticleViewModel>();
                cfg.CreateMap<ArticleType, ArticleViewModel>();
                cfg.CreateMap<ArticleMeasure, ArticleViewModel>();
                cfg.CreateMap<ArticlePrice, ArticleViewModel>();
            });

            var mapper = config.CreateMapper();

            mapper.Map(_dbArticle, this);


            Header = $"{AppDictionary.Instance.GetString("StringLocs", "Article")} {ArticleCode}";
        }

        public void UpdateView()
        {
            var taxs = _taxRepository.GetEntities();
            var measures = _measureRepository.GetEntities();
            var types = _articleTypeRepository.GetEntities();
            var priceTypes = _articlePriceTypeRepository.GetEntities();

            Taxs.Clear();
            foreach (var tax in taxs)
                Taxs.Add(tax);

            Measures.Clear();
            foreach (var measure in measures)
                Measures.Add(measure);

            ArticleTypes.Clear();
            foreach (var type in types)
                ArticleTypes.Add(type);

            ArticlePriceTypes.Clear();
            foreach (var type in priceTypes)
                ArticlePriceTypes.Add(type);
        }


        #region Model properties

        public ObservableCollection<Tax> Taxs { get; protected set; } = new ObservableCollection<Tax>();

        public ObservableCollection<ArticleMeasure> Measures { get; protected set; } =
            new ObservableCollection<ArticleMeasure>();

        public ObservableCollection<ArticlePrice> ArticlePrice { get; protected set; } =
            new ObservableCollection<ArticlePrice>();

        public ObservableCollection<ArticleType> ArticleTypes { get; protected set; } =
            new ObservableCollection<ArticleType>();

        public ObservableCollection<ArticlePriceType> ArticlePriceTypes { get; protected set; } =
            new ObservableCollection<ArticlePriceType>();


        public string ArticleName
        {
            get => _articleName;
            set => Set(nameof(ArticleName), ref _articleName, value);
        }

        public string ArticleCode
        {
            get => _articleCode;
            set => Set(nameof(ArticleCode), ref _articleCode, value);
        }

        public double ArticleQuantity
        {
            get => _articleQuantity;
            set => Set(nameof(ArticleQuantity), ref _articleQuantity, value);
        }

        public string ArticleEan
        {
            get => _articleEan;
            set => Set(nameof(ArticleEan), ref _articleEan, value);
        }

        public ArticlePrice DefaultArticlePrice
        {
            get => _defaultArticlePrice;
            set => Set(nameof(_defaultArticlePrice), ref _defaultArticlePrice, value);
        }

        public Tax ArticleTax
        {
            get => _articleTax;
            set => Set(nameof(ArticleTax), ref _articleTax, value);
        }

        public ArticleType ArticleType
        {
            get => _articleType;
            set => Set(nameof(ArticleType), ref _articleType, value);
        }

        public ArticleMeasure ArticleMeasure
        {
            get => _articleMeasure;
            set => Set(nameof(_articleMeasure), ref _articleMeasure, value);
        }

        #endregion

        #region Private model fields

        private Article _dbArticle;
        private bool _isNew = true;
        private RelayCommand _closeCommand;
        private double _articleQuantity;
        private string _articleCode;
        private string _articleEan;
        private double _articleDefaultNetto;
        private Tax _articleTax;
        private ArticleMeasure _articleMeasure;
        private string _articleName;
        private ArticlePrice _defaultArticlePrice;
        private ArticleType _articleType;


        public string Header { get; set; }
        public bool IsMultiply { get; set; } = true;

        #endregion
    }
}