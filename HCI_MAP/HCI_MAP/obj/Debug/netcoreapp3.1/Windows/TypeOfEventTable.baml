   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCI_MAP.WindowsHCI_MAP.Windows  5   	   !clr-namespace:HCI_MAPHCI_MAP  5   	   &     HCI_MAP.Windows.TypeOfEventTable   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HCI_MAP.Windows     5   	   %cmdclr-namespace:HCI_MAP     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5
   	      CustomWindowStyle#���   5   	     TypeOfEvent2 � Title# �  5   	   $	��750��5   	   $
��1100��6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  cmd:MyCommands.ChangeTheme��5      6�     5   
   -   5        $ cmd:MyCommands.Lenguage��5      6{     5   
   -   5        $$ cmd:MyCommands.windowsCommand1��5      6~     5   
   -   5        $$ cmd:MyCommands.windowsCommand2��5      6�     5   
   -   5        $$ cmd:MyCommands.windowsCommand3��5      6�     5   
   -   5        $# cmd:MyCommands.addTypeOfEvent��5      6w     5   
   -   5        $$ cmd:MyCommands.editTypeOfEvent��5      6z     5   
   -   5        $&  cmd:MyCommands.deleteTypeOfEvent��5      6�   .��5      �� .+�5   
   o� $	��Top=�6   .@�5      m�  
 Themes#���  6   .@�5      m� -	   5         	 Light#���  5        SingleDropDownMenuItem#���  6H   
 J� Uid$ 0��6�    m� Icon 5      �� 5      ���	#FF848484���	#FFE8E8E8$��2��6H    �� StrokeLineJoin$ Round=�6\   5       m� 5&      -
   5          Dark#���  5&      #���  6G   $ 2��6�    5'      �� 5(      ���	#FF404040���	#FF1B1B1B$��2��6H   $ Round=�6\   5*      50      m� 51      -   5        $��menuItemLanguages��51        Lenguage#���  60   .@�52      m� -   5        
 � Tag$ en-US��52        English#���  6'   6V   m� 53      -   5        $	 SRB��53        Serbian#���  6%   6T   54      m� 55      -   5        $��windowPicker��55       	 Windows#��� 	 6+   .@�56      m� -   5         
 
EventTable#��� 
 56      6N   m� 57      -   5          TypeOfEventTable#���  57      6T   m� 58      -   5          Map#���  58      6F   59      m� 5:      -   5          Help#���  5:   .   5;      �� 5<   
   $��40(�6   $��Center=�6"     MainWindow_Title#���  6?   6w   �� 5=   
   	 �� Orientation$	 
Horizontal=�6   .+�5>      �� -   5        $��DemiBold"�5>      $��10q�6+     Add#���  67   $
��Left=�6c   $��32(�6~   $	��150��6�   6�   �� 5?      -   5        $��DemiBold"�5?      $��10q�6+     Edit#���  67   $
��Left=�6d   $��32(�6   $	��150��6�   6�   �� 5@      -   5        $��DemiBold"�5@      $��10q�6+    
 Remove#���  67   $
��Left=�6f   $��32(�6�   $	��180��6�   6�   5B      &   System.Windows.Controls.DataGrid  5C   
   -   5        
  Name$
 table��5C      
��� � �   
IsReadOnly$
 True��6\      SelectionMode$ Single=�5D         AutoGenerateColumns$ False��6*   $
��Left=�6F   $	��510��5E      $	��Top=�6!   $��28(�69   $��0q�6G   ��5C   7   �� *TypeOfEvents+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+   Header 5H      �� 5I      $��ID��6$   5K        5L      $ * 6>    6%   �� *Name+ 5M      �� 5N      #��� ��6$   5P        5Q      $ * 6K    6%   �� *Human_description+ 5R      �� 5S        Unique_mark2#���  6$   5U        5V      $ * 6E    6%   �� *Description+ 5W      �� 5X        Description#���  6$   5Z      5\      5]      5^      