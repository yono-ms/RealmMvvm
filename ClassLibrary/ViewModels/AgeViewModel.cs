using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 年齢入力ページ.
    /// </summary>
    public class AgeViewModel : BaseViewModel
    {
        private int age;

        /// <summary>
        /// 年齢
        /// </summary>
        [Required(ErrorMessage ="年齢を入力してください。")]
        [Range(18, 80, ErrorMessage ="年齢は{1}以上{2}以下で入力してください。")]
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                ErrorAge = ValidateProperty(nameof(Age), value);
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(Age)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(ErrorAge)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(CanCommit)));
            }
        }
        /// <summary>
        /// エラーメッセージ 年齢
        /// </summary>
        public string ErrorAge { get; set; }
        /// <summary>
        /// コミットボタン活性状態
        /// </summary>
        public bool CanCommit
        {
            get
            {
                return string.IsNullOrEmpty(ErrorAge);
            }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AgeViewModel()
        {
            PageTitle = "年齢の入力";
            PageDescription = "年齢を入力して「次へ」ボタンを押してください。";
        }
    }
}
