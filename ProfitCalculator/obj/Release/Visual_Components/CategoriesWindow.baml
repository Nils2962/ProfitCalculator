   M S B A M L   `   `   `  ???? K  GProfitCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ProfitCalculator.Visual_Components"ProfitCalculator.Visual_Components  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 9    3ProfitCalculator.Visual_Components.CategoriesWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  <local0clr-namespace:ProfitCalculator.Visual_Components  3System&clr-namespace:System;assembly=mscorlib    ? Title$  
Categories??$??489.301??$??363.072??(  "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush ?	#FF1E1E1E ? Icon$ Pictures/graph_64px.png?????	#FF1E1E1E ? ShowInTaskbar .   ? WindowStartupLocation$ CenterOwner=? ? 
ResizeMode$ NoResize=? ? 	Resources    Grow ?? TargetProperty ?? 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O? KeyTime
 O? Value 
 Shrink 	 Grow2  Shrink2??%  &	        &	 "    &	 n    &	 ?    ?? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$ 	buttonAdd??.\?  $	 0:0:0.1??$

 1.02Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$ 	buttonAdd??.\?  $	 0:0:0.1??$

 1.02Q??? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$ 	buttonAdd??.\?  $	 0??$

 1.02Q?  $	 0:0:0.1??$
 1Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$ 	buttonAdd??.\?  $	 0??$

 1.02Q?  $	 0:0:0.1??$
 1Q??? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$ buttonRemove??.\?  $	 0:0:0.1??$

 1.02Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$ buttonRemove??.\?  $	 0:0:0.1??$

 1.02Q??? .??U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)?$ buttonRemove??.\?  $	 0??$

 1.02Q?  $	 0:0:0.1??$
 1Q?U? $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)?$ buttonRemove??.\?  $	 0??$

 1.02Q?  $	 0:0:0.1??$
 1Q? ? Triggers :?  :? RoutedEvent$ UIElement.MouseEnter?? :? 
SourceName$ 	buttonAdd??.[??? #??[  :? $ UIElement.MouseLeave??$ 	buttonAdd??.[??? -    ??Name$ Shrink_BeginStoryboard??#??[ :? $ UIElement.MouseEnter??$ buttonRemove??.[??? -   $ Grow2_BeginStoryboard??#??[ :? $ UIElement.MouseLeave??$ buttonRemove??.[??? -   $ Shrink_BeginStoryboard1??#??[ .??? $??0q?$	??357?? ? ColumnDefinitions ?? $??6* ??? .+??? -    ??Name$ listBoxCategories??$??0q????	#FF38383B$??1q?
???????$??0????Z? ???? .R?? ???	#FF1E1E1E$??0q?.+???  ?? Orientation$ 
Horizontal=?.+??? $??Pictures/file_64px.png??$??16??$??16???? 
??????? ?? Padding$ 5,0,0,0q?????  ?? Path$
 Name?????  ?? 
TargetType" ?? ?? 	Resources  ?? Color??%C   (??       * SystemColors.HighlightBrushKey+)?? $ 	#FF1E1E1E???? -    ??Name$ 	buttonAdd??$??	11,10,9,0q????	#FF00F700$??0q?$??5q?$??31?? J? RenderTransformOrigin$ 0.5,0.5&?$??1??$??31??$	??Top=?$??Center=?$??1????Z? z?V? .~??? ?? ?? T? .??? .+??? $ ??Pictures/add_file_64px.png??$??0q? J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 1Q?   ShadowDepth$ 0Q??? -   $ buttonRemove??$??	11,49,9,0q?$??31??$??31??
???  ??$??0q?$??5q?$ 0.5,0.5&?$??1??$	??Top=?$??Center=?$??2????Z? z?V? .~??? ?? ?? T? .??? .+??? $#??Pictures/delete_file_64px.png??$??0q?   $ 1Q?$ 0Q?? $
??Left=?$??20??$	??Top=?$??20??