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
                        realm.Write(() =>
                        {
                            settings = new Settings { CurrentPage = nameof(StartViewModel) };
                            realm.Add(settings);
                        });
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
                        nameViewModel.OnClickCommit += NameViewModel_OnClickCommit;
                        nameViewModel.OnClickBack += NameViewModel_OnClickBack;
                        return nameViewModel as T;
                    }
                    else if (typeof(T) == typeof(AgeViewModel))
                    {
                        var ageViewModel = new AgeViewModel();
                        ageViewModel.Age = entrySheet.Age;
                        ageViewModel.OnClickCommit += AgeViewModel_OnClickCommit;
                        ageViewModel.OnClickBack += AgeViewModel_OnClickBack;
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

        private void AgeViewModel_OnClickBack(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                Debug.WriteLine("busy.");
                return;
            }

            nativeCall.NavigateTo(nameof(NameViewModel));
        }

        private void AgeViewModel_OnClickCommit(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                Debug.WriteLine("busy.");
                return;
            }

            var ageViewModel = sender as AgeViewModel;

            // 画面間のバリデーションチェックがあればここで

            // 保存する
            try
            {
                using (var realm = Realm.GetInstance())
                {
                    realm.Write(() =>
                    {
                        // エントリーシート
                        var entrySheet = realm.All<EntrySheet>().FirstOrDefault();
                        if (entrySheet == null)
                        {
                            nativeCall.ShowAlert("No entry sheet.");
                            return;
                        }
                        entrySheet.Age = ageViewModel.Age;

                        // 次画面
                        var settings = realm.All<Settings>().FirstOrDefault();
                        if (settings == null)
                        {
                            nativeCall.ShowAlert("No settings.");
                            return;
                        }
                        settings.CurrentPage = nameof(AddressViewModel);
                    });

                }

                nativeCall.NavigateTo(nameof(AddressViewModel));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                nativeCall.ShowAlert(ex.Message);
            }
        }

        private void NameViewModel_OnClickBack(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                Debug.WriteLine("busy.");
                return;
            }

            nativeCall.NavigateTo(nameof(StartViewModel));
        }

        private void NameViewModel_OnClickCommit(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                Debug.WriteLine("busy.");
                return;
            }

            var nameViewModel = sender as NameViewModel;

            // 画面間のバリデーションチェックがあればここで

            // 保存する
            try
            {
                using (var realm = Realm.GetInstance())
                {
                    realm.Write(() =>
                    {
                        // エントリーシート
                        var entrySheet = realm.All<EntrySheet>().FirstOrDefault();
                        if (entrySheet == null)
                        {
                            nativeCall.ShowAlert("No entry sheet.");
                            return;
                        }
                        entrySheet.Name = nameViewModel.Name;
                        entrySheet.NameKana = nameViewModel.NameKana;

                        // 次画面
                        var settings = realm.All<Settings>().FirstOrDefault();
                        if (settings == null)
                        {
                            nativeCall.ShowAlert("No settings.");
                            return;
                        }
                        settings.CurrentPage = nameof(AgeViewModel);
                    });

                }

                nativeCall.NavigateTo(nameof(AgeViewModel));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                nativeCall.ShowAlert(ex.Message);
            }
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
