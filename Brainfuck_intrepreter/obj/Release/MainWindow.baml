   M S B A M L   `   `   `  ���� P  LBrainfuck_intrepreter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Brainfuck_intrepreterBrainfuck_intrepreter  &     Brainfuck_intrepreter.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:Brainfuck_intrepreter       � Title$#  Neurons brainfuck interpreter��$	��450��$	��800�� � 
ResizeMode$ NoResize=�.��� .+��� $
��Left=�$	��421��$	��Top=�$	��794��$��bg.jpg��$
��Fill=� J� Opacity$	 0.3Q��� -    ��Name$ 	textInput��$
��Left=� �� AcceptsReturn . $	��399��$��	10,10,0,0q� �� TextWrapping$
 Wrap=�$��Verdana)�$��16(�$��Place your code here��$	��Top=�$	��303��$ 0.985Q����	#7FFFFFFF�� -    ��Name$ buttonStart��$��Start��$
��Left=�$��46��$��
641,18,0,0q�$	��Top=�$	��141��$��Verdana)�$��20(����	#66DDDDDD�� -   $ buttonAbout��$��About��$
��Left=�$��46��$��641,255,0,0q�$	��Top=�$	��141��$��Verdana)�$��20(����	#66DDDDDD�� -   $ 
textOutput��$
��Left=�$��54��$��318,355,0,0q�$
 Wrap=�$��Verdana)�$��16(�$��OUTPUT:��$	��Top=�$	��464�����	#7FFFFFFF�� -   $ buttonDebug��$��Debug Start��$
��Left=�$��46��$	��Top=�$	��140��$��Verdana)�$��20(�$��
642,74,0,0q����	#66DDDDDD�� -   $ buttonContinue��$��Continue��$
��Left=�$��46��$	��Top=�$��Verdana)�$��20(�$	��141��$��641,125,0,0q����	#66DDDDDD�� -   $ 
buttonStep��$��	Next step��$
��Left=�$��46��$	��Top=�$	��141��$��Verdana)�$��20(�$��641,176,0,0q����	#66DDDDDD�� -    ��Name$ labelIsDebug��$��Is in debug: false��$
��Left=�$��
318,18,0,0q�$	��Top=�$��Verdana)�$��15(��� -	   $ labelIsBreak��$��On breakpoint: false��$
��Left=�$��
318,44,0,0q�$	��Top=�$��Verdana)�$��15(��� -
   $ 	labelHelp��$��Help variable value: 0��$
��Left=�$��
318,70,0,0q�$	��Top=�$��Verdana)�$��15(�