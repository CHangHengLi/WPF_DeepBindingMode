using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingModeDemo.Common
{
    /// <summary>
    /// 所有ViewModel的基类，实现INotifyPropertyChanged接口
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 在属性值更改时发生
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引发PropertyChanged事件
        /// </summary>
        /// <param name="propertyName">已更改的属性的名称</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置字段的值，并在值更改时引发PropertyChanged事件
        /// </summary>
        /// <typeparam name="T">字段和属性的类型</typeparam>
        /// <param name="field">字段引用</param>
        /// <param name="value">字段的新值</param>
        /// <param name="propertyName">公共属性名称</param>
        /// <returns>如果值已更改，则为true，否则为false</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
} 