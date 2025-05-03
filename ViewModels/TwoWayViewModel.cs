using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using BindingModeDemo.Common;
using BindingModeDemo.Models;

namespace BindingModeDemo.ViewModels
{
    /// <summary>
    /// TwoWay绑定示例的ViewModel
    /// </summary>
    public class TwoWayViewModel : ViewModelBase
    {
        private string _userName;
        private int _age;
        private string _email;
        private bool _isActive;
        private double _notificationFrequency;
        private User _user;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TwoWayViewModel()
        {
            // 初始化默认值
            _user = new User
            {
                Id = Guid.NewGuid().ToString("N"),
                UserName = "张三",
                Age = 30,
                Email = "zhangsan@example.com",
                IsActive = true,
                NotificationFrequency = 5.0,
                CreationDate = DateTime.Now
            };

            // 从模型加载到ViewModel属性
            _userName = _user.UserName;
            _age = _user.Age;
            _email = _user.Email;
            _isActive = _user.IsActive;
            _notificationFrequency = _user.NotificationFrequency;

            // 初始化命令
            ResetCommand = new RelayCommand(_ => ResetForm());
            SaveCommand = new RelayCommand(_ => SaveUser(), _ => IsValid());
        }

        /// <summary>
        /// 用户名属性
        /// </summary>
        public string UserName
        {
            get => _userName;
            set
            {
                if (SetProperty(ref _userName, value))
                {
                    OnPropertyChanged(nameof(UserSummary));
                    CommandManager.InvalidateRequerySuggested(); // 刷新命令可执行状态
                }
            }
        }

        /// <summary>
        /// 年龄属性
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (SetProperty(ref _age, value))
                {
                    OnPropertyChanged(nameof(UserSummary));
                }
            }
        }

        /// <summary>
        /// 电子邮件属性
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                if (SetProperty(ref _email, value))
                {
                    OnPropertyChanged(nameof(UserSummary));
                    CommandManager.InvalidateRequerySuggested(); // 刷新命令可执行状态
                }
            }
        }

        /// <summary>
        /// 账户是否活跃
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (SetProperty(ref _isActive, value))
                {
                    OnPropertyChanged(nameof(UserSummary));
                }
            }
        }

        /// <summary>
        /// 通知频率
        /// </summary>
        public double NotificationFrequency
        {
            get => _notificationFrequency;
            set
            {
                if (SetProperty(ref _notificationFrequency, value))
                {
                    OnPropertyChanged(nameof(UserSummary));
                }
            }
        }

        /// <summary>
        /// 用户信息摘要
        /// </summary>
        public string UserSummary
        {
            get
            {
                StringBuilder summary = new StringBuilder();
                summary.AppendLine($"用户名: {UserName}");
                summary.AppendLine($"年龄: {Age}");
                summary.AppendLine($"邮箱: {Email}");
                summary.AppendLine($"账户状态: {(IsActive ? "活跃" : "非活跃")}");
                summary.AppendLine($"通知频率: 每{NotificationFrequency:F1}天一次");

                return summary.ToString();
            }
        }

        /// <summary>
        /// 重置命令
        /// </summary>
        public ICommand ResetCommand { get; }

        /// <summary>
        /// 保存命令
        /// </summary>
        public ICommand SaveCommand { get; }

        /// <summary>
        /// 重置表单
        /// </summary>
        private void ResetForm()
        {
            UserName = "张三";
            Age = 30;
            Email = "zhangsan@example.com";
            IsActive = true;
            NotificationFrequency = 5.0;
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        private void SaveUser()
        {
            // 更新模型对象
            _user.UserName = UserName;
            _user.Age = Age;
            _user.Email = Email;
            _user.IsActive = IsActive;
            _user.NotificationFrequency = NotificationFrequency;

            // 在实际应用中，这里会将用户信息保存到数据库或发送到服务器
            MessageBox.Show($"用户 {UserName} 的信息已保存！", "保存成功",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 验证表单是否有效
        /// </summary>
        private bool IsValid()
        {
            // 简单验证示例
            if (string.IsNullOrWhiteSpace(UserName))
                return false;

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                return false;

            if (Age <= 0 || Age > 120)
                return false;

            return true;
        }
    }
} 