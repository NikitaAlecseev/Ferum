   M S B A M L   `   `   `  ����I  EFerumServerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FerumServerWPFFerumServerWPF  5   	       FerumServerWPF.WindowView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:FerumServerWPF     5   	   -   5          � Title$  Ferum��5   	   $	��720��6   $
��1080��6$    � WindowStartupLocation$ CenterScreen=�61    � WindowStyle$
 None=�6q    � AllowsTransparency . 
������ .��5
      �� -   5        ���#0D0E1A �� CornerRadius$ 15��5
   "   ._�5   
   �  � RowDefinitions 5      �� 5      $��60 �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��1��6&   $��Right=�66   $	��Top=�6R   $��	0,10,30,0q�6j   $��30��6}    �� Orientation$ 
Horizontal=�6�   $��RightToLeft=�6�   $��2��6�   .+�5      �� -   5         ��Name$ btnClose��5         IconButtonsStyle#��[  6+    	 close#���  6U   
	 � Tag$	 IsCloseButton��6�   �� 5      -   5        $ 
btnRestore��5      $	��5,0q�6-   ��5      �� 5      
 �� 
TargetType"
 ��6     �� BasedOn# [  6=   .�5      ��  �� Property � ��  maximize �� Value# �  68    �� Triggers 5      �� 5   "    �� Binding 6.   ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized6e   .a�5   &   ��  � ��  restore# �  6@   5   #   5!      5#      �� 5$      -   5        $ btnMinimize��5$      #���   6.     minimize#���  6Y   6~   5%      �� 5)      ���#030411$ 15 0 0 0��6*   ._�5*      �� $��0��6   $��Меню��6)   
�������$��25(�6H   $
��Bold"�6V    �� TextAlignment$ Center=�6h   $��Center=�6   5+      � 5,      $��1��6   .+�5-      �� ���#030411$��2��6.   $ 0 0 0 15��6?   ._�5.      �� -   5         ��Name$ listMenu��5.      
������ 
������ $��0 50 0 0q�6d   ��5/      �� 50      .R�51   "   � $��5 0 0 0q�6'    52   &   �� 53   *   $��50 �68    55   &   �� 56   *   $��50 �6;   �� 57   *   $��* �6;   .+�59   &   �� $��40��6,   ��67   �� *
PathIcon+�� 5:   &   $��20(�6F   
�������$��1��6g   $
 Left=�6w   $��10 0 0 0q�6�   $��Center=�6�   ��60   �� *Name+6�   5;   #   5<      5>      5?      5@       � 5D      -   5        $��
fContainer��5E      $��1��5D      $��1��6$     � NavigationUIVisibility$ Hidden=�5F      5G      5H      5I      5J      