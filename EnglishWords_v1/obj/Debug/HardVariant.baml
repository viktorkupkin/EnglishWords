   M S B A M L   `   `   `  ����J  FEnglishWords_v1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EnglishWords_v1EnglishWords_v1  5   	   !    EnglishWords_v1.HardVariant   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:EnglishWords_v1     5   	     � Title$  Сложная игра��5   	   $	��450��6   $	��600��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ imageBox��5      $��0��6"   $	��300��63   $��
/apple.jpg��6?   �� 5   
   -   5         ��Name$ 	GamerName��5      $��1��6#   $��Имя игрока��63   $��Center=�6H   �� 5   
   $��1��6   $��Center=�6%   $��Center=�6B   .+�5      �� $#��Что на картинке?��6   $��Center=�6/   �� 5      $7��1Напиши правильный вариант.��6   $
��Auto��69   $��Center=�6G   �� 5      -   5         ��Name$ textBox_Answer��5      $	��150��6.   $��
10,20,10,5q�6:   �� 5      -   5         ��Name$ button_ChekVariant��5      $��Проверить��61   $	��150��6E   6Q   �� 5      -   5        $ button_ShowAnswer��5      $��
Ответ��60   $	��150��6@   $��0,50,0,0q�6L   6^   � 5      $��0,50,0,0q�6   .+�5      �� $)��#Правильные ответы: ��6   
��� � �66   �� 5      -   5        $ lable_RightAnswer��5      $��0��63   
��� � �$
��Bold"�6R   $��13,0,0,0q�6d   �� 5      $-��'Неправильные ответы: ��6   
���  ��68   �� 5      -   5        $ lable_NotRightAnswer��5      $��0��66   
���  ��$
��Bold"�6S   5      � 5       � Orientation$ Vertical=�6   $��Center=�6/   $��0,30,0,0q�6L   .+�5      �� $��Таймер��6   �� 5      -   5        $ 
timerLable��5      $��00:00:00��6,   $
��Bold"�6?   $��Center=�6Q   $
��Auto��6n   5      5       5!      5"      