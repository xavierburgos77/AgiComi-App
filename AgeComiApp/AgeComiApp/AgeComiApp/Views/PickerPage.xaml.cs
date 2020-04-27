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

namespace AgeComiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        private Horario horario;
        private List<Comida> comidas;
        public PickerPage(Horario item)
        {
            InitializeComponent();
            horario = item;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblComida.Text = horario.Nombre;
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            comidas = db.Query<Comida>("SELECT * FROM Comida WHERE ID_Horario ="+horario.ID);
            int x = 0;
            
            foreach (var item in comidas)
            {
                x++;
                if (x == 1)
                {
                    imgPrimera.Source = item.Nombre_Imagen + ".jpg";
                    lblPrimera.Text = item.Nombre;
                }
                else if (x == 2)
                {
                    imgSegunda.Source = item.Nombre_Imagen + ".jpg";
                    lblSegunda.Text = item.Nombre;
                }
                else if (x == 3)
                {
                    imgTercera.Source = item.Nombre_Imagen + ".jpg";
                    lblTercera.Text = item.Nombre;
                }
                else if (x == 4)
                {
                    imgCuarta.Source = item.Nombre_Imagen + ".jpg";
                    lblCuarta.Text = item.Nombre;
                }
                
            }
        }

        private void imgPrimera_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var menus = db.Query<Models.Menu>("SELECT * FROM Menu");
            Models.Menu menu = menus.First();
            if (horario.ID == 1)
            {
                menu.ID_Desayuno = comidas[0].ID;
                
               
            }
            else if (horario.ID == 2)
            {
                menu.ID_Comida = comidas[0].ID;
            }
            else if (horario.ID == 3)
            {
                menu.ID_Cena = comidas[0].ID;
            }

            db.Update(menu);
            DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la comida correctamente.");
            Navigation.PopAsync();
        }

        private void imgCuarta_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var menus = db.Query<Models.Menu>("SELECT * FROM Menu");
            Models.Menu menu = menus.First();
            if (horario.ID == 1)
            {
                menu.ID_Desayuno = comidas[3].ID;


            }
            else if (horario.ID == 2)
            {
                menu.ID_Comida = comidas[3].ID;
            }
            else if (horario.ID == 3)
            {
                menu.ID_Cena = comidas[3].ID;
            }

            db.Update(menu);
            DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la comida correctamente.");
            Navigation.PopAsync();
        }

        private void imgTercera_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var menus = db.Query<Models.Menu>("SELECT * FROM Menu");
            Models.Menu menu = menus.First();
            if (horario.ID == 1)
            {
                menu.ID_Desayuno = comidas[2].ID;


            }
            else if (horario.ID == 2)
            {
                menu.ID_Comida = comidas[2].ID;
            }
            else if (horario.ID == 3)
            {
                menu.ID_Cena = comidas[2].ID;
            }

            db.Update(menu);
            DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la comida correctamente.");
            Navigation.PopAsync();
        }

        private void imgSegunda_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
            var menus = db.Query<Models.Menu>("SELECT * FROM Menu");
            Models.Menu menu = menus.First();
            if (horario.ID == 1)
            {
                menu.ID_Desayuno = comidas[1].ID;

            }
            else if (horario.ID == 2)
            {
                menu.ID_Comida = comidas[1].ID;
            }
            else if (horario.ID == 3)
            {
                menu.ID_Cena = comidas[1].ID;
            }

            db.Update(menu);
            DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la comida correctamente.");
            Navigation.PopAsync();
        }
    }
}