   M S B A M L   `   `   `  ����  MunicipalArchive.    (MunicipalArchive.Windows.WinPlaqueSearch   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��570��5   	   $	��902��6     � WindowStartupLocation$  CenterScreen=�6"   $��20(�6G    � 
ResizeMode$ NoResize=�6U   $��	B Nazanin)�6k   ���	#FF192D6E$��2q�6�    � WindowStyle$
 None=�6�    � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:.5D�6Z   	 g� FillBehavior$	 HoldEnd=�6l   5      5      5      .��5      � $��RightToLeft=�6   ���	#FFEEEEF2.+�5   
   �� -   5        ���	#FF192D6E$��0��5   '   ���	#FFEEEEF2$��30��6a   $	��Top=�6m   �� 5   
   -   5        
 ��Name$
 LblTitle��5      $��انتخاب مالک��6"   $��22(�68   $
��Bold"�6F   $	��Top=�6X      LabelStyle1#���   6�   $��30��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ BtnClose��5      $��×��6#   $��35��6/   $��30��6:   $��22(�6F   $��Arial)�6T   $
��Left=�6u   $	��Top=�6�     ButtonStyle2#���  6�   �� 5   
   -   5        $ BtnMinimize��5      $��-��6&   $��35,0,0,0q�62   $��35��6D   $��30��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   �� 5   
   ���	#FF192D6E$��2q�6)   $��10,35,10,10q�6=    �� CornerRadius$ 10��6R   �� 5   
   $��جست و جو:��6   $��	20,45,0,0q�6$   $	��Top=�67   $��30��6O   $
��Left=�6[   #���   6v   �� 5   
   -   5         ��Name$ 	TxtSearch��5      $
��Left=�6%   $��30��6@   $��
104,45,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6u   $	��774��6�     TextBoxStyle1#���  6�   $��0��6�    �� 	MaxLength$ 50��6�   6�   �� 5   
   -   5        $ BtnNew��5      $��جدید��6!   $��326,516,0,0q�60     ButtonStyle1#���  6E   $��2��6l   $��30��6y   $	��Top=�6�    �� 	IsDefault . $
��Left=�6�   $	��120��6�   6�   �� 5    
   -   5        $ 	BtnSelect��5       $��انتخاب��6$   $��451,516,327,0q�65   #���  6L   $��2��6s    . $��30��6�   $	��Top=�6�   6�   &   System.Windows.Controls.DataGrid  5!   
   -	   5          Name$ 	DgdPlaque��5!      $��
19,80,20,0q�6&     DataGridStyle1#���  6:   ���	#FF192D6E$��2q�6�      AreRowDetailsFrozen .    
IsReadOnly .    GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FF192D6E   AlternatingRowBackground �	#FFF1F4F7 �� AlternationCount$ 2��6=     SelectionMode$ Single=�6R     AutoGenerateColumns .  -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 Once=�6�     CanUserSortColumns .  $	��431��6�  $	��Top=�6  ��6c   Z�    Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ اصلی��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Main+  5%      $ فرعی��6%   $	 120 63    6?   �� *	Secondary+  5&      $ قطعه��6%   $	 120 63    6?   �� *Part+  5'      $ 
توضیح��6%   $	 140 64    6@   �� *Description+5*      5-      5.      