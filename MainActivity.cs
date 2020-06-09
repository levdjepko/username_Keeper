using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace username_Keeper
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our UI controls from the loaded layout
            EditText    username = FindViewById<EditText>(Resource.Id.nameText);
            EditText    password = FindViewById<EditText>(Resource.Id.passwordText);
            Button      addButton = FindViewById<Button>(Resource.Id.AddButton);
            Button      loadAllButton = FindViewById<Button>(Resource.Id.LoadAll);


            addButton.Click += (sender, e) =>
            {
                // Check if the password is correct and username is not empty
                if (Core.EntryValidator.CheckPassword(password.Text) && username.Text.Length > 0)
                {
                    FindViewById<TextView>(Resource.Id.addedText).Text = $"Your username is {username.Text} ," +
                    $" password is {password.Text}";
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Password not complaint");
                    alert.SetMessage("Your username should be not empty. \n Password must only contain letters and digits, be between 5 and 12 letters long, have at least" +
                        " 1 letter and 1 number, and not have recurring substrings (like abcabc");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        // no action required
                    });
                    alert.Show();
                }
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}