   M S B A M L   `   `   `  ????U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5       ProfitCalculator6   0ProfitCalculator.Visual_Components.MaterialCards   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      -   5          >?Name$  userControl??5      $??273.839??5      $??448.364??60    J? RenderTransformOrigin$ 0.5,0.5&?6@    ? 	Resources 5         Grow ?? TargetProperty ?? 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O? KeyTime O? Value 
 Shrink??%?  &	        &	 ?    ?? 5	   
   .??5
      U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?6,   $ userControl??6?   .\?5        $ 0:0:0.1??6'   $
 1.02Q?69   5      U? 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?6,   $ userControl??6?   .\?5        $ 0:0:0.1??6'   $
 1.02Q?69   5      5      ?? 5   
   .??5      U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?6,   $ userControl??6?   .\?5        $ 0??6'   $
 1.02Q?63     5      $ 0:0:0.1??6'   $ 1Q?69   5      U? 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?6,   $ userControl??6?   .\?5        $ 0??6'   $
 1.02Q?63     5      $ 0:0:0.1??6'   $ 1Q?69   5      5      5      z?5      V? 5   
   .~?5      ?? ?? 5      ?? 5       T? 5!      5"       ? Triggers 5$      :? 5%   
    :? RoutedEvent$ UIElement.MouseEnter??6   .[?5&      ?? -   5        	 ??Name$	 Grow_BeginStoryboard??5&      #??[  6<   5'      :? 5(   
   $ UIElement.MouseLeave??6   .[?5)      ?? #??[ 6   5*      .??5,      ? .+?5-   
   #   LiveCharts.Wpf.CartesianChart  -   5        
  Name$
 chart??5-      &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=?6,      Zoom$ Xy=?6C   
???????   AxisY 5/         LiveCharts.Wpf.Axis     Title$ Profit??6      LabelFormatter 6*   ?? *
YFormatter+6R      AxisX 52        $
 Date??6      Labels 6(   ?? *Labels+6D   54      55      56      