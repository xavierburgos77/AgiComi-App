using AgeComiApp.Models;
using AgeComiApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgeComiApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPage : ContentPage
    {

        public EditarPage()
        {
            InitializeComponent();
            

        }
        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                var horarios = db.Query<Horario>("SELECT * FROM Horario");
                var menu = db.Query<Models.Menu>("SELECT * FROM Menu");

                var desayuno = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Desayuno);
                var almuerzo = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Comida);
                var cena = db.Query<Comida>("SELECT * FROM Comida where ID =" + menu.First().ID_Cena);


                lblCena.Text = cena.First().Nombre;
                lblAlmuerzo.Text = almuerzo.First().Nombre;
                lblDesayuno.Text = desayuno.First().Nombre;

                foreach (var item in horarios)
                {
                    if (item.ID == 1)
                    {
                        tpDesayuno.Time = item.Hora;
                    }
                    else if (item.ID == 2)
                    {
                        tpAlmuerzo.Time = item.Hora;
                    }
                    else if (item.ID == 3)
                    {
                        tpCena.Time = item.Hora;
                    }
                }

            }
            catch (Exception)
            {

                //throw;
            }
            
        }

        private async void btnDesayuno_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                var horarios = db.Query<Horario>("SELECT * FROM Horario");

                foreach (var item in horarios)
                {
                    if (item.ID == 1)
                    {
                        await Navigation.PushAsync(new PickerPage(item));
                    }
                   
                }
            }
            catch (Exception ea)
            {

                Debug.WriteLine(ea.Message);
            }
        }

        private async void btnAlmuerzo_Clicked(object sender, EventArgs e)
        {
            try
            {

                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                var horarios = db.Query<Horario>("SELECT * FROM Horario");

                foreach (var item in horarios)
                {
                    if (item.ID == 2)
                    {
                        await Navigation.PushAsync(new PickerPage(item));
                    }

                }
            }
            catch (Exception ea)
            {

                Debug.WriteLine(ea.Message);
            }
        }

        private async void btnCena_Clicked(object sender, EventArgs e)
        {
            try
            {

                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                var horarios = db.Query<Horario>("SELECT * FROM Horario");

                foreach (var item in horarios)
                {
                    if (item.ID == 3)
                    {
                        await Navigation.PushAsync(new PickerPage(item));
                    }

                }
            }
            catch (Exception ea)
            {

                Debug.WriteLine(ea.Message);
            }
        }

        private void tpCena_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

                var horarioCena = db.Query<Horario>("SELECT * FROM Horario where ID = 3");
                Horario horario = horarioCena.First();
                if ((tpCena.Time == new TimeSpan()))
                {
                   

                }
                else
                {
                    horario.Hora = tpCena.Time;
                    //DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la hora correctamente.");
                    //horario.Hora = tpCena.Time;
                }
                db.Update(horario);


            }
            catch (Exception)
            {

            }
        }

        private void tpDesayuno_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

                var horarioDesayuno = db.Query<Horario>("SELECT * FROM Horario where ID = 1");

                Horario horario = horarioDesayuno.First();
                if ((tpDesayuno.Time == new TimeSpan()))
                {
                    

                }
                else
                {
                    horario.Hora = tpDesayuno.Time;
                   // DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la hora correctamente.");
                    //horario.Hora = tpDesayuno.Time;
                }
                db.Update(horario);

            }
            catch (Exception ea)
            {
                var x = ea.Message;
            }
           


        }

        private void tpAlmuerzo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

                var horarioAlmuerzo = db.Query<Horario>("SELECT * FROM Horario where ID = 2");

                Horario horario = horarioAlmuerzo.First();
                if ((tpAlmuerzo.Time == new TimeSpan()))
                {
                    

                }
                else
                {
                    horario.Hora = tpAlmuerzo.Time;
                    //DependencyService.Get<IToastMessage>().DisplayMessage("Se ha actualizado la hora correctamente.");
                    //horario.Hora = tpAlmuerzo.Time;

                }
                db.Update(horario);

            }
            catch (Exception)
            {

            }
        }

     
    }
}