   M S B A M L   `   `   `  ����?  ;Xleb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Xleb.Forms
Xleb.Forms  5          Xleb.Forms.SupplyEditForm   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Xleb.Forms     5        N� Title$  SupplyEditForm��5	      .��5      � .+�5   
   � -   5         �Name$ fmGrid��5      $��0,0,0,0q�6   ���	#FF3D3A23 � ColumnDefinitions 5      �� 5      $	��69* �6#   �� 5      $	��52* �6#   �� 5      $	��78* �6#   .+�5      �� -   5         ��Name$ fmLabel��5      $+��%Добавление поставки��6%   $
��Left=�6C   $��0,0,0,0q�6^   $	��Top=�6o   $��16(�6�   $
��Bold"�6�   $��3��6�   
�������6�   �� 5      -   5        $��Записать��5      $��0,6,0,0q�6(   $	��Top=�69   $��Right=�6Q   $��80��6m   $��2��6y   
����������	#FF8F85326�   � 5      $	��Top=�6   $��0,40,0,0q�6+   $��3��6=    5      �� 5      $	��.5* �6'   65   �� 5      $��2* �6'   64    � RowDefinitions 5      �� 5      6&   �� 5      6&   �� 5      6&   �� 5      6&   �� 5       6&   .+�5#      �� $��0��6   $��0��6(   $��id��65   ���	#00000000
�������$
��Bold"�6l   �� 5$      $��1��6   $��0��6*    �� 
IsReadOnly$
 True��6L   ${�False��6^   ��67   �� *Id+6^   �� 5&      $��0��6   $��1��6(   $��Пекарня��65   $
��Bold"�6G   
�������6Y   �� 5'      -   5        $��fmBakery��5'      $��1��6+   $��1��6;    �� 
IsEditable$
 True��6g    �� 
IsReadOnly$
 True��6y    �� Text 6H   �� *Bakeries.Name+6y   �� 5)      $��0��6   $��2��6(   $��Продукт��65   
�������$
��Bold"�6Z   �� 5*      -   5        $��	fmProduct��5*      $��1��6,   $��2��6<   $
 True��6g   $
 True��6y    6I   �� *Product.Name+6y   �� 5,      $��0��6   $��3��6(   $��Поставщик��65   
�������$
��Bold"�6\   �� 5-      -   5        $��
fmSupplier��5-      $��1��6-   $��3��6=   $
 True��6i   $
 True��6{    6J   �� *Supplier.Name+6{   5.      5/      50      51      