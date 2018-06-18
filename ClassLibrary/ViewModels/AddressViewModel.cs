using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealmMvvm
{
    /// <summary>
    /// 住所入力ページ.
    /// </summary>
    public class AddressViewModel : BaseViewModel
    {
        private string address;

        /// <summary>
        /// 住所
        /// </summary>
        [Required(ErrorMessage = "ご住所を入力してください。")]
        [StringLength(4, ErrorMessage = "ご住所は{1}桁以内で入力してください。")]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                ErrorAddress = ValidateProperty(nameof(Address), value);
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(Address)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(ErrorAddress)));
                PropertyChangedInvoke(this, new PropertyChangedEventArgs(nameof(CanCommit)));
            }
        }
        /// <summary>
        /// エラーメッセージ 年齢
        /// </summary>
        public string ErrorAddress { get; set; }
        /// <summary>
        /// コミットボタン活性状態
        /// </summary>
        public bool CanCommit
        {
            get
            {
                return string.IsNullOrEmpty(ErrorAddress);
            }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AddressViewModel()
        {
            PageTitle = "ご住所の入力";
            PageDescription = "ご住所を入力して「次へ」ボタンを押してください。";
        }
    }
}
