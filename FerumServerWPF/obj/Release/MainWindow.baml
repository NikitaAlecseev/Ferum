   M S B A M L   `   `   `  ���� I  EFerumServerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FerumServerWPFFerumServerWPF      FerumServerWPF.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     >Icon-http://metro.mahapps.com/winfx/xaml/iconpacks     .localclr-namespace:FerumServerWPF     -     � Title$  Ferum��$	��720��$
��1080�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������ .���� -    ��Name$ 
MainBorder�����#0D0E1A �� CornerRadius$ 15��._��  � RowDefinitions �� $��60 ��� $��60 ��� $��* ��� $��60 �.+��� $��Ferum��$��Workes Regular)�
�������$��40(�$
��Bold"� �� TextAlignment$
 Left=�$��	20 20 0 0q�� $��1�� � ColumnDefinitions �� �� $��8* ��� $��9* �.+��� $#��Список клиентов��
�������$��25(�$
��Bold"�$
 Left=�$��30 0 0 0q�$��Bottom=�$��2���� ���#9C9C9C$��20(�$��Normal"�$ Right=�$��0 0 30 0q�$��2��$��Bottom=����� *CountClients+	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��0��$��1��$��Right=�$	��Top=�$��	0,10,30,0q�$��30��
 �� Orientation$
 
Horizontal=�$��RightToLeft=�$��2��.+��� -    ��Name$ btnClose��   IconButtonsStyle#��[   	 close#���  
 � Tag$ IsCloseButton���� -   $ 
btnRestore��$	��5,0q�����  �� 
TargetType" �� �� BasedOn# [  .���  �� Property � ��  maximize �� Value# �   �� Triggers ��  �� Binding ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized.a���  � ��  restore# �  �� -   $ btnMinimize��#���     minimize#���  �� -    ��Name$ listClients�����#0D0E1A  listViewCustom#��[ 
������ $��2��$��30q�$��Stretch=�$��Disabled=����� *ClientEntity+$	 PropertyChanged=����� .R��� $��50��$ 10�����#030411$��0 0 0 10q�._��  �� $��50 ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��10��$��10��$��4��$ 50��$��Right=�$��0 0 10 0q����� $ ColorIndicator�$	 PropertyChanged=��� $��0��$��35��$��35��$��10 0 0 0q�$%��/Assets/Icons/Icon_Computer.png��$��1���� $��3��$
 
Horizontal=�$��Right=�$��Center=�.+��� $��30��$��30��$��3��$��20 0 0 0q�$��/Assets/Icons/ic_game.png��y��� $ GameModeVisibleUI�$	 PropertyChanged=��� $��30��$��30��$��3��$��20 0 0 0q�$"��/Assets/Icons/ic_warning.png��$y�	Collapsed=��� $��1��$��Center=�
�������$��2��$
 Left=�$��10 0 0 0q�$��18(����� $ HostName��� $��5��$��Center=����#393A47$��18(�$��3��$ Center=�$��	 10 0 0 0q����� $ VersionAgent� � ContextMenu �� .@�m� -   $��Открыть��$��18(�m� -   $0��*Удаленный рабочий стол��$��18(�m� -	   $4��.Получить текущий процесс��$��18(�m� $:��4Изменения в характеристиках��$��18(�{�.  m� -
   $��Отключить��$��18(��� m� -   $��Выключить��$��18(�m� -   $ ��Перезагрузить��$��18(�m� -   $ ��Заблокировать��$��18(��� $
��v1.5�����#9C9C9C$��3��$��20(�$��Normal"�$ Center=�$��0 0 0 10q�$��3��$��Bottom=��� -   $ btnDeveloper��  ButtonDeveloper#��[ 
������ $��3��$
��Left=�$��10 0 0 0q�
������ .���� $��@PineDeveloper�����#9C9C9C$��20(�$��Normal"�$
 Left=�$��3��$��Bottom=�