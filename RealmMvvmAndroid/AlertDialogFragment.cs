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

namespace RealmMvvmAndroid
{
    public class AlertDialogFragment : DialogFragment
    {
        const string KEY_MESSAGE = "message";
        /// <summary>
        /// 引数をバンドルしてインスタンスを生成する.
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>フラグメント</returns>
        public static AlertDialogFragment NewInstance(string message)
        {
            // 引数をセットする
            var bundle = new Bundle();
            bundle.PutString(KEY_MESSAGE, message);
            var fragment = new AlertDialogFragment();
            fragment.Arguments = bundle;
            return fragment;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            // バンドルから引数を回収する
            var message = Arguments.GetString(KEY_MESSAGE, "no message.");
            var dialog = new AlertDialog.Builder(Activity).SetMessage(message);
            Cancelable = false;

            return dialog.Create();
        }
    }
}