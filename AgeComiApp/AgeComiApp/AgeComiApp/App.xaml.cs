using AgeComiApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgeComiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbSCV.db");
            Preferences.Set("DB_PATH", dbPath);
            //Guardamos el string de la base de datos en una preferencia.


            //Conectar con la base de datos
            var db = new SQLiteConnection(Preferences.Get("DB_PATH", dbPath));


            db.CreateTable<Comida>();
            db.CreateTable<Horario>();
            db.CreateTable<Models.Menu>();

            if (Preferences.Get("FIRST_BOOT", true))
            {

                InsertarHorario();
                InsertarComida();
                InsertarMenu();

                Preferences.Set("FIRST_BOOT", false);
            }
            else
            {

            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void InsertarHorario()
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));
                List<Horario> listHorario = new List<Horario>();
                Horario horarioC = new Horario();
                horarioC.Nombre = "Desayuno";
                horarioC.Hora = new TimeSpan(7, 0, 0);

                listHorario.Add(horarioC);

                horarioC = new Horario();
                horarioC.Nombre = "Almuerzo";
                horarioC.Hora = new TimeSpan(13, 0, 0);
                listHorario.Add(horarioC);

                horarioC = new Horario();
                horarioC.Nombre = "Cena";
                horarioC.Hora = new TimeSpan(19, 0, 0);
                listHorario.Add(horarioC);


                db.InsertAll(listHorario);
            }
            catch (Exception ea)
            {

                
            }
        }
        private void InsertarMenu()
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

                Models.Menu menu = new Models.Menu();
                menu.ID_Desayuno = 1;
                menu.ID_Comida = 1;
                menu.ID_Cena = 1;

                db.Insert(menu);
            }
            catch (Exception ea)
            {


            }
        }
        private void InsertarComida()
        {
            try
            {
                var db = new SQLiteConnection(Preferences.Get("DB_PATH", ""));

                var horarios = db.Query<Horario>("SELECT * FROM Horario");

                if (horarios.Count != 0)
                {
                    List<Comida> listcomidas = new List<Comida>();

                    #region Comidas de Desayuno
                    Comida comida = new Comida();
                    comida.Nombre = "CornFlakes con leche";
                    comida.Nombre_Imagen = "Cereal";
                    comida.ID_Horario = 1;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Frutas";
                    comida.Nombre_Imagen = "Frutas";
                    comida.ID_Horario = 1;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Pan tostado con huevo revuelto";
                    comida.Nombre_Imagen = "HuevoPan";
                    comida.ID_Horario = 1;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "PanCakes";
                    comida.Nombre_Imagen = "Pancakes";
                    comida.ID_Horario = 1;

                    listcomidas.Add(comida);
                    #endregion

                    #region Comidas de Almuerzo
                    comida = new Comida();
                    comida.Nombre = "Bandera Dominicana";
                    comida.Nombre_Imagen = "Bd";
                    comida.ID_Horario = 2;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Hamburguesas con papas fritas";
                    comida.Nombre_Imagen = "Hamburguesa";
                    comida.ID_Horario = 2;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Mangu de platano verde con carne";
                    comida.Nombre_Imagen = "Mangu";
                    comida.ID_Horario = 2;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Sancocho";
                    comida.Nombre_Imagen = "Sancocho";
                    comida.ID_Horario = 2;

                    listcomidas.Add(comida);
                    #endregion

                    #region Comidas de Cena
                    comida = new Comida();
                    comida.Nombre = "Hotdogs";
                    comida.Nombre_Imagen = "Hotdog";
                    comida.ID_Horario = 3;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Mangu de platano verde con salami";
                    comida.Nombre_Imagen = "ManguC";
                    comida.ID_Horario = 3;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Pizza";
                    comida.Nombre_Imagen = "Pizza";
                    comida.ID_Horario = 3;

                    listcomidas.Add(comida);

                    comida = new Comida();
                    comida.Nombre = "Tacos";
                    comida.Nombre_Imagen = "Tacos";
                    comida.ID_Horario = 3;

                    listcomidas.Add(comida);
                    #endregion

                    db.InsertAll(listcomidas);
                }

            }
            catch (Exception ea)
            {

                //throw;
            }
        }


    }
}
