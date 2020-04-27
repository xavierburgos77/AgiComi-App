using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgeComiApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMenu_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new MenuPage());
            }
            catch (Exception)
            {

                
            }
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new EditarPage());
            }
            catch (Exception)
            {


            }
        }
    }
}
