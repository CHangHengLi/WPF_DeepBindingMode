using System.Windows.Input;
using BindingModeDemo.Common;

namespace BindingModeDemo.ViewModels
{
    /// <summary>
    /// 主导航ViewModel，负责在不同绑定模式示例之间切换
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private string _title = "WPF绑定模式深入";

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainViewModel()
        {
            // 初始化命令
            NavigateToOneWayCommand = new RelayCommand(_ => NavigateToOneWay());
            NavigateToTwoWayCommand = new RelayCommand(_ => NavigateToTwoWay());
            NavigateToOneWayToSourceCommand = new RelayCommand(_ => NavigateToOneWayToSource());
            NavigateToDefaultCommand = new RelayCommand(_ => NavigateToDefault());

            // 默认显示OneWay示例
            NavigateToOneWay();
        }

        /// <summary>
        /// 应用标题
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// 当前显示的ViewModel
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        /// <summary>
        /// 导航到OneWay示例的命令
        /// </summary>
        public ICommand NavigateToOneWayCommand { get; }

        /// <summary>
        /// 导航到TwoWay示例的命令
        /// </summary>
        public ICommand NavigateToTwoWayCommand { get; }

        /// <summary>
        /// 导航到OneWayToSource绑定示例的命令
        /// </summary>
        public ICommand NavigateToOneWayToSourceCommand { get; }

        /// <summary>
        /// 导航到Default绑定示例的命令
        /// </summary>
        public ICommand NavigateToDefaultCommand { get; }

        /// <summary>
        /// 导航到OneWay绑定示例
        /// </summary>
        private void NavigateToOneWay()
        {
            CurrentViewModel = new OneWayViewModel();
            Title = "WPF绑定模式深入 - OneWay示例";
        }

        /// <summary>
        /// 导航到TwoWay绑定示例
        /// </summary>
        private void NavigateToTwoWay()
        {
            CurrentViewModel = new TwoWayViewModel();
            Title = "WPF绑定模式深入 - TwoWay示例";
        }

        /// <summary>
        /// 导航到OneWayToSource绑定示例
        /// </summary>
        private void NavigateToOneWayToSource()
        {
            CurrentViewModel = new OneWayToSourceViewModel();
            Title = "WPF绑定模式深入 - OneWayToSource示例";
        }

        /// <summary>
        /// 导航到Default绑定示例
        /// </summary>
        private void NavigateToDefault()
        {
            CurrentViewModel = new DefaultBindingViewModel();
            Title = "WPF绑定模式深入 - Default示例";
        }
    }
} 