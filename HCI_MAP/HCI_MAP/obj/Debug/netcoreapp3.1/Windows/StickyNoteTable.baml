   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCI_MAP.WindowsHCI_MAP.Windows  5   	   %    HCI_MAP.Windows.StickyNoteTable   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HCI_MAP.Windows     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	      CustomWindowStyle#���   5
   	     StickyNoteTable � Title# �  5   	   $	��750��5   	   $	��900��6   .��5      ��  � DataContext 6   �� *Event+.+�5   
   �� $��40(�6   
��� � �$��Center=�65     StickyNotes#���  6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ table��5   &   
��� � �   
IsReadOnly$
 True��6f      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6*   $
��Left=�6F   $	��577��5      $��0,0,-0.4,15q�6    $	��Top=�65   $	��900��6M   $��32(�6Y   ��5   5   �� *StickyNotes+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6&   �� *Description+   Header 5      �� 5        Description#���  6$   5        5      $
 * 6K    6%   �� *Human_description+ 5      �� 5        Unique_mark2#���  6$   5      5      �� 5    
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5!      �� -   5        $��DemiBold"�5!      $��10q�6+     Add#���  67   $
��Left=�6c   $��32(�6~   $	��150��6�   6�   �� 5"      -   5        $��DemiBold"�5"      $��10q�6+     Edit#���  67   $
��Left=�6d   $��32(�6   $	��150��6�   6�   �� 5#      -   5        $��DemiBold"�5#      $��10q�6+    
 Remove#���  67   $
��Left=�6f   $��32(�6�   $	��150��6�   6�   5%      5'      5(      