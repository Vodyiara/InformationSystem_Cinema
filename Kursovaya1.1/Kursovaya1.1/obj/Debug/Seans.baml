   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.Seans   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	     � Title$  Сеансы��5   	   $��388.24��6   $��739.117��6(    � Icon$# Resouce1\icons8-cinema-64.png��68   .��5
      � $��0,0,-1.2,-0.6q�6   ��5   
   �� 5       �� ImageSource$ Resouce1\фон3.jpg��6   6;    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Gridcinemfilm��5         AutoGenerateColumns .     
IsReadOnly . $	��200��6X   $��4,54,434.8,41.2q�6e      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn
   Header$
 Кинотеатр��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Name_cinema+6Z     5!      $
 
Город��6%    64   �� *City+6O     5"      $#
 Название фильма��6%    6>   �� *	Film_name+6^   5'        5(   
   -   5        $ 
Gridession��5(       .   . $��358,55,28.8,95.2q�6U   	 5*        5+      $
 Дата сеанса��6%    6:   �� *Data_session+6]     5,      $
 Время сеанса��6%    6;   �� *Session_time+6^     5-      $
 Номер зала��6%    69   �� *Lounge_number+6]   4  .System.Windows.Controls.DataGridTemplateColumn  5.         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)      CellTemplate 5/      �� 50      .R�51      �� $
��Bted��6=   -   5        $ ��Редактировать��51   %   6^   52      54      56      �� 57   
   -   5        $��35��57      $��Center=�6   $
��Bold"�68   $��14(�6J   $��Добавить��6X   $
��Left=�6k   $��43,15.8,0,8.4q�6�   $��1��6�   $��75��6�    J� RenderTransformOrigin$ 0.597,-0.281&�6�   6�   �� 58   
   -   5        $��35��58      $��Center=�6   $
��Bold"�69   $��14(�6K   $��Удалить��6Y   $
��Left=�6k   $��1��6�   $��75��6�   $ 0.864,0.521&�6�   $��586,14.8,0,9.4q�6�   �� 59   
   -   5        $��35��59      $��Center=�6   $
��Bold"�69   $��14(�6K   $��Экспорт��6Y   $
��Left=�6k   $��329,14.8,0,9.4q�6�   $��1��6�   $��75��6�   6�   5:      5;      