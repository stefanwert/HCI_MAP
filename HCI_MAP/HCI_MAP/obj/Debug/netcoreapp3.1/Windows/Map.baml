   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCI_MAP.WindowsHCI_MAP.Windows  5   	   !clr-namespace:HCI_MAPHCI_MAP  5   	       HCI_MAP.Windows.Map   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HCI_MAP.Windows     5   	   %cmdclr-namespace:HCI_MAP     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	      CustomWindowStyle#���   5   	    � 
ResizeMode$ NoResize=�5   	     Map � Title# �  5   	   $	��800��63   $
��1100��6@    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  cmd:MyCommands.ChangeTheme��5      6�     5   
   -   5        $ cmd:MyCommands.Lenguage��5      6{     5   
   -   5        $$ cmd:MyCommands.windowsCommand1��5      6~     5   
   -   5        $$ cmd:MyCommands.windowsCommand2��5      6�     5   
   -   5        $$ cmd:MyCommands.windowsCommand3��5      6�   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   o� $	��Top=�6   .@�5      m�  
 Themes#���  6   .@�5      m� -   5         	 Light#���  5        SingleDropDownMenuItem#���  6H   
 J� Uid$ 0��6�    m� Icon 5      �� 5      ���	#FF848484���	#FFE8E8E8$��2��6H    �� StrokeLineJoin$ Round=�6\   5      m� 5"      -   5          Dark#���  5"      #���  6G   $ 2��6�    5#      �� 5$      ���	#FF404040���	#FF1B1B1B$��2��6H   $ Round=�6\   5&      5,      m� 5-      -	   5        $��menuItemLanguages��5-        Lenguage#���  60   .@�5.      m� -
   5        
	 � Tag$	 en-US��5.        English#���  6'   6V   m� 5/      -   5        $		 SRB��5/        Serbian#���  6%   6T   50      m� 51      -   5        $��windowPicker��51       	 Windows#��� 	 6+   .@�52      m� -   5         
 
EventTable#��� 
 52      6N   m� 53      -   5          TypeOfEventTable#���  53      6T   m� 54      -   5        #���  54      6F   55      m� 56      -   5          Help#���  56   .   57      �� 58   
   $��10q�6   $ 
Horizontal=�6!   $��Right=�6;   .+�59      �� -   5        
 ��Name$
 searchTextBox��59   R   $��0 0 0 5q�6   
��� � �$��32(�6D   $��	20 0 20 0q�6i   $	��250��6|   6�   �� 5:      -   5        $��DemiBold"�5:       
 Search#���  6,   $
��Left=�6[   $��32(�6v   6�   �� 5;      -   5        $��DemiBold"�5;       	 Clear#���  6>   $��32(�6l   $��10 0 0 0q�6{   5<      �� 5=   
   -   5         ��Name$ MyCanvas��5=      $	��620��6#   $
��1000��60   5@      �� 5A   
   -   5        $��10q�5A      $��DemiBold"�6   $��Center=�63   $��32(�6P     DeleteEventFromMap#���  6^   6�   5B      5C      