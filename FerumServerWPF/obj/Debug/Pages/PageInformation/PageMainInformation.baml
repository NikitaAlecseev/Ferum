   M S B A M L   `   `   `  ����I  EFerumServerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FerumServerWPF.Pages.PageInformation$FerumServerWPF.Pages.PageInformation  5      R NLottieSharp, Version=2.3.0.0, Culture=neutral, PublicKeyToken=0b9dd77ba52f039aF2clr-namespace:LottieSharp.WPF;assembly=LottieSharpLottieSharp.WPF 5      >    8FerumServerWPF.Pages.PageInformation.PageMainInformation   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:FerumServerWPF.Pages.PageInformation     5      Elottie2clr-namespace:LottieSharp.WPF;assembly=LottieSharp     5      -   5          N� Title$  PageMainInformation��5
      .��5      �� ���#0D0E1A._�5   
   �  � RowDefinitions 5      �� 5      $��60 �6    �� 5      $��* �6    .+�5      �� $+��%Основная информация��6    �� TextAlignment$
 Left=�63   $��20 0 0 0q�6H   $��Center=�6Z   
�������$��30(�6�   $
��Bold"�6�   )  #LottieSharp.WPF.LottieAnimationView  5      -   5          Name$ loaderAnimUI��5   )   $	��300��6?   $	��300��6K   $��Center=�6X   $��Center=�6u      AutoPlay .    FileName$ Animations/load.json��6�      RepeatCount$ -1��6�   $��1��6�   y�6�   �� *VisibleLoadIdentificator+�� 5      -   5         ��Name$ scrollViewerUI��5      ���#0D0E1A$��1��6H   $��20q�6�   y�6U   �� *VisibleInformationPanel+.��5      �� .+�5      �  5      �� 5      $��50 �6,   �� 5      $��50 �6,   .+�5       �� $��Хост��6$   
�������$��25(�6C   $
��Bold"�6Q   $��Bottom=�6c   $
��0 10q�6~   �� 5!      ���#030411 �� CornerRadius$ 10��66   $��1��6H   ._�5"      � 	 � ColumnDefinitions	 5#   "   �� 5$   &   $��40 �67   �� 5%   &   $��* �67   .+�5'   "   �� $��30��6(   $-��'/Assets/Icons/Information/icon_host.png��63   �� 5(   "   
�������$��20(�6�   $��1��6�   $��Center=�6�   $
��10 0q�6�   ��6,   �� *InfoEntity.HostName+
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5)      5*      5+      � 5.       5/      �� 50      $��50 �6,   �� 51      $��* �6,   .+�53      �� $��Пользователи��6$   
�������$��25(�6K   $
��Bold"�6Y   $��Bottom=�6k   $
��0 10q�6�   �� 55      $��2��6%   .+�56      �� ��6+   �� *InfoEntity.Users+��57   "   �� 58   &   .R�59   *   �� $��50��61   ���#030411$ 10��6R   $��0 0 0 5q�6d   ._�5:   .   � 	 5;   2   �� 5<   6   $��40 �6G   �� 5=   6   $��* �6G   �� 5>   6   $	��100 �6G   .+�5@   2   �� $��30��68   $-��'/Assets/Icons/Information/icon_user.png��6C   �� 5A   2   
�������$��20(�6k   $��1��6y   $��Center=�6�   $
��10 0q�6�   ��6<   ��  �� Path$ Login�6�   �� 5B   2   $��Текущий��6<   ���#14FF00$��20(�6`   $��2��6n   $��Center=�6~   $
��10 0q�6�   y�6�   �� $ VisibleActiveUserText�5C   /   5D   +   5E   '   5G      5H      5J      � 5M       5N      �� 5O      $��50 �6,   �� 5P      $��50 �6,   .+�5R      �� $'��!Материнская плата��6$   
�������$��25(�6P   $
��Bold"�6^   $��Bottom=�6p   $
��0 10q�6�   �� 5S      ���#030411$ 10��66   $��1��6H   ._�5T      � 	 5U   "   �� 5V   &   $��40 �67   �� 5W   &   $��* �67   .+�5Y   "   �� $��30��6(   $4��./Assets/Icons/Information/icon_motherboard.png��63   �� 5Z   "   
�������$��20(�6l   $��1��6z   $��Center=�6�   $
��10 0q�6�   ��6,   �� *InfoEntity.ModelMotherboard+6�   5[      5\      5]      � 5`       5a      �� 5b      $��50 �6,   �� 5c      $��50 �6,   .+�5e      �� $��Процессор��6$   
�������$��25(�6H   $
��Bold"�6V   $��Bottom=�6h   $
��0 10q�6�   �� 5f      ���#030411$ 10��66   $��1��6H   ._�5g      � 	 5h   "   �� 5i   &   $��40 �67   �� 5j   &   $��* �67   .+�5l   "   �� $��30��6(   $2��,/Assets/Icons/Information/icon_processor.png��63   �� 5m   "   
�������$��20(�6j   $��1��6x   $��Center=�6�   $
��10 0q�6�   ��6,   �� *InfoEntity.ModelProcessor+6�   5n      5o      5p      � 5s       5t      �� 5u      $��50 �6,   �� 5v      $��* �6,   .+�5x      �� $)��#Оперативная память��6$   
�������$��25(�6Q   $
��Bold"�6_   $��Bottom=�6q   $
��0 10q�6�   �� 5y      $��2��6%   .+�5z      �� ��6+   �� *InfoEntity.RandomMemory+��5{   "   �� 5|   &   .R�5}   *   �� $��50��61   ���#030411$ 10��6R   $��0 0 0 5q�6d   ._�5~   .   � 	 5   2   �� 5�   6   $��40 �6G   �� 5�   6   $��* �6G   �� 5�   6   $	��100 �6G   .+�5�   2   �� $��30��68   $0��*/Assets/Icons/Information/icon_omemory.png��6C   �� 5�   2   
�������$��20(�6k   $��1��6y   $��Center=�6�   $
��10 0q�6�   ��6<   �� $ Model�6�   �� 5�   2   
�������$��20(�6n   $��2��6|   $��Center=�6�   $ Right=�6�   $��0 0 10 0q�6�   ��6<   �� $ MemoryGB�6�   5�   /   5�   +   5�   '   5�      5�      5�      � 5�       5�      �� 5�      $��50 �6,   �� 5�      $��* �6,   .+�5�      �� $��Видеокарта��6$   
�������$��25(�6I   $
��Bold"�6W   $��Bottom=�6i   $
��0 10q�6�   �� 5�      $��2��6%   .+�5�      �� ��6+   �� *InfoEntity.ModelsVideoCard+��5�   "   �� 5�   &   .R�5�   *   �� $��50��61   ���#030411$ 10��6R   $��0 0 0 5q�6d   ._�5�   .   � 	 5�   2   �� 5�   6   $��40 �6G   �� 5�   6   $��* �6G   �� 5�   6   $	��100 �6G   .+�5�   2   �� $��30��68   $2��,/Assets/Icons/Information/icon_videocard.png��6C   �� 5�   2   
�������$��20(�6k   $��1��6y   $��Center=�6�   $
��10 0q�6�   ��6<   �� $ Model�6�   5�   /   5�   +   5�   '   5�      5�      5�      � 5�       5�      �� 5�      $��50 �6,   �� 5�      $��* �6,   .+�5�      �� $C��=Компьютер работает на протяжении��6$   
�������$��25(�6_   $
��Bold"�6m   $��Bottom=�6   $
��0 10q�6�   �� 5�      $��2��6%   .+�5�      �� $��50��6%   ���#030411$ 10��6F   ._�5�   "   � 	 5�   &   �� 5�   *   $��40 �6;   �� 5�   *   $��* �6;   �� 5�   *   $	��100 �6;   .+�5�   &   �� $��30��6,   $+��%/Assets/Icons/Information/icon_on.png��67   �� 5�   &   
�������$��20(�6v   $��1��6�   $��Center=�6�   $
��10 0q�6�   ��60   �� *#!InfoEntity.GetLastRestartComputer+6�   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      