   M S B A M L   `   `   `  ???? K  GProfitCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProfitCalculator.Visual_Components"ProfitCalculator.Visual_Components  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem ;    5ProfitCalculator.Visual_Components.NewCategorieWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  <local0clr-namespace:ProfitCalculator.Visual_Components  3System&clr-namespace:System;assembly=mscorlib  -   (  "MahApps.Metro.Controls.MetroWindow   Name$  window?? ? Title$ 
Categories??$??97.617??$??301.748??   WindowTitleBrush ?	#FF1E1E1E ? Icon$ Pictures/graph_64px.png?????	#FF1E1E1E ? 
ResizeMode$ CanMinimize=? ? ShowInTaskbar .   ? WindowStartupLocation$ CenterOwner=? ? 	Resources    Grow ?? TargetProperty	 ?? 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O? KeyTime O? Value 
 Shrink??%?  &	        &	 "    ?? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$	 	buttonAdd??.\?  $
 0:0:0.1??$
 1.02Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$	 	buttonAdd??.\?  $
 0:0:0.1??$
 1.02Q??? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$	 	buttonAdd??.\?  $
 0??$
 1.02Q?  $
 0:0:0.1??$ 1Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$	 	buttonAdd??.\?  $
 0??$
 1.02Q?  $
 0:0:0.1??$ 1Q? ? Triggers :?  :? RoutedEvent$ UIElement.MouseEnter?? :? 
SourceName$ 	buttonAdd??.[??? #??[  :? $ UIElement.MouseLeave??$ 	buttonAdd??.[??? -    ??Name$ Shrink_BeginStoryboard??#??[ .??? $??0q?.+??? -    ??Name$ 	buttonAdd??$	??ADd??$??Right=?$??0,0,5,5q?$??Bottom=?$??88?????	#FF00F700$??0q? J? RenderTransformOrigin$ 0.5,0.5&?$??1????Z? z?V? .~??? ?? ?? T? ?? -    ??Name$ textBoxName??$??23??$??5,5,5,0q? ?? TextWrapping$
 Wrap=?$	??Top=????	#FF38383B
???????$??0????Z? 