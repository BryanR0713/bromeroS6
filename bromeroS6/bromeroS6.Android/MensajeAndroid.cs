using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using bromeroS6.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    [ assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]//considerado al momento de ejecutarse la aplicacion
namespace bromeroS6.Droid
{
    public class MensajeAndroid : Mensaje
    {
        public void longalert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();// 5 seg
        }

        public void shortalert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();//3seg
        }
    }
}