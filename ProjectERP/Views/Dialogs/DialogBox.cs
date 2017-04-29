using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ProjectERP.Views.Dialogs
{

    public class MessageDialogBox : CommandDialogBox
    {
        public MessageBoxResult? LastResult { get; protected set; }
        public MessageBoxButton Buttons { get; set; } = MessageBoxButton.OK;
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;
        public bool IsLastResultYes
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.Yes;
            }
        }
        public bool IsLastResultNo
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.No;
            }
        }
        public bool IsLastResultCancel
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.Cancel;
            }
        }
        public bool IsLastResultOK
        {
            get
            {
                if (!LastResult.HasValue) return false;
                return LastResult.Value == MessageBoxResult.OK;
            }
        }
        public MessageDialogBox()
        {
            execute = o =>
            {
                LastResult = MessageBox.Show((string)o, Caption, Buttons, Icon);
                OnPropertyChanged("LastResult");
                switch (LastResult)
                {
                    case MessageBoxResult.Yes:
                        OnPropertyChanged("IsLastResultYes");
                        ExecuteCommand(CommandYes, CommandParameter);
                        break;
                    case MessageBoxResult.No:
                        OnPropertyChanged("IsLastResultNo");
                        ExecuteCommand(CommandNo, CommandParameter);
                        break;
                    case MessageBoxResult.Cancel:
                        OnPropertyChanged("IsLastResultCancel");
                        ExecuteCommand(CommandCancel, CommandParameter);
                        break;
                    case MessageBoxResult.OK:
                        OnPropertyChanged("IsLastResultOK");
                        ExecuteCommand(CommandOK, CommandParameter);
                        break;
                }
            };
        }
        public static DependencyProperty CommandYesProperty =
        DependencyProperty.Register("CommandYes", typeof(ICommand), typeof(MessageDialogBox));

        public static DependencyProperty CommandNoProperty =
        DependencyProperty.Register("CommandNo", typeof(ICommand), typeof(MessageDialogBox));

        public static DependencyProperty CommandCancelProperty =
        DependencyProperty.Register("CommandCancel", typeof(ICommand), typeof(MessageDialogBox));

        public static DependencyProperty CommandOKProperty =
        DependencyProperty.Register("CommandOK", typeof(ICommand), typeof(MessageDialogBox));

        public ICommand CommandYes
        {
            get
            {
                return (ICommand)GetValue(CommandYesProperty);
            }
            set
            {
                SetValue(CommandYesProperty, value);
            }
        }
        public ICommand CommandNo
        {
            get
            {
                return (ICommand)GetValue(CommandNoProperty);
            }
            set
            {
                SetValue(CommandNoProperty, value);
            }
        }
        public ICommand CommandCancel
        {
            get
            {
                return (ICommand)GetValue(CommandCancelProperty);
            }
            set
            {
                SetValue(CommandCancelProperty, value);
            }
        }
        public ICommand CommandOK
        {
            get
            {
                return (ICommand)GetValue(CommandOKProperty);
            }
            set
            {
                SetValue(CommandOKProperty, value);
            }
        }
    }

    public class CommandDialogBox : DialogBox
    {
        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CommandDialogBox));

        public static DependencyProperty CommandBeforeProperty =
            DependencyProperty.Register("CommandBefore", typeof(ICommand),
                typeof(CommandDialogBox));

        public static DependencyProperty CommandAfterProperty =
            DependencyProperty.Register("CommandAfter", typeof(ICommand),
                typeof(CommandDialogBox));

        public override ICommand Show
        {
            get
            {
                if (show == null)
                    show = new RelayCommand<object>(
                        o =>
                        {
                            ExecuteCommand(CommandBefore, CommandParameter);
                            execute(o);
                            ExecuteCommand(CommandAfter, CommandParameter);
                        });
                return show;
            }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ICommand CommandBefore
        {
            get { return (ICommand) GetValue(CommandBeforeProperty); }
            set { SetValue(CommandBeforeProperty, value); }
        }

        public ICommand CommandAfter
        {
            get { return (ICommand) GetValue(CommandAfterProperty); }
            set { SetValue(CommandAfterProperty, value); }
        }

        protected static void ExecuteCommand(ICommand command, object commandParameter)
        {
            if (command != null)
                if (command.CanExecute(commandParameter))
                    command.Execute(commandParameter);
        }
    }

    public class NotificationDialogBox : CommandDialogBox
    {
        public NotificationDialogBox()
        {
            execute =
                o => { MessageBox.Show((string) o, Caption, MessageBoxButton.OK, MessageBoxImage.Information); };
        }

        public abstract class DialogBox : FrameworkElement, INotifyPropertyChanged
        {
            protected Action<object> execute = null;
            protected ICommand show;
            public string Caption { get; set; }

            public virtual ICommand Show
            {
                get
                {
                    if (show == null)
                        show = new RelayCommand<object>(execute);
                    return show;
                }
            }

            #region INotifyPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string nazwaWłasności)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
            }

            #endregion
        }
    }

    public abstract class DialogBox : FrameworkElement, INotifyPropertyChanged
    {
        protected Action<object> execute;
        protected ICommand show;
        public string Caption { get; set; }

        public virtual ICommand Show
        {
            get
            {
                if (show == null) show = new RelayCommand<object>(execute);
                return show;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string nazwaWłasności)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
        }

        #endregion
    }
}
