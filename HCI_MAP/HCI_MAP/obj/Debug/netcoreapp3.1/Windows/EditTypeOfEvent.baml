   M S B A M L   `   `   `  ����B  >HCI_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HCI_MAP.WindowsHCI_MAP.Windows  5   	   %    HCI_MAP.Windows.EditTypeOfEvent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HCI_MAP.Windows     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	      CustomWindowStyle#���   5	   	     AddTypeOfEvent � Title# �  5   	   $	��480��6>   $	��600��6K   .��5      ��  � DataContext 6   �� *TypeOfEvent+.+�5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��Center=�6   
��� � �$��
40 20 0 0 q�6D   $��28(�6X   $��0��6f    	 Name2#���  6v   �� 5      -   5         ��Name$
 Name��5   E   $��0 0 0 5q�6   
��� � �$��0 20 100 0 q�6T   $��28(�6i   $��1��6w   ��6�   ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   5      � 5   
    5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��Center=�6   
��� � �$��
40 20 0 0 q�6D   $��28(�6X   $��0��6f     Unique_mark#���  6v   �� 5      -   5        $ 
UniqueMark��5   E   $��0 0 0 5q�6   
��� � �$��0 20 100 0 q�6Z   $��28(�6o   $��1��6}   ��6�   �� $ Human_description�$ PropertyChanged=�$ TwoWay=�6�   5      � 5   
    5      �� 5      $��2* �6#   �� 5       $��3* �6#   .+�5"      �� $��Center=�6   
��� � �$��
40 20 0 0 q�6D   $��28(�6X   $��0��6f     Description2#���  6v   �� 5#      -   5        $ Description��5#   E   $��0 0 0 5q�6   
��� � �$��0 20 100 0 q�6[   $��28(�6p   $��1��6~   ��6�   �� $ Description�$ PropertyChanged=�$ TwoWay=�6�   5$      �� 5%   
   -   5        $��btnLoadFromFile��5%      $	��200��6(   $��28(�64   $��30q�6B     LoadFromFile#���  6l   �� 5&   
   $��80��6   $
��Auto=�6#   $
��Auto=�6F   .��5'      �� -   5        $��
imgDynamic��5'      $��10q�6&   5(      �� 5)   
   -   5        $��28(�5)      $	��250��6   $��20q�6+     Edit#���  6I   5*      5+      