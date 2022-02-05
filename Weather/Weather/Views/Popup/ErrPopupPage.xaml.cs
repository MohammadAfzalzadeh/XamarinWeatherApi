using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FreshMvvm;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;




namespace Weather.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrPopupPage : PopupPage
    {
        public ErrPopupPage(String err)
        {
            InitializeComponent();
            errlbl.Text = err;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }

}
