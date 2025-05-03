using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BindingModeDemo.Common
{
    /// <summary>
    /// 将布尔值转换为Visibility枚举值的转换器
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 当值从源传播到目标时，将源数据从bool转换为Visibility
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // 如果参数存在且为字符串"Invert"，则反转转换逻辑
                bool invert = parameter is string paramStr && paramStr.Equals("Invert", StringComparison.OrdinalIgnoreCase);
                
                boolValue = invert ? !boolValue : boolValue;
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            
            return Visibility.Collapsed;
        }

        /// <summary>
        /// 当值从目标传播回源时，将Visibility转换回bool
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                // 如果参数存在且为字符串"Invert"，则反转转换逻辑
                bool invert = parameter is string paramStr && paramStr.Equals("Invert", StringComparison.OrdinalIgnoreCase);
                
                bool result = visibility == Visibility.Visible;
                return invert ? !result : result;
            }
            
            return false;
        }
    }
} 