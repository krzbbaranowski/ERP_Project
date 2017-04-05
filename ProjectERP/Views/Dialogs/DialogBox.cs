using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace ProjectERP.Views.Dialogs
{
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