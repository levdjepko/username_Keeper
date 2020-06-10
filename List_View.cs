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
using username_Keeper.Data;

namespace username_Keeper
{
        [Activity(Label = "All saved usernames")]
        public class List_View : ListActivity
        {
            protected override async void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                UserDatabase database = new UserDatabase();
                var listSource = await database.GetItemsAsync();
            

                List<string> retrieved = new List<string>();
                

                foreach (var s in listSource)
                {
                    retrieved.Add($" Name: {s.Name} " + $" Password: {s.Pass}");
                }
                


                ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, retrieved);
            }
        }
}
