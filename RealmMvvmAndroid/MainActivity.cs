using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using RealmMvvm;

namespace RealmMvvmAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, INativeCall
    {
        private BizLogic bizLogic;

        public void ShowAlert(string message)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            bizLogic = new BizLogic(this);
            var currentView = bizLogic.GetCurrentView();
            System.Diagnostics.Debug.WriteLine(currentView);
        }
    }
}

