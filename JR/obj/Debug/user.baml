   M S B A M L   `   `   `  ����=  9JR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JRJR  5   	       JR.user   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:JR     5   	     � Title$
  user��5   	   $	��450��6   $��599.526��6#    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 use��5
      $
��Left=�6       AutoGenerateColumns .     
IsReadOnly . $	��325��6j   $��	10,85,0,0q�6w   $	��Top=�6�   $	��570��6�   $
��Bold"�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6I   	   
FontWeight$	 Normal"�6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ID+6T     5      $ Дата��6>   $ 60 6L   $	 Normal"�6W   
 6%   �� *Date+6W     5      $ 	О чем��6?   $	 350 6N   $	 Normal"�6Z   
 6%   �� *About+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   6L   5      5        5      $ Исполнитель��6@   $	 100 6U   $	 Normal"�6a   
 6%   �� *Famaly+6a   5+      �� 5,   
   -   5         ��Name$ ex��5,      $��
Выйти��6   $
��Left=�6.   $��	480,5,0,0q�6I   $	��Top=�6\   $	��100��6t   $��35��6�   $��18(�6�   $
��Bold"�6�   ���	#FFF48585
�������6�   �� 5-   
   -   5        $	 exc��5-      $��Экспорт Excel��6   $
��Left=�67   $��
283,45,0,0q�6R   $	��Top=�6f   $	��150��6~   $��35��6�   $��18(�6�   $
��Bold"�6�   ���	#FF74D361
�������6�   �� 5.   
   -   5        $
 word��5.      $��Экспорт Word��6    $
��Left=�67   $��
438,45,0,0q�6R   $	��Top=�6f   $	��142��6~   $��35��6�   $��18(�6�   $
��Bold"�6�   ���	#FF7082E4
�������6�   �� 5/   
   -   5        $	 add��5/      $��Добавить��6   $
��Left=�62   $��	11,45,0,0q�6M   $	��Top=�6`   $	��114��6x   $��35��6�   $��18(�6�   $
��Bold"�6�   51      52      