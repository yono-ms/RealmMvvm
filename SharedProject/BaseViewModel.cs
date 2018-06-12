using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 基本クラス.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// ページタイトル.
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// ページ説明文.
        /// </summary>
        public string PageDescription { get; set; }
        /// <summary>
        /// コミットボタンラベル.
        /// </summary>
        public string ButtonLabelCommit { get; set; }
        /// <summary>
        /// 戻るボタンラベル.
        /// </summary>
        public string ButtonLabelBack { get; set; }
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public BaseViewModel()
        {
            PageTitle = "ページ名が定義されていません";
            ButtonLabelCommit = "次へ";
            ButtonLabelBack = "戻る";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 派生クラスからプロパティイベントをキックする.
        /// </summary>
        /// <param name="sender">送信者</param>
        /// <param name="e">イベント引数</param>
        protected void PropertyChangedInvoke(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
        /// <summary>
        /// プロパティバリデーションを実行する.
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="value">値</param>
        /// <returns>エラーメッセージ</returns>
        protected String ValidateProperty(string propertyName, object value)
        {
            var context = new ValidationContext(this) { MemberName = propertyName };
            var validationErrors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, validationErrors))
            {
                // エラーあり
                var errors = validationErrors.Select(e => e.ErrorMessage);
                var result = string.Join("\n", errors);
                return result;
            }
            else
            {
                // エラーなし
                return null;
            }
        }

        /// <summary>
        /// コミットボタン押下イベント.
        /// </summary>
        public event EventHandler OnClickCommit;
        /// <summary>
        /// 派生クラスからボタン押下イベントをキックする.
        /// </summary>
        /// <param name="sender">送信者</param>
        /// <param name="e">イベント引数</param>
        public void OnClickCommitInvoke(object sender, EventArgs e)
        {
            OnClickCommit?.Invoke(sender, e);
        }
        /// <summary>
        /// バックボタン押下イベント.
        /// </summary>
        public event EventHandler OnClickBack;
        /// <summary>
        /// 派生クラスからボタン押下イベントをキックする.
        /// </summary>
        /// <param name="sender">送信者</param>
        /// <param name="e">イベント引数</param>
        public void OnClickBackInvoke(object sender, EventArgs e)
        {
            OnClickBack?.Invoke(sender, e);
        }
    }
}
