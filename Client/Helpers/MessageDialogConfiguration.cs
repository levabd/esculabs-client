namespace Client.Helpers
{
    using MahApps.Metro.Controls.Dialogs;

    public class MessageDialogConfiguration
    {
        public MetroDialogSettings CommonSettings
        {
            get
            {
                return new MetroDialogSettings
                {
                    AffirmativeButtonText = "Да",
                    NegativeButtonText = "Отмена"
                };
            }
        }
    }
}
