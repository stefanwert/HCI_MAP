   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCI_MAP.WindowsHCI_MAP.Windows  5   	   #    HCI_MAP.Windows.AddStickyNote   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   )localclr-namespace:HCI_MAP.Windows  5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5
   	      CustomWindowStyle#���   5   	     AddStickyNote � Title# �  5   	   $	��450��5   	   $	��700��6   .��5      �� $��Center=�6   .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��Center=�6   
��� � �$��
20 20 0 0 q�6D   $��28(�6X   $��0��6f     Description2#���  6v   �� 5      -   5         ��Name$ Description��5   D   $��0 0 0 5q�6   
��� � �$��
0 20 50 0 q�6Z   $��28(�6n   $��1��6|   6�   5      � 5   
   $��10q�6    5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��Center=�6   
��� � �$��
20 20 0 0 q�6D   $��28(�6X   $��0��6f     Unique_mark#���  6v   �� 5      -   5        $ unique_mark��5   D   $��0 0 0 5q�6   
��� � �$��
0 20 50 0 q�6Z   $��28(�6n   $��1��6|   6�   5      � 5   
   $��10q�6    5       �� 5!      $��2* �6#   �� 5"      $��3* �6#   .+�5$      �� $��Center=�6   
��� � �$��
20 20 0 0 q�6D   $��28(�6X   $��0��6f    	 Color#���  6v   #  Xceed.Wpf.Toolkit.ColorPicker  5%      -   5        $��ClrPcker_Background��5%   �   $��	0 0 50 0 q�6   $��28(�63   $��1��6�   6�   5&      �� 5'   
   -   5        $��DemiBold"�5'        AddNote#���  6'   $��40(�6W   $��200 50 200 0q�6e   $��60��6{   6�   5(      5)      