   M S B A M L   `   `   `  ���� I  EFerumServerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FerumServerWPFFerumServerWPF      FerumServerWPF.WindowView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:FerumServerWPF     -     � Title$  Ferum��$	��720��$
��1080�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������ .���� -   ���#0D0E1A �� CornerRadius$ 15��._��  � RowDefinitions �� $��60 ��� $��* � � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0��$��1��$��Right=�$	��Top=�$��	0,10,30,0q�$��30�� �� Orientation$ 
Horizontal=�$��RightToLeft=�$��2��.+��� -    ��Name$ btnClose��   IconButtonsStyle#��[   	 close#���  
	 � Tag$	 IsCloseButton���� -   $ 
btnRestore��$	��5,0q����� 
 �� 
TargetType"
 �� �� BasedOn# [  .���  �� Property � ��  maximize �� Value# �   �� Triggers ��  �� Binding ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized.a���  � ��  restore# �  �� -   $ btnMinimize��#���     minimize#���  �� ���#030411$ 15 0 0 0��._��� $��0��$��Меню��
�������$��25(�$
��Bold"� �� TextAlignment$ Center=�$��Center=�� $��1��.+��� ���#030411$��2��$ 0 0 0 15��._��� -    ��Name$ listMenu��
������ 
������ $��0 50 0 0q����� .R�� $��5 0 0 0q� �� $��50 � �� $��50 ��� $��* �.+��� $��40������ *
PathIcon+�� $��20(�
�������$��1��$
 Left=�$��10 0 0 0q�$��Center=����� *Name+ � -   $��
fContainer��$��1��$��1��  � NavigationUIVisibility$ Hidden=�