   M S B A M L   `   `   `  ����G  CKursovaya1.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kursovaya1._1Kursovaya1._1  5   	       Kursovaya1._1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Kursovaya1._1     5   	   -   5          � Title$+  %Редактор кинотеатра��5   	   $��376.4��6%   $��938.1��64    � Icon$# Resouce1\icons8-cinema-64.png��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��50 �6   .+�5   
   �� $��1��6   ���#f4bf0662   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgridCinema��5      $��2��6(   $��0,-1,0,1q�6<    J� RenderTransformOrigin$ 0.5,0.5&�6N      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $	��932��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.592Q�6&   T� 5      5         Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$+	 %Название кинотеатра��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name_cinema+6p     5#      $	 
Город��6%   $
 70 6M    64   �� *City+6Z     5$      $'	 !Адресс кинотеатра��6%   $	
 130 6c    6@   �� *Address_cinema+6q     5%      $)	 #Телефон кинотеатра��6%   $	
 130 6f    6A   �� *Telephone_number+6t     5&      $)	 #Количество фильмов��6%   $	
 130 6b    6A   �� *Number_films+6p     5'      $'	 !Количетво сеансов��6%   $	
 130 6c    6@   �� *Number_session+6q     5(      $	 Время работы��6%   $	
 130 6_    6;   �� *Work_timecinema+6m   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $

 auto 6)      CellTemplate 5*      �� 5+      .R�5,      ��  ��Name$ BtnEdit��6%   -   5        $ ��Редкатировать��5,   6   6f   5.      51      53      �� 55   
   -   5        $��Удалить��55      $
��Bold"�6#   $��14(�65   $
��Left=�6C   $��859,309,0,0q�6s   $��79��6�   $��2��6�   �� 56   
   -   5        $��Добвавить��56      $
��Bold"�6&   $��14(�68   $
��LEft=�6F   $��70��6x   $��	0,2,0,0.4q�6�   $��1��6�   �� 57   
   -   5        $��Экспорт��57      $
��Bold"�6#   $��14(�65   $��1��6D   $��Center=�6Q   $��1��6�   $��95��6�   $��415,0,422,0.4q�6�   6�   58      59      