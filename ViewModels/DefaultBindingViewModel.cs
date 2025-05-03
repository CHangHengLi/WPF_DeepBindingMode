using System;
using BindingModeDemo.Common;

namespace BindingModeDemo.ViewModels
{
    /// <summary>
    /// Default绑定示例的ViewModel
    /// </summary>
    public class DefaultBindingViewModel : ViewModelBase
    {
        private string _textBoxContent;
        private bool _isOptionSelected;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultBindingViewModel()
        {
            // 初始默认值
            _textBoxContent = "请在此输入文本";
            _isOptionSelected = false;
        }

        /// <summary>
        /// 文本框内容
        /// </summary>
        public string TextBoxContent
        {
            get => _textBoxContent;
            set => SetProperty(ref _textBoxContent, value);
        }

        /// <summary>
        /// 是否选中选项
        /// </summary>
        public bool IsOptionSelected
        {
            get => _isOptionSelected;
            set 
            { 
                if (SetProperty(ref _isOptionSelected, value))
                {
                    OnPropertyChanged(nameof(IsSelectedText));
                }
            }
        }

        /// <summary>
        /// 选中状态文本描述
        /// </summary>
        public string IsSelectedText => IsOptionSelected ? "已选中" : "未选中";
    }
} 