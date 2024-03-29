﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;
using library_architecture_mvvm_modify_c_sharp;

namespace template_for_lamm_c_sharp;

public sealed class MainWindowView : Window
{
    /// RELEASE CODE
    // private MainWindowViewModel? viewModel;
    /// TEST CODE
    private TestMainWindowViewModel? viewModel;

    public MainWindowView()
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            /// RELEASE CODE
            // viewModel = new MainWindowViewModel();
            /// TEST CODE
            viewModel = new TestMainWindowViewModel();
            InitWindow();
            InitParameterViewModel();
            BuildParameterViewModel();
        });
    }

    protected override void OnStateChanged(EventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            if(WindowState == WindowState.Minimized)
            {
                Hide();
                base.OnStateChanged(e);
                return;
            }
            Show();
            base.OnStateChanged(e);
        });
    }

    protected override void OnClosed(EventArgs e)
    {
        ExceptionHelperUtility.CallExceptionHelperFromThisClassAndCallback(this,() => 
        {
            viewModel?.Dispose();
            base.OnClosed(e);
        });
    }

    private void InitWindow() 
    {
        Title = "Example";
        Height = 400;
        Width = 600;
        MinHeight = 400;
        MinWidth = 600;
        MaxHeight = 400;
        MaxWidth = 600;
        Icon = BitmapFrame.Create(new Uri(@"../build/Assets/Icon/CoinsDollar32.ico",UriKind.RelativeOrAbsolute));
        ResizeMode = ResizeMode.NoResize;
        WindowState = WindowState.Normal;
        Closing += ClosingFromSenderAndE;  
        TaskbarIcon taskbarIcon = new()
        {
            ToolTipText = "TemplateForLAMMCSharp",
            Icon = new System.Drawing.Icon(@"../build/Assets/Icon/CoinsDollar32.ico")
        };
        taskbarIcon.TrayLeftMouseUp += TrayLeftMouseClickFromSenderAndE;
        taskbarIcon.TrayLeftMouseDown += TrayLeftMouseClickFromSenderAndE;
    }

    private async void InitParameterViewModel() 
    {
        viewModel?.ListenStreamDataForNamedFromCallbackParameterNamedStreamWState((data) =>
        {
            BuildParameterViewModel();
        });
        var result = await viewModel!.Init();
        Utility.DebugPrint($"MainWindowView: {result}");
        viewModel.NotifyStreamDataForNamedParameterNamedStreamWState();
    }
    
    private void BuildParameterViewModel() 
    {
        var dataForNamedParameterNamedStreamWState = viewModel?.GetDataForNamedParameterNamedStreamWState();
        switch(dataForNamedParameterNamedStreamWState?.GetEnumDataForNamed()) 
        {
            case EnumDataForMainWindowView.isLoading:
                Grid gridWIsLoading = new();
                gridWIsLoading.Children.Add(new Ellipse() {
                    Width = 50,
                    Height = 50,
                    Fill = new SolidColorBrush(Colors.Black),
                    VerticalAlignment = VerticalAlignment.Center
                });
                Content = gridWIsLoading;
                break;
            case EnumDataForMainWindowView.exception:
                Grid gridWException = new();
                gridWException.Children.Add(new TextBlock() {
                    Text = dataForNamedParameterNamedStreamWState.exceptionController.GetKeyParameterException(),
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWException;
                break;
            case EnumDataForMainWindowView.success:
                Grid gridWSuccess = new();
                gridWSuccess.Children.Add(new TextBlock() {
                    Text = "Success",
                    FontSize = 16.0,
                    Foreground = new SolidColorBrush(Colors.Black)
                });
                Content = gridWSuccess;
                break;
            default:
                break;            
        }
    }

    private void ClosingFromSenderAndE(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
        WindowState = WindowState.Minimized;
        ShowInTaskbar = true;
    }

    private void TrayLeftMouseClickFromSenderAndE(object sender, RoutedEventArgs e)
    {
        Show();
        WindowState = WindowState.Normal;
    }
}   