   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Films   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Фильмы��5   	   $	��450��6   $��1558.2��6%   .��5
      � ��5   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinname��5         AutoGenerateColumns .     
IsReadOnly . $��35,40,1217,110.4q�6V   $	��200��6p      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$+	 %Название кинотеатра��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6B   �� *Name_cinema+6e     5      $	 
Город��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6M   
 64   �� *City+6Z   5        5!   
   -   5        $ GridFilm��5!       .   . $��410,0,10,0.4q�6S   ��. $
��Auto=�5"      $
��Auto=�5#      .@�69   > 5$        5%      $#	 Название фильма��6%   $	 110 6\   
 6>   �� *	Film_name+6j     5&      $(	 "Продолжительность��6%   $	 125 6]   
 6@   �� *
Duration+6k     5'      $	 Жанр��6%   $ 60 6M   
 63   �� *genre+6Z     5(      $	 Год выпуска��6%   $ 80 6^   
 6:   �� *Foundation_year+6k     5)      $	 Студия��6%   $ 80 6P   
 65   �� *Studio+6]     5+      $)	 #Возрастной рейтинг��6%   $	 150 6a   
 6A   �� *Film_rating+6o     5,      $*	 $Дата начала проката��6%   $	 150 6i   
 6B   �� *Start_distribution+6w     5-      $	 Конец проката��6%   $	 120 6a   
 6<   �� *End_distribution+6o     5.      $	 Оценка фильма��6%   $	 150 6\   
 6<   �� *Film_scores+6j   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $
 auto 6)      CellTemplate 50      �� 51      .R�52      �� $
��Bted��6=   -   5        $ ��Редактировать��52   %   6^   53      55      58      �� 59   
   -   5        $
��Bold"�59      $��14(�6%   $��Добавить��63   $
��Left=�6F   $��
35,9.6,0,0q�6a   $��1��6u   $��Center=�6�   $	��132��6�    J� RenderTransformOrigin$ 0.597,-0.281&�6�   $��45��6�   �� 5:   
   -   5        $
��Bold"�5:      $��14(�6$   $��Удалить��62   $
��Left=�6D   $��1387,11.6,0,0q�6_   $��1��6v   $��Center=�6�   $	��120��6�   $ 0.864,0.521&�6�   $��45��6�   �� 5;   
   -   5         ��Name$ Export��5;      $
��Bold"�6!   $��14(�63   $��Экспорт��6A   $
��Left=�6S   $��657,10.6,0,0q�6n   $��1��6�   $��Center=�6�   $	��138��6�   $��45��6�   5=      5>      