   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Zal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Зал��5   	   $	��450��6   $	��800��6"    � Icon$# Resouce1\icons8-cinema-64.png��5	      .��5
      � ��5   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $	��17* �6   �� 5      $��4* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinemfilmseans��5         AutoGenerateColumns .     
IsReadOnly . $��20,75,315.6,85q�6]      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$+
 %Назавние кинотеатра��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name_cinema+6d     5      $
 
Город��6%    64   �� *City+6O     5      $#
 Название фильма��6%    6>   �� *	Film_name+6^     5      $
 Дата сеанса��6%    6:   �� *Data_session+6]     5      $
 Время сеанса��6%    6;   �� *Session_time+6^   5         5"   
   -   5        $ Gridzal��5"       .   . $��515,69,35.6,41q�6R   	 5$        5%      $
 Ряд��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6J    62   �� *Row+6X     5&      $
 
Место��6%   $ 50 6M    64   �� *Seat+6Z     5'      $
 Цена��6%   $ 40 6M    63   �� *Price+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5(      $
 auto 6)      CellTemplate 5)      �� 5*      .R�5+      �� $
��Bted��6=   -   5        $ ��Редактировать��5+   %   6^   5,      5.      50      �� 51   
   -   5        $
��Bold"�51      $��14(�6#   $��35��61   $��Добавить��6=   $
��Left=�6P   $��	36,23,0,0q�6k   $��1��6~   $	��Top=�6�   $��75��6�   6�   �� 52   
   -   5        $��Удалить��52      $
��Left=�6#   $��
680,23,0,0q�6>   $��1��6R   $	��Top=�6_   $��75��6w   $��35��6�   $
��Bold"�6�   $��14(�6�   6�   �� 53   
   -   5        $��1��53      $��75��6   $��35��6)   $��Экспорт��65   $
��Bold"�6H   $��14(�6Z   6�   56      57      