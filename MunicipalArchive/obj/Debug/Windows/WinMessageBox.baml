   M S B A M L   `   `   `  ����  MunicipalArchive,    &MunicipalArchive.Windows.WinMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � SizeToContent$  WidthAndHeight=�5   	   $	��220��6(   $	��555��68   $	��700��6H   $	��400��6W    � WindowStartupLocation$ CenterScreen=�6f    � WindowStyle$
 None=�6�   $��20(�6�    � 
ResizeMode$ NoResize=�6�   $��	B Nazanin)�6�   ���	#FF192D6E$��2q�6�   $	��357��6   � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S   	 g� Duration$	 0:0:.5D�6Z   
 g� FillBehavior$
 HoldEnd=�6l   5      5      5      .��5      � $��RightToLeft=�6   ���	#FFEEEEF2.+�5   
   �� -   5        ���	#FF2D2D30$��0��5   '   ���	#FFEEEEF2$��30��6a   $	��Top=�6m   �� 5   
   -   5         ��Name$ LblTitle��5      $��22(�6"   $
��Bold"�60   $��0q�6B   $	��Top=�6M      LabelStyle1#���   6z   $��30��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ BtnClose��5      $��×��6#   $��35��6/   $��30��6:   $��22(�6F   $��Arial)�6T   $
��Left=�6u   $	��Top=�6�     ButtonStyle2#���  6�   �� 5   
   -   5        $ BtnMinimize��5      $��-��6&   $��35,0,0,0q�62   $��35��6D   $��30��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   �� 5   
   ���	#FF192D6E$��2q�6)   $��10,35,10,10q�6=    �� CornerRadius$ 10��6R   �� 5   
   -   5         ��Name$ 
TxtMessage��5      $��135,55,30,60q�6(   $	��450��6>   $	��535��6N   $
��Wrap=�6]    �� TextAlignment$ Justify=�6q   $	��Top=�6�   $
��Left=�6�   �� 5   
   -   5         ��Name$ 
ImgMessage��5      $��../Icon/Correct.png��6$   $��	30,55,0,0q�6A   $��90��6T   $��90��6_   $
��Left=�6k   $	��Top=�6�   �� 5   
   -   5        $ BtnOk��5      $��قبول��6    $��0,0,0,20q�6/   $	��120��6A     ButtonStyle1#���  6M   $��1��6t    �� 	IsDefault . $��30��6�   $��Bottom=�6�   $��Center=�6�   6�   �� 5   
   -	   5        $ BtnYes��5      $��بلی��6!   $��76,0,200,20q�6/   $	��120��6D   #���  6P   $��1��6w    . $��30��6�   $��Bottom=�6�   $��Center=�6�   $y�Hidden=�6�   �� 5   
   -
   5        $ BtnNo��5      $��خیر��6    $��201,0,75,20q�6.   $	��120��6C   #���  6O   $��2��6v   $��30��6�   $��Bottom=�6�   $��Center=�6�   $y�Hidden=�6�    �� IsCancel . 6�   5"      5#      