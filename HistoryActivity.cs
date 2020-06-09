using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace username_Keeper
{
    [Activity(Label = "Username_History")]
    public class HistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var userNameList = Intent.Extras.GetStringArrayList("user_names") ?? new string[0];
            var passwordList = (Intent.Extras.GetStringArrayList("pass_words") ?? new string[0]);
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, userNameList);

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            
            //Android.Widget.Toast.MakeText(this, passwordList[position], Android.Widget.ToastLength.Short).Show();
        }
    }
}