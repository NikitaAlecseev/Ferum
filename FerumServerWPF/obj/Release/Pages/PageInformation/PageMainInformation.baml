   M S B A M L   `   `   `  ���� I  EFerumServerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FerumServerWPF.Pages.PageInformation$FerumServerWPF.Pages.PageInformation  R NLottieSharp, Version=2.3.0.0, Culture=neutral, PublicKeyToken=0b9dd77ba52f039aF2clr-namespace:LottieSharp.WPF;assembly=LottieSharpLottieSharp.WPF >    8FerumServerWPF.Pages.PageInformation.PageMainInformation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:FerumServerWPF.Pages.PageInformation     Elottie2clr-namespace:LottieSharp.WPF;assembly=LottieSharp     -     N� Title$  PageMainInformation��.���� ���#0D0E1A._��  � RowDefinitions �� $��60 ��� $��* �.+��� $+��%Основная информация�� �� TextAlignment$
 Left=�$��20 0 0 0q�$��Center=�
�������$��30(�$
��Bold"�)  #LottieSharp.WPF.LottieAnimationView  -     Name$ loaderAnimUI��$	��300��$	��300��$��Center=�$��Center=�   AutoPlay .    FileName$ Animations/load.json��   RepeatCount$ -1��$��1��y��� *VisibleLoadIdentificator+�� -    ��Name$ scrollViewerUI�����#0D0E1A$��1��$��20q�y��� *VisibleInformationPanel+.���� .+��  �� $��50 ��� $��50 �.+��� $��Хост��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� ���#030411 �� CornerRadius$ 10��$��1��._�� 	 � ColumnDefinitions	 �� $��40 ��� $��* �.+��� $��30��$-��'/Assets/Icons/Information/icon_host.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� *InfoEntity.HostName+
 �� UpdateSourceTrigger$
 PropertyChanged=��  �� $��50 ��� $��* �.+��� $��Пользователи��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� $��2��.+��� ���� *InfoEntity.Users+���� .R��� $��50�����#030411$ 10��$��0 0 0 5q�._�� 	 �� $��40 ��� $��* ��� $	��100 �.+��� $��30��$-��'/Assets/Icons/Information/icon_user.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q�����  �� Path$ Login��� $��Текущий�����#14FF00$��20(�$��2��$��Center=�$
��10 0q�y��� $ VisibleActiveUserText��  �� $��50 ��� $��50 �.+��� $'��!Материнская плата��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� ���#030411$ 10��$��1��._�� 	 �� $��40 ��� $��* �.+��� $��30��$4��./Assets/Icons/Information/icon_motherboard.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� *InfoEntity.ModelMotherboard+�  �� $��50 ��� $��50 �.+��� $��Процессор��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� ���#030411$ 10��$��1��._�� 	 �� $��40 ��� $��* �.+��� $��30��$2��,/Assets/Icons/Information/icon_processor.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� *InfoEntity.ModelProcessor+�  �� $��50 ��� $��* �.+��� $)��#Оперативная память��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� $��2��.+��� ���� *InfoEntity.RandomMemory+���� .R��� $��50�����#030411$ 10��$��0 0 0 5q�._�� 	 �� $��40 ��� $��* ��� $	��100 �.+��� $��30��$0��*/Assets/Icons/Information/icon_omemory.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� $ Model��� 
�������$��20(�$��2��$��Center=�$ Right=�$��0 0 10 0q����� $ MemoryGB��  �� $��50 ��� $��* �.+��� $��Видеокарта��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� $��2��.+��� ���� *InfoEntity.ModelsVideoCard+���� .R��� $��50�����#030411$ 10��$��0 0 0 5q�._�� 	 �� $��40 ��� $��* ��� $	��100 �.+��� $��30��$2��,/Assets/Icons/Information/icon_videocard.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� $ Model��  �� $��50 ��� $��* �.+��� $C��=Компьютер работает на протяжении��
�������$��25(�$
��Bold"�$��Bottom=�$
��0 10q��� $��2��.+��� $��50�����#030411$ 10��._�� 	 �� $��40 ��� $��* ��� $	��100 �.+��� $��30��$+��%/Assets/Icons/Information/icon_on.png���� 
�������$��20(�$��1��$��Center=�$
��10 0q����� *#!InfoEntity.GetLastRestartComputer+