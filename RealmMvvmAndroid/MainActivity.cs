using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using RealmMvvm;
using System.Collections.Generic;
using System;

namespace RealmMvvmAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, INativeCall
    {
        private BizLogic bizLogic;
        public BizLogic BizLogic { get { return bizLogic; } }

        public Dictionary<string, Type> stringToPage = new Dictionary<string, Type>
        {
            { nameof(StartViewModel), typeof(StartFragment) },
            //{ nameof(NameViewModel), typeof(NamePage) },
            //{ nameof(AgeViewModel), typeof(AgePage) },
            //{ nameof(AddressViewModel), typeof(AddressPage) },
            //{ nameof(ConfirmViewModel), typeof(ConfirmPage) },
            //{ nameof(FinishViewModel), typeof(FinishPage) }
        };

        public void NavigateTo(string viewName)
        {
            RunOnUiThread(() =>
            {
                if (stringToPage.ContainsKey(viewName))
                {
                    var next = Activator.CreateInstance(stringToPage[viewName]) as Fragment;
                    FragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutContent, next).Commit();
                }
                else
                {
                    var fragment = AlertDialogFragment.NewInstance($"{viewName}の画面がありません。");
                    fragment.Show(FragmentManager, nameof(AlertDialogFragment));
                }
            });
        }

        public void ShowAlert(string message)
        {
            RunOnUiThread(() =>
            {
                var fragment = AlertDialogFragment.NewInstance(message);
                fragment.Show(FragmentManager, nameof(AlertDialogFragment));
            });
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

