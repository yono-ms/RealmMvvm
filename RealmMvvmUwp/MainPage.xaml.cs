using RealmMvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace RealmMvvmUwp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page, INativeCall
    {
        private BizLogic bizLogic;

        public Frame ContentFrame { get; private set; }

        public Dictionary<string, Type> stringToPage = new Dictionary<string, Type>
        {
            { nameof(StartViewModel), typeof(StartPage) },
            { nameof(NameViewModel), typeof(NamePage) },
            { nameof(AgeViewModel), typeof(AgePage) },
            { nameof(AddressViewModel), typeof(AddressPage) },
            { nameof(ConfirmViewModel), typeof(ConfirmPage) },
            { nameof(FinishViewModel), typeof(FinishPage) }
        };

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size { Width = 480, Height = 640 };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            bizLogic = new BizLogic(this);

            ContentFrame = new Frame();
            GridContent.Children.Add(ContentFrame);
            var view = bizLogic.GetCurrentView();
            ContentFrame.Navigate(stringToPage[view]);
        }

        public void ShowAlert(string message)
        {
            Task.Run(async () =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    // アラート表示
                    var dialog = new ContentDialog
                    {
                        Title = "エラー",
                        Content = message,
                        IsPrimaryButtonEnabled = true,
                        PrimaryButtonText = "OK"
                    };
                });
            });
        }
    }
}
