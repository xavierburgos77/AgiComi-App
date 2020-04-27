using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgeComiApp.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastMessage))]
namespace AgeComiApp.Droid
{
    class ToastMessage : IToastMessage
    {
        public void DisplayMessage(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}