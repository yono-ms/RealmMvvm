using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RealmMvvm
{
    public class BizLogic
    {
        /// <summary>
        /// OS依存機能
        /// </summary>
        INativeCall nativeCall;
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
                    var settings = realm.All<Settings>().First();
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
                    var entrySheet = realm.All<EntrySheet>().First();
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
                    if (typeof(T) == typeof(NameViewModel))
                    {
                        var viewModel = new NameViewModel();
                        viewModel.Name = entrySheet.Name;
                        viewModel.NameKana = entrySheet.NameKana;
                        return viewModel as T;
                    }
                    else if (typeof(T) == typeof(AgeViewModel))
                    {
                        var viewModel = new AgeViewModel();
                        viewModel.Age = entrySheet.Age;
                        return viewModel as T;
                    }
                    else if (typeof(T) == typeof(AddressViewModel))
                    {
                        var viewModel = new AddressViewModel();
                        viewModel.Address = entrySheet.Address;
                        return viewModel as T;
                    }
                    else if (typeof(T) == typeof(ConfirmViewModel))
                    {
                        var viewModel = new ConfirmViewModel();
                        return viewModel as T;
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
    }
}
