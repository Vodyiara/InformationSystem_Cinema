   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Reziser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Режиссер��5   	   $	��450��6   $��1093.2��6'    � Icon$# Resouce1\icons8-cinema-64.png��66   .��5	      � $��	0,0,3.6,0q�6   ��5
   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $	��71* �6   �� 5      $	��13* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinemfilm��5         AutoGenerateColumns .     
IsReadOnly . $	��200��6X   $��25,80,747.8,75.2q�6e      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Кинотеатр��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Name_cinema+6Z     5      $
 
Город��6%    64   �� *City+6O     5      $#
 Название фильма��6%    6>   �� *	Film_name+6^   5        5    
   -   5        $ Griderector��5        .   . $��360,80,277.8,15.2q�6V    5!      �� 5"      "  6   .�5#      -   5        5$      	 5&        5'      $
 Имя режиссра��6%    6;   �� *FIO+6U     5(      $
 Страна��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 55 6Q    65   �� *	Country+6^     5)      $
 Возраст��6%   $ 55 6N    66   �� *FIO+6[     5*      $(
 "Должность в фильме��6%   $	 125 6\    6A   �� *Gender+6j     5+      $
 Снято фильмов��6%    6<   �� *Filmdirected+6_     5,      $
 Кинонаград��6%    69   �� *
Filmawards+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $
 auto 6)      CellTemplate 50      �� 51      .R�52      �� $
��Bted��6=   -   5        $ ��Редактировать��52   %   6^   53      55      5;      �� 5<   
   -   5        $��35��5<      $
��Bold"�6   $��14(�6/   $��Добавить��6=   $
��Left=�6P   $��47,15.8,0,0q�6k   $��1��6�   $	��Top=�6�   $��75��6�   6�   �� 5=   
   -   5        $��35��5=      $
��Bold"�6   $��14(�6/   $��Удалить��6=   $
��Left=�6O   $��933,16.8,0,0q�6j   $��1��6�   $	��Top=�6�   $��74��6�    J� RenderTransformOrigin$ 0.498,0.941&�6�   �� 5>   
   -   5        $��35��5>      $
��Bold"�6   $��14(�6/   $��Экспорт��6=   $
��Left=�6O   $��457,13.8,0,0q�6j   $��1��6�   $	��Top=�6�   $��75��6�   6�   �� 5?   
   -	   5         ��Name$ imagedirect��5?      $
��Left=�6%   $
��Fill=�6@   $	��140��6O   $��
888,96,0,0q�6\   $	��Top=�6p   $	��125��6�   �� 5@   
   $��3q�6   ���	#FF000000$	��Top=�5A   	   $��1��6!   $��
819,96,0,0q�61   $��4��6E   $	��140��6V   $	��125��6c   5B      5C      