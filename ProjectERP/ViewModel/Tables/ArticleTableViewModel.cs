#region

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Messages;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Interfaces;
using ProjectERP.ViewModel.MVVMLight;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class ArticleTableViewModel : ViewModelBase, IMainTabItem, IUpdateView
    {
        private readonly IArticleRepository _articleRepository;
        private RelayCommand _addItemCommand;
        private RelayCommand _closeCommand;
        private RelayCommand<Article> _deleteItemCommand;

        private RelayCommand<Article> _selectRowCommand;

        public ArticleTableViewModel(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        public ObservableCollection<Article> Articles { get; protected set; } =
            new ObservableCollection<Article>();

        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand
                       ?? (_addItemCommand = new RelayCommand(
                           () =>
                           {ViewModelLocator locator = new ViewModelLocator();

                               IMainTabItem articleDetailsVm = locator.ArticleView;

                               var newItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = articleDetailsVm
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
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


        public RelayCommand<Article> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<Article>(
                           item =>
                           {
                               //if (item == null)
                               //    return;

                               //IMainTabDetailsItem counterpartyDetailsVM =
                               //    SimpleIoc.Default.GetInstance<CounterpartyViewModel>(Guid.NewGuid().ToString());

                               //counterpartyDetailsVM.Initialize(item.Id);

                               //var newItemMessage = new MainTabItemMessage
                               //{
                               //    MainTabItem = counterpartyDetailsVM
                               //};

                               //Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public RelayCommand<Article> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand
                       ?? (_deleteItemCommand = new RelayCommand<Article>(
                           article =>
                           {
                               var dbArticle = _articleRepository.GetById(article.Id);
                               _articleRepository.Remove(dbArticle);
                               _articleRepository.Save();

                               UpdateView();
                           }));
            }
        }

        public string Header { get; set; } = "Lista towarów";
        public bool IsMultiply { get; set; } = false;

        public void UpdateView()
        {
            var articles = _articleRepository.GetEntities();

            Articles.Clear();
            foreach (var article in articles)
                Articles.Add(article);
        }
    }
}