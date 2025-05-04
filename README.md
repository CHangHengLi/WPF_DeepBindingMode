# WPF绑定模式深入示例

本项目演示了WPF中不同的数据绑定模式，包括OneWay、TwoWay、OneWayToSource和Default四种模式，帮助开发者深入理解WPF的数据绑定机制。
![image](https://github.com/user-attachments/assets/6fe35b2c-c23a-47c9-890a-7fe714527c7a)

## 功能说明

应用程序提供了四个不同的示例页面，分别展示了不同的绑定模式：

1. **OneWay (单向)绑定**：数据从源(ViewModel)到目标(UI)的单向流动，展示了实时时间和温度显示的场景。
   
2. **TwoWay (双向)绑定**：数据在源和目标之间双向流动，通过用户表单展示如何实现UI和ViewModel的双向数据同步。
   
3. **OneWayToSource (反向单向)绑定**：数据从目标(UI)到源(ViewModel)的单向流动，演示如何捕获UI状态（如窗口大小和分隔条位置）。
   
4. **Default (默认)绑定**：展示不同控件的默认绑定行为，包括TextBox(TwoWay)、TextBlock(OneWay)和CheckBox(TwoWay)等。

## 运行要求

- .NET 8.0
- Windows操作系统
- Visual Studio 2022或更高版本

## 项目结构

```
BindingModeDemo/
├── Common/             # 通用工具类和基础类
├── Models/             # 数据模型
├── ViewModels/         # 视图模型
│   ├── OneWayViewModel.cs
│   ├── TwoWayViewModel.cs
│   ├── OneWayToSourceViewModel.cs
│   └── DefaultBindingViewModel.cs
├── Views/              # 视图
│   ├── OneWayView.xaml
│   ├── TwoWayView.xaml
│   ├── OneWayToSourceView.xaml
│   └── DefaultBindingView.xaml
└── MainWindow.xaml     # 主窗口
```

## 绑定模式说明

### OneWay (单向)绑定
- 数据从源属性流向目标属性
- 源属性变化会更新目标属性，但目标属性变化不会影响源属性
- 适用于显示数据的场景（如标签、只读字段等）
- XAML语法：`{Binding PropertyName, Mode=OneWay}`

### TwoWay (双向)绑定
- 数据在源属性和目标属性之间双向流动
- 源属性或目标属性任一方变化，都会更新另一方
- 适用于需要用户输入的场景（如表单、设置页面等）
- XAML语法：`{Binding PropertyName, Mode=TwoWay}`

### OneWayToSource (反向单向)绑定
- 数据从目标属性流向源属性
- 目标属性变化会更新源属性，但源属性变化不会影响目标属性
- 适用于需要捕获UI状态的场景
- XAML语法：`{Binding PropertyName, Mode=OneWayToSource}`

### Default (默认)绑定
- 根据目标依赖属性特性自动选择适当的绑定模式
- 用户交互控件默认为TwoWay（如TextBox.Text, CheckBox.IsChecked）
- 显示控件默认为OneWay（如TextBlock.Text, Image.Source）
- XAML语法：`{Binding PropertyName}`（不指定Mode属性）

## 启动应用程序

1. 打开解决方案文件 `WPF_绑定模式深入.sln`
2. 按F5或点击"开始调试"按钮运行应用程序
3. 使用顶部导航按钮在不同的绑定模式示例之间切换 
