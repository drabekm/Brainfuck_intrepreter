   M S B A M L   `   `   `  ����P  LBrainfuck_intrepreter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Brainfuck_intrepreterBrainfuck_intrepreter  5   	   &     Brainfuck_intrepreter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Brainfuck_intrepreter     5   	     � Title$#  Neurons brainfuck interpreter��5   	   $	��450��6/   $	��800��6<    � 
ResizeMode$ NoResize=�6H   .��5	      � .+�5
   
   �� $
��Left=�6   $	��421��6+   $	��Top=�68   $	��794��6P   $��bg.jpg��6\   $
��Fill=�6l    J� Opacity$	 0.3Q�6{   �� 5   
   -   5         ��Name$ 	textInput��5      $
��Left=�6%    �� AcceptsReturn . $	��399��6V   $��	10,10,0,0q�6c    �� TextWrapping$
 Wrap=�6w   $��Verdana)�6�   $��16(�6�   $��Place your code here��6�   $	��Top=�6�   $	��303��6�   $ 0.985Q�6�   ���	#7FFFFFFF6�   �� 5   
   -   5         ��Name$ buttonStart��5      $��Start��6&   $
��Left=�66   $��46��6Q   $��
641,18,0,0q�6]   $	��Top=�6q   $	��141��6�   $��Verdana)�6�   $��20(�6�   ���	#66DDDDDD6�   �� 5   
   -   5        $ buttonAbout��5      $��About��6&   $
��Left=�66   $��46��6Q   $��641,255,0,0q�6]   $	��Top=�6r   $	��141��6�   $��Verdana)�6�   $��20(�6�   ���	#66DDDDDD6�   �� 5   
   -   5        $ 
textOutput��5      $
��Left=�6&   $��54��6A   $��318,355,0,0q�6M   $
 Wrap=�6b   $��Verdana)�6v   $��16(�6�   $��OUTPUT:��6�   $	��Top=�6�   $	��464��6�   ���	#7FFFFFFF6�   �� 5   
   -   5        $ buttonDebug��5      $��Debug Start��6&   $
��Left=�6<   $��46��6W   $	��Top=�6c   $	��140��6{   $��Verdana)�6�   $��20(�6�   $��
642,74,0,0q�6�   ���	#66DDDDDD6�   �� 5   
   -   5        $ buttonContinue��5      $��Continue��6)   $
��Left=�6<   $��46��6W   $	��Top=�6c   $��Verdana)�6{   $��20(�6�   $	��141��6�   $��641,125,0,0q�6�   ���	#66DDDDDD6�   �� 5   
   -   5        $ 
buttonStep��5      $��	Next step��6%   $
��Left=�69   $��46��6T   $	��Top=�6`   $	��141��6x   $��Verdana)�6�   $��20(�6�   $��641,176,0,0q�6�   ���	#66DDDDDD6�   �� 5   
   -   5         ��Name$ labelIsDebug��5      $��Is in debug: false��6&   $
��Left=�6C   $��
318,18,0,0q�6^   $	��Top=�6r   $��Verdana)�6�   $��15(�6�   �� 5   
   -	   5        $ labelIsBreak��5      $��On breakpoint: false��6&   $
��Left=�6E   $��
318,44,0,0q�6`   $	��Top=�6t   $��Verdana)�6�   $��15(�6�   �� 5   
   -
   5        $ 	labelHelp��5      $��Help variable value: 0��6#   $
��Left=�6E   $��
318,70,0,0q�6`   $	��Top=�6t   $��Verdana)�6�   $��15(�6�   5      5      