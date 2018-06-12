using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 名前入力ページ.
    /// </summary>
    public class NameViewModel : BaseViewModel
    {
        private string name;
        private string nameKana;

        /// <summary>
        /// 名前
        /// </summary>
        [Required(ErrorMessage = "お名前を入力してください。")]
        [RegularExpression("[^0-9A-Za-z]+", ErrorMessage = "英数字は使用できません。")]
        [StringLength(4, ErrorMessage = "お名前は{1}桁以内で入力してください。")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                ErrorName = ValidateProperty(nameof(Name), value);
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(ErrorName)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(CanCommit)));
            }
        }
        /// <summary>
        /// 名前（カナ）
        /// </summary>
        [Required(ErrorMessage = "お名前（カナ）を入力してください。")]
        [RegularExpression("[^0-9A-Za-z]+", ErrorMessage = "英数字は使用できません。")]
        [StringLength(6, ErrorMessage = "お名前（カナ）は{1}桁以内で入力してください。")]
        public string NameKana
        {
            get { return nameKana; }
            set
            {
                nameKana = value;
                ErrorNameKana = ValidateProperty(nameof(NameKana), value);
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(NameKana)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(ErrorNameKana)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(CanCommit)));
            }
        }
        /// <summary>
        /// タイトル 名前
        /// </summary>
        public string TitleName { get; } = "名前";
        /// <summary>
        /// タイトル 名前（カナ）
        /// </summary>
        public string TitleNameKana { get; } = "名前（カナ）";
        /// <summary>
        /// エラーメッセージ 名前
        /// </summary>
        public string ErrorName { get; set; }
        /// <summary>
        /// エラーメッセージ 名前（カナ）
        /// </summary>
        public string ErrorNameKana { get; set; }
        /// <summary>
        /// コミットボタン活性状態
        /// </summary>
        public bool CanCommit
        {
            get
            {
                return string.IsNullOrEmpty(ErrorName) && string.IsNullOrEmpty(ErrorNameKana);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NameViewModel()
        {
            PageTitle = "名前の入力";
            PageDescription = "名前を入力して「次へ」ボタンを押してください。";
        }
    }
}
