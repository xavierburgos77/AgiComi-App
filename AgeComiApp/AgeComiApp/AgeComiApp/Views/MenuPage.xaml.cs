using AgeComiApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgeComiApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {

                List<string> raiting = new List<string> { "Malo", "Normal", "Bueno", "Excelente" };
                pcRaiting.ItemsSource = raiting;
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                var horarios = db.Query<Horario>("SELECT * FROM Horario");
                var menu = db.Query<Models.Menu>("SELECT * FROM Menu");

                var desayuno = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Desayuno);
                var almuerzo = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Comida);
                var cena = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Cena);

                lblCena.Text = cena.First().Nombre;
                lblAlmuerzo.Text = almuerzo.First().Nombre;
                lblDesayuno.Text = desayuno.First().Nombre;
                imgDesayuno.Source = desayuno.First().Nombre_Imagen + ".jpg";
                imgAlmuerzo.Source = almuerzo.First().Nombre_Imagen + ".jpg";
                imgCena.Source = cena.First().Nombre_Imagen + ".jpg";
                foreach (var item in horarios)
                {
                    if (item.ID == 1)
                    {
                        
                        DateTime time = DateTime.Today.Add(item.Hora);
                        lblDesayunoHora.Text = time.ToString("hh:mm tt");
                    }
                    else if (item.ID == 2)
                    {
                        DateTime time = DateTime.Today.Add(item.Hora);
                        lblAlmuerzoHora.Text = time.ToString("hh:mm tt");
                    }
                    else if (item.ID == 3)
                    {
                        DateTime time = DateTime.Today.Add(item.Hora);
                        lblCenaHora.Text = time.ToString("hh:mm tt");
                    }
                }
            }
            catch (Exception ea)
            {

                
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}