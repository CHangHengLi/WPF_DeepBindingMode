using System;
using BindingModeDemo.Common;

namespace BindingModeDemo.ViewModels
{
    /// <summary>
    /// OneWayToSource绑定示例的ViewModel
    /// </summary>
    public class OneWayToSourceViewModel : ViewModelBase
    {
        private double _leftPanelWidth = 200;
        private double _windowWidth = 900;
        private double _windowHeight = 650;

        /// <summary>
        /// 构造函数
        /// </summary>
        public OneWayToSourceViewModel()
        {
            // 初始默认值
        }

        /// <summary>
        /// 左侧面板宽度 - 通过OneWayToSource绑定从UI更新
        /// </summary>
        public double LeftPanelWidth
        {
            get => _leftPanelWidth;
            set
            {
                if (value > 0 && SetProperty(ref _leftPanelWidth, value))
                {
                    OnPropertyChanged(nameof(SettingsSummary));
                }
            }
        }

        /// <summary>
        /// 窗口宽度 - 通过OneWayToSource绑定从UI更新
        /// </summary>
        public double WindowWidth
        {
            get => _windowWidth;
            set
            {
                if (value > 0 && SetProperty(ref _windowWidth, value))
                {
                    OnPropertyChanged(nameof(SettingsSummary));
                }
            }
        }

        /// <summary>
        /// 窗口高度 - 通过OneWayToSource绑定从UI更新
        /// </summary>
        public double WindowHeight
        {
            get => _windowHeight;
            set
            {
                if (value > 0 && SetProperty(ref _windowHeight, value))
                {
                    OnPropertyChanged(nameof(SettingsSummary));
                }
            }
        }

        /// <summary>
        /// 设置摘要，显示当前保存的设置
        /// </summary>
        public string SettingsSummary
        {
            get
            {
                return $"窗口尺寸: {WindowWidth:F0} x {WindowHeight:F0}\n" +
                       $"左侧面板宽度: {LeftPanelWidth:F0}";
            }
        }
    }
} 