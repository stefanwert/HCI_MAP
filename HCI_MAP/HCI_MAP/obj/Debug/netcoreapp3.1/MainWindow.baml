   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:HCI_MAPHCI_MAP  5   	   !clr-namespace:HCI_MAPHCI_MAP  5   	   +clr-namespace:HCI_MAP.helpHCI_MAP.help  5	   	       HCI_MAP.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:HCI_MAP     5   	   %cmdclr-namespace:HCI_MAP     5   	   (lclr-namespace:HCI_MAP.help     5	   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	      CustomWindowStyle#���   5   	     MainWindow_Title � Title# �  5   	   $	��750��5   	   $
��1100��6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:MyCommands.AddEvent��5      6{     5   
   -   5        $ cmd:MyCommands.EditEvent��5      6~     5   
   -   5        $  cmd:MyCommands.DeleteEvent��5      6�     5   
   -   5        $ cmd:MyCommands.GoToMap��5      6x     5   
   -   5        $$ cmd:MyCommands.ShowStickyNotes��5      6�     5   
   -   5        $  cmd:MyCommands.ChangeTheme��5      6�     5   
   -   5        $ cmd:MyCommands.Lenguage��5      6{     5   
   -   5        $$ cmd:MyCommands.windowsCommand1��5      6~     5   
   -	   5        $$ cmd:MyCommands.windowsCommand2��5      6�     5   
   -
   5        $$ cmd:MyCommands.windowsCommand3��5      6�   .��5      �� .+�5   
   o� $	��Top=�6   .@�5      m�  
 Themes#���  6   .@�5      m� -   5         	 Light#���  5        SingleDropDownMenuItem#���  6H   
 J� Uid$ 0��6�    m� Icon 5      �� 5       ���	#FF848484���	#FFE8E8E8$��2��6H    �� StrokeLineJoin$ Round=�6\   5"      m� 5(      -   5          Dark#���  5(      #���  6G   $ 2��6�    5)      �� 5*      ���	#FF404040���	#FF1B1B1B$��2��6H   $ Round=�6\   5,      52      m� 53      -   5        $��menuItemLanguages��53        Lenguage#���  60   .@�54      m� -   5        
 � Tag$ en-US��54        English#���  6'   6V   m� 55      -   5        $	 SRB��55        Serbian#���  6%   6T   56      m� 57      -   5        $��windowPicker��57       	 Windows#��� 	 6+   .@�58      m� -   5         
 
EventTable#��� 
 58      6N   m� 59      -   5          TypeOfEventTable#���  59      6T   m� 5:      -   5          Map#���  5:      6F   5;      m� 5<      -   5          Help#���  5<   .   5=      �� 5>   
   $��40(�6   $��Center=�6"   #���  6?   6w   �� 5?   
   $��200 10 10 10q�6   	 �� Orientation$	 
Horizontal=�6+   $��Right=�6D   .+�5@      �� -   5        
 ��Name$
 searchTextBox��5@   S   $��0 0 0 5q�6   
��� � �$��32(�6E   $��	20 0 20 0q�6j   $	��250��6}      HCI_MAP.help.HelpProvider   HelpKey$ Indeks��6�   6�   �� 5A      -   5        $��DemiBold"�5A       
 Search#���  6-   $
��Left=�6\   $��32(�6w   $	��150��6�   6�   �� 5B      -   5         	 Clear#���  5B      $��32(�6C   $��10 0 0 0q�6d   $��DemiBold"�6v   5C      �� 5D   
   $	 
Horizontal=�6   .+�5E      �� -   5        $��DemiBold"�5E      $��10q�6+     Add#���  67   $
��Left=�6c   $��32(�6~   $	��150��6�   $	 Ime��6�   �� 5F      -   5        $��DemiBold"�5F      $��10q�6+     Edit#���  67   $
��Left=�6d   $��32(�6   $	��150��6�   6�   �� 5G      -   5        $��DemiBold"�5G      $��10q�6+    
 Remove#���  67   $
��Left=�6f   $��32(�6�   $	��180��6�   6�   �� 5H      -   5        $��DemiBold"�5H      $��10q�6+     ShowStickyNotes#���  67   $
��Left=�6�   $��32(�6�   $	��270��6�   5J      &   System.Windows.Controls.DataGrid  5K   
   -   5          Name$ table��5K      
��� � �   
IsReadOnly$
 True��6V      SelectionMode$ Single=�5L         AutoGenerateColumns$ False��6*   $
��Left=�6F   $	��510��5M      $	��Top=�6!   $��28(�69   $��0q�6G   ��5K   7   �� *Events+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5P      $ * 6>    6%   �� *Name+ 5Q      �� 5R      #��� ��6$   5T        5U      $ * 6@    6&   �� *Price+ 5V      �� 5W       	 Price#���  6$   5Y        5Z      $ * 6A    6%   �� *	Country+ 5[      �� 5\        Country#���  6$   5^        5_      $ * 6>    6%   �� *City+ 5`      �� 5a        City#���  6$   5c        5d      $ * 6@    6&   �� *Place+ 5e      �� 5f       	 Place#���  6$   5h        5i      $ * 6E    6%   �� *Description+ 5j      �� 5k        Description#���  6$   5m      5o      5q      5r      