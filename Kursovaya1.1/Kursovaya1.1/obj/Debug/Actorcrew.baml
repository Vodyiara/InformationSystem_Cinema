   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Actorcrew   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Актеры��5   	   $	��450��6   $��1159.161��6%    � Icon$# Resouce1\icons8-cinema-64.png��66   .��5	      � $��0,0,4,0q�6   ��5   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinemfilm��5         AutoGenerateColumns .     
IsReadOnly . $	��200��6X   $��18,79,868.8,71.4q�6e      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Кинотеатр��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Name_cinema+6Z     5      $
 
Город��6%    64   �� *City+6O     5      $#
 Название фильма��6%    6>   �� *	Film_name+6^   5        5!   
   -   5        $ 	Gridacter��5!       .   . $��290,60,212.8,20.4q�6T    5"      �� 5#      "  6   .�5$      -   5        5%      	 5(        5)      $
 Имя актера��6%    69   �� *FIO+6S     5*      $
 Страна��6%    65   �� *	Country+6S     5+      $
 Год рождения ��6&    6=   �� *
Birth_year+6^     5,      $
 Роль в фильме��6%    6<   �� *Gender+6Y     5-      $)
 #Количество фильмов��6%    6A   �� *
Filmplayed+6b     5.      $'
 !Количество наград��6%    6@   �� *
Filmawards+6a   4  .System.Windows.Controls.DataGridTemplateColumn  50         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)      CellTemplate 51      �� 52      .R�53      �� $
��Bted��6=   -   5        $ ��Редактировать��53   %   6^   54      56      5:      �� 5;   
   -   5        $
��Bold"�5;      $��14(�6#   $��Добавить��61   $
��Left=�6D   $��41,18.6,0,0q�6_   $��1��6t   $	��Top=�6�   $��35��6�   $��75��6�    J� RenderTransformOrigin$ 0.597,-0.281&�6�   6�   �� 5<   
   -   5        $
��Bold"�5<      $��14(�6#   $��Удалить��61   $
��Left=�6C   $��1��6_   $	��Top=�6l   $��75��6�   $��35��6�   $ 0.864,0.521&�6�   $��1029,18.6,0,0q�6�   �� 5=   
   -   5        $
��Bold"�5=      $��14(�6#   $��Экспорт��61   $
��Left=�6C   $��530,17.6,0,0q�6^   $��1��6t   $	��Top=�6�   $��75��6�   $��35��6�   6�   �� 5@      -	   5         ��Name$ Imageact��5@      $
��Left=�6'   $
��Fill=�6B   $	��181��6Q   $��997,105,0,0q�6^   $	��Top=�6s   $	��125��6�   �� 5A   
   $��3q�6   ���	#FF000000$	��Top=�5B   	   $��970,105,0,0q�6"   $��4��67   $	��181��6H   $	��125��6U   5G      5H      