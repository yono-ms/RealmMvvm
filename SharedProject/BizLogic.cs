using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmMvvm
{
    public class BizLogic
    {
        /// <summary>
        /// OS依存機能
        /// </summary>
        private INativeCall nativeCall;
        /// <summary>
        /// 連打防止
        /// </summary>
        private bool busy;
        /// <summary>
        /// 連打防止
        /// </summary>
        public bool IsBusy
        {
            get
            {
                if (!busy)
                {
                    busy = true;
                    Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        busy = false;
                    });
                    return false;
                }
                else
                {
                    return busy;
                }
            }
            set { busy = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="nativeCall">OS依存機能</param>
        public BizLogic(INativeCall nativeCall)
        {
            this.nativeCall = nativeCall;
        }
        /// <summary>
        /// 現在のページを返す
        /// </summary>
        /// <returns>現在のページ</returns>
        public string GetCurrentView()
        {
            try
            {
                using (var realm = Realm.GetInstance())
                {
                    var settings = realm.All<Settings>().FirstOrDefault();
                    if (settings == null)
                    {
                        realm.Write(() => { settings = new Settings { CurrentPage = nameof(StartViewModel) }; });
                    }

                    return settings.CurrentPage;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                nativeCall.ShowAlert(ex.Message);
            }

            return nameof(StartViewModel);
        }
        /// <summary>
        /// ビューモデルを取得する.
        /// </summary>
        /// <typeparam name="T">ビューモデルの型.</typeparam>
        /// <returns>ビューモデルのインスタンス.</returns>
        public T GetViewModel<T>() where T : BaseViewModel, new()
        {
            try
            {
                using (var realm = Realm.GetInstance())
                {
                    var entrySheet = realm.All<EntrySheet>().FirstOrDefault();
                    if (entrySheet == null)
                    {
                        // 保存情報が存在しない
                        realm.Write(() =>
                        {
                            entrySheet = new EntrySheet
                            {
                                Name = "",
                                NameKana = "",
                                Age = 20,
                                Address = ""
                            };
                            realm.Add(entrySheet);
                        });
                    }
                    if (typeof(T) == typeof(StartViewModel))
                    {
                        var startViewModel = new StartViewModel();
                        startViewModel.OnClickCommit += StartViewModel_OnClickCommit;
                        return startViewModel as T;
                    }
                    else if (typeof(T) == typeof(NameViewModel))
                    {
                        var nameViewModel = new NameViewModel();
                        nameViewModel.Name = entrySheet.Name;
                        nameViewModel.NameKana = entrySheet.NameKana;
                        return nameViewModel as T;
                    }
                    else if (typeof(T) == typeof(AgeViewModel))
                    {
                        var ageViewModel = new AgeViewModel();
                        ageViewModel.Age = entrySheet.Age;
                        return ageViewModel as T;
                    }
                    else if (typeof(T) == typeof(AddressViewModel))
                    {
                        var addressViewModel = new AddressViewModel();
                        addressViewModel.Address = entrySheet.Address;
                        return addressViewModel as T;
                    }
                    else if (typeof(T) == typeof(ConfirmViewModel))
                    {
                        var confirmViewModel = new ConfirmViewModel();
                        return confirmViewModel as T;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                nativeCall.ShowAlert(ex.Message);
            }

            return new T();
        }

        private void StartViewModel_OnClickCommit(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                Debug.WriteLine("busy.");
                return;
            }

            nativeCall.NavigateTo(nameof(NameViewModel));
        }
    }
}
