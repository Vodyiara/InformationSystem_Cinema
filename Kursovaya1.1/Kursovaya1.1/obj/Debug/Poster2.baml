   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Poster2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Постер2��5   	   $	��450��6   $	��800��6&   .��5	      � ��5
   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $	��65* �6   �� 5      $	��19* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinemfilm��5         AutoGenerateColumns .     
IsReadOnly . $	��200��6X   $��14,78,559.6,46.8q�6e      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Кинотеатр��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *Name_cinema+6Z     5      $	 
Город��6%   
 64   �� *City+6O     5      $#	 Название фильма��6%   
 6>   �� *	Film_name+6^   5      �� 5"   
   -   5         ��Name$ imagedirect��5"      $
��Left=�6%   $	��173��6@   $��607,100,0,0q�6M   $	��Top=�6b   $	��143��6z   �� 5#   
   $��3q�6   ���	#FF000000$	��Top=�5$   	   $��565,100,0,0q�6"   $��4��67   $	��173��6H   $	��143��6U   �� 5%   
   -   5        $
��Bold"�5%      $��14(�6#   $��35��61   $#��Добавить постер��6=   $
��Left=�6W   $��59,31.2,0,0q�6r   $	��Top=�6�   $	��125��6�   $��1��6�     5(   
   -   5        $ Griderector��5(       .   . $��270,75,248.6,19.8q�6V    5)      �� 5*      "  6   .�5+      -   5        5,       5.        5/      $	 Автор постера��6%   
 6<   �� *Author+6Y     50      $	 Дата создания��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 95 6[   
 6<   �� *
Datamaking+6h   4  .System.Windows.Controls.DataGridTemplateColumn  53      $
 auto 6)      CellTemplate 54      �� 55      .R�56      �� $
��Bted��6=   -   5        $ ��Редактировать��56   %   6^   57      59      5?      �� 5@   
   -   5        $
��Bold"�5@      $��14(�6#   $��35��61   $��Удалить��6=   $
��Left=�6O   $��687,30.2,0,0q�6j   $��1��6�   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ 0.833,0.561&�6�   �� 5A   
   -	   5        $
��Bold"�5A      $��14(�6#   $��35��61   $��Экспорт��6=   $
��Left=�6O   $��389,31.2,0,0q�6j   $��1��6�   $	��Top=�6�   $��75��6�   $ 0.833,0.561&�6�   5B      5C      