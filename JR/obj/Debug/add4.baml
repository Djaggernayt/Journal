   M S B A M L   `   `   `  ����=  9JR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:JRJR  5   	       JR.add4   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:JR     5   	     � Title$)  #Добавить должность��5   	   $��243.397��6$   $��303.483��65    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�6[   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 use��5
         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6N   $	��100��6i   $��	10,10,0,0q�6v   $	��Top=�6�   $	��268��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6I   	   
FontWeight$	 Normal"�6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ID+6T     5      $ Название��6>   $	 220 6P   $	 Normal"�6\   
 6%   �� *Name+6\   5      �� 5   
   $��Название��6   $
��Left=�6#   $��
10,115,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ tb��5      $
��Left=�6   $��23��69   $��
78,115,0,0q�6E    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��200��6�   �� 5   
   -   5         ��Name$	 add��5      $��Добавить��6   $
��Left=�62   $��
24,162,0,0q�6M   $	��Top=�6a   $	��114��6y   $��35��6�   $��18(�6�   $
��Bold"�6�   �� 5   
   -   5        $
 back��5      $��
Назад��6    $
��Left=�60   $��164,162,0,0q�6K   $	��Top=�6`   $	��114��6x   $��35��6�   $��18(�6�   $
��Bold"�6�   6�   5      5      