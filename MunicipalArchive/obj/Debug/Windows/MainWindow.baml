   M S B A M L   `   `   `  ����K  GMunicipalArchive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MunicipalArchiveMunicipalArchive  5   	   )    #MunicipalArchive.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;municipalArchiveclr-namespace:MunicipalArchive     5   	   -   5          � Title$  
MainWindow��5   	   $	��640��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6\    � 
ResizeMode$ NoResize=�6o   $��20(�6�   $��	B Nazanin)�6�    � 	Resources 5	         OnMouseLeftButtonDown1 �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible	 R� Value
   	Collapsed9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value  OnMouseLeftButtonDown2��%;  &	        &	 e    �� 5
   
   .��5      T� $ (UIElement.Visibility)�6,   $ BtnMenue��6_   ..�5      i� $ 0��6)   #	 Z 65   i� 5      $ 0:0:0.5��6)   #	 Z
 6;   5      T� 5      $ (UIElement.Visibility)�6,   $ BtnBack��6_   ..�5      i� $ 0��6)   #	 Z 65   i� 5      $ 0:0:0.5��6)   #	 Z 6;   5      U� 5      $ (UIElement.Opacity)�6,   $ BtnMenue��6\   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.5��6'   $ 0Q�69   5      U� 5      $ (UIElement.Opacity)�6,   $ BtnBack��6\   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $ 1Q�69   5      r� 5      $ (FrameworkElement.Margin)�6/   $ 
StackPanel��6e   .	�5        $ 0��6*   $ 1000,0,-300,0q�66     5      $ 0:0:0.5��6*   $ 	700,0,0,0q�6<   5      5      �� 5    
   .��5!      r� $ (FrameworkElement.Margin)�6/   $ 
StackPanel��6e   .	�5"        $ 0��6*   $ 	700,0,0,0q�66     5#      $ 0:0:0.5��6*   $ 1000,0,-300,0q�6<   5$      U� 5%      $ (UIElement.Opacity)�6,   $ BtnBack��6\   .\�5&        $ 0��6'   $ 1Q�63     5'      $ 0:0:0.5��6'   $ 0Q�69   5(      U� 5)      $ (UIElement.Opacity)�6,   $ BtnMenue��6\   .\�5*        $ 0��6'   $ 0Q�63     5+      $ 0:0:0.5��6'   $ 1Q�69   5,      T� 5-      $ (UIElement.Visibility)�6,   $ BtnMenue��6_   ..�5.      i� $ 0��6)   #	 Z
 65   i� 5/      $ 0:0:0.5��6)   #	 Z 6;   50      51      52       � Triggers 53      :� 54   
    :� RoutedEvent$# UIElement.MouseLeftButtonDown��6    :� 
SourceName$ BtnMenue��6C   .[�55      �� #��[  6   56      :� 57   
   $# UIElement.MouseLeftButtonDown��6   $ BtnBack��6C   .[�58      �� -   5         ��Name$+ %OnMouseLeftButtonDown2BeginStoryboard��58      #��[ 6M   59      .��5=      � 
�������.+�5>   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��640��6T   $��0q�6a   $	��Top=�6l   $
��1000��6�   �� 5?   
   -   5        ���	#FF192D6E$��1��5?   '   ���	#FF419FD9$��40��6a   $	��Top=�6m   �� 5@   
   -   5         ��Name$ LblTitle��5@      $��بایگانی��6"   $��22(�64   $
��Bold"�6B   $��0q�6T   $	��Top=�6_     LabelStyle1#���  6�   $��40��6�   $��Center=�6�   
�������6�   �� 5A   
   -   5         ��Name$ 
BtnUpClose��5A      $��×��6%   $��38��61   $��38��6<   $��22(�6H   $��Arial)�6V   $
��Left=�6w   $	��Top=�6�     ButtonStyle2#���  6�   $��1,1,0,0q�6�   
�������6�   �� 5B   
   -   5        $ BtnMinimize��5B      $��-��6&   $��39,1,0,0q�62   $��38��6D   $��38��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   
�������6�   � 5C   
   $��0,40,0,0q�6   .+�5D      %   MunicipalArchive.CustomControl1  -   5          Name$ BtnFile��5D   .   %   MunicipalArchive.CustomControl1   MouseLeftButtonDown$! BtnFile_MouseLeftButtonDown��6�   $
��Left=�6?   $��
339,10,0,0q�6Z   $	��Top=�6n   $	��190��6�   $	��323��6�      SettingText$( "ثبت اطلاعات پرونده��6�      SettingImageSource$ ../Icon/File.png��6�   6�     5E      -   5        $ 	BtnPerson��5E   .   $# BtnPerson_MouseLeftButtonDown��6�   $
��Left=�6A   $��	11,10,0,0q�6\   $	��Top=�6o   $	��190��6�   $	��323��6�   $( "ثبت اطلاعات مالکین��6�   $ ../Icon/Person.png��6�   6�     5F      -	   5        $ 	BtnSearch��5F   .   $# BtnSearch_MouseLeftButtonDown��6�   $
��Left=�6A   $��
667,10,0,0q�6\   $	��Top=�6p   $	��190��6�   $	��323��6�   $ جست و جو��6�   $1 +/MunicipalArchive;component/Icon/Search.png��6�   6�   5G      �� 5H   
   -
   5         ��Name$ 
StackPanel��5H      $��1000,0,-300,0q�6)   ���	#FFCCCCCC$	��300��6W   .+�5I      $   MunicipalArchive.CustomControl     SettingText$! اطلاعات کاربری��6-      SettingImageSource$ ../Icon/UserInfo.png��6J   $��
10,40,10,5q�6t   $��50��6�   $��0q�6�     5J      -   5          Name$ 
BtnAddUser��5J   -   $   MunicipalArchive.CustomControl   MouseLeftButtonDown$$ BtnAddUser_MouseLeftButtonDown��6�   $  ثبت کاربر جدید��6A   $ ../Icon/AddUser.png��6^   $��	10,5,10,5q�6�   $��50��6�   6�     5K      -   5        $ 	BtnBackUp��5K   -   $# BtnBackUp_MouseLeftButtonDown��6�   $1 +پشتیبان گیری از اطلاعات��6@   $ ../Icon/Backup.png��6f   $��	10,5,10,5q�6�   $��50��6�   6�     5L      -   5        $ BtnAutoBackUp��5L   -   $' !BtnAutoBackUp_MouseLeftButtonDown��6�   $5 /مشاهده پشتیبان های خودکار��6D   $ ../Icon/RestoreAll.png��6l   $��	10,5,10,5q�6�   $��50��6�   6�     5M      -   5        $ 
BtnRestore��5M   -   $$ BtnRestore_MouseLeftButtonDown��6�   $. (بازنشانی فایل پشتیبان��6A   $ ../Icon/Restore.png��6e   $��	10,5,10,5q�6�   $��50��6�   6�     5N      $* $بروزرسانی نرم افزار��6-   $ ../Icon/Update.png��6O   $��	10,5,10,5q�6w   $��50��6�     5O      -   5        $ BtnChangePassword��5O   -   $+ %BtnChangePassword_MouseLeftButtonDown��6�   $" تغییر کلمه عبور��6H   $  ../Icon/ChangePassword.png��6f   $��	10,5,10,5q�6�   $��50��6�   6�     5P      $ راهنما��6-   $ ../Icon/Help.png��6B   $��	10,5,10,5q�6h   $��50��6{     5Q      $ درباره ی ما��6-   $ ../Icon/AboutUs.png��6G   $��	10,5,10,5q�6p   $��50��6�     5R      -   5        $ BtnClose��5R   -   $" BtnClose_MouseLeftButtonDown��6�   $ خروج��6?   $ ../Icon/Exit.png��6R   $��	10,5,10,5q�6x   $��50��6�   6�   5W      �� 5X   
   -   5         ��Name$ BtnBack��5X      $��../Icon/Back.png��6!   $��961,13,13,0q�6;    J� Opacity$ 0Q�6P   $��14��6\   $	��Top=�6h   �� 5Y   
   -   5        $ BtnMenue��5Y      $��../Icon/MenuIcon.png��6"   $��
966,8,10,0q�6@   $��24��6T   $	��Top=�6`   5\      5]      