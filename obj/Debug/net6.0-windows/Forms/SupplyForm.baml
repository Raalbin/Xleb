   M S B A M L   `   `   `  ����?  ;Xleb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Xleb.Forms
Xleb.Forms  5          Xleb.Forms.SupplyForm   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Xleb.Forms     5      -   5          N� Title$  
SupplyForm��5	      .��5      � .+�5   
   � ���	#FF3D3A23.+�5      �� $#��Список поставок��6   $
��Left=�6.   $��0,0,0,0q�6I   $	��Top=�6Z   $��16(�6r   $
��Bold"�6�   
�������6�   �� 5      -   5        $��Добавить��5      $��0,6,0,0q�6(   $	��Top=�69   $��Right=�6f   $��80��6�   ���	#FF8F8532$
��Bold"�6�   ���	#FFF7F2F26�   �� 5      $��Right=�6   $��17��60   $��	0,8,210,0q�6<   $	��Top=�6O   $��17��6g   $��UniformToFill=�6s    J� RenderTransformOrigin$ 0.961,0.549&�6�   z�5      V� 5      .~�5      ��  �� ScaleX$ -1Q�6)   �� 5      �� 5      T� 5       T� X$ -15.674Q�6-   5      5      �� 5      -   5         ��Name$ tbSearch��5      $��0,7,85,0q�6(    �� TextWrapping$
 Wrap=�6:   $	��Top=�6q   $��Right=�6�   $	��120��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	fDataGrid��5      $��0,32,0,0q�6*      FrozenColumnCount$ 1��6<    �� IsTextSearchEnabled$
 True��6R   	   AutoGenerateColumns$	 False��6m   
   
IsReadOnly$

 True��5       J� IsManipulationEnabled$
 True��6%   $��Stretch=�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 68   ���	#FF3D3A23���	#FF141313$
��Bold"�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6)      MaxWidth$ 40Q�6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5      $ Пекарня��6)      MinWidth$	 200Q�6]    6;   �� *Bakeries.Name+6]     5       $ Продукт��6)    6:   �� *Products.Name+  5!      $ Поставщик��6)    6<   �� *Suppliers.Name+5#      5&      5'      5(      