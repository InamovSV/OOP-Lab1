using GalaSoft.MvvmLight.Messaging;
using OOP_1_Lab.ViewModel;

namespace OOP_1_Lab
{
    class MessageListener
    {
        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            // Hook to the message that states that some caller wants to open a ChildWindow.
            Messenger.Default.Register<string>(
                this,
                msg =>
                {
                    var window = new UserWindow();
                    var model = window.DataContext;
                    if (model != null)
                    {
                        //model.TextForWindow = msg;
                    }
                    window.ShowDialog();
                });
        }

            public bool BindableProperty => true;
    }
}
