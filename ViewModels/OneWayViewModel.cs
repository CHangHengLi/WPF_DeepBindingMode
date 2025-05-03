using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using BindingModeDemo.Common;

namespace BindingModeDemo.ViewModels
{
    /// <summary>
    /// OneWay绑定示例的ViewModel
    /// </summary>
    public class OneWayViewModel : ViewModelBase
    {
        private DispatcherTimer _timer;
        private DateTime _currentTime;
        private double _temperature;
        private readonly Random _random = new Random();

        /// <summary>
        /// 构造函数
        /// </summary>
        public OneWayViewModel()
        {
            // 初始化数据
            _currentTime = DateTime.Now;
            _temperature = 20.0 + _random.NextDouble() * 10;

            // 创建刷新命令
            RefreshCommand = new RelayCommand(async _ => await RefreshDataAsync());

            // 设置定时器以模拟数据变化
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // 每秒更新一次
            };
            _timer.Tick += (s, e) =>
            {
                // 更新时间
                CurrentTime = DateTime.Now;

                // 随机波动温度
                Temperature += (_random.NextDouble() - 0.5);
            };
            _timer.Start();
        }

        /// <summary>
        /// 当前时间属性
        /// </summary>
        public DateTime CurrentTime
        {
            get => _currentTime;
            private set => SetProperty(ref _currentTime, value);
        }

        /// <summary>
        /// 温度属性
        /// </summary>
        public double Temperature
        {
            get => _temperature;
            private set => SetProperty(ref _temperature, value);
        }

        /// <summary>
        /// 刷新命令
        /// </summary>
        public ICommand RefreshCommand { get; }

        /// <summary>
        /// 模拟从服务器刷新数据
        /// </summary>
        private async Task RefreshDataAsync()
        {
            // 模拟网络延迟
            await Task.Delay(500);

            // 更新温度数据
            Temperature = 20.0 + _random.NextDouble() * 10;
        }
    }
} 