   M S B A M L   `   `   `  ����B  >WPFView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFViewWPFView  5   	       WPFView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFView     5   	     � Title$  	Labirynth��5   	   $	��500��6   $	��500��6(   $	��500��64   $	��500��6D    J� InputBindings 5	      �� 5   
   
 �� Key$ W��6    �� CommandParameter$ W��6=    �� Command 6   �� *StepCommand+6=   �� 5   
   $ A��6   $ A��6=    6   �� *StepCommand+6=   �� 5   
   $ S��6   $ S��6=    6   �� *StepCommand+6=   �� 5   
   $ D��6   $ D��6=    6   �� *StepCommand+6=   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   o� $��0��6   .@�5      m� $
��Menu��6   .@�5      m� $��New Game��6    m� Command 6-   �� *NewGameCommand+�� 5      m� 5      $��Load level...��6    62   �� *LoadGameCommand+�� 5      m� 5      $
��Exit��6    6)   �� *ExitCommand+5      5      �� 5   
   $��1��6   ��6$   �� *Fields+��5!      �� 5"      .R�5$      A�  A� Rows 6"   �� *
GameSize+ A� Columns 6<   �� *
GameSize+��5%   "   �� *GameSize*50+��6@   �� *GameSize*50+5&      ��5(      �� 5)      .R�5*      �� $��50��6   $��50��6'   z�5,      �� 5-      	 �� ScaleX$	 1Q�6-   
 �� ScaleY$
 1Q�68   ��5/      �� 51       �� 
TargetType" ��6$   .�52      ��  �� Property � �� �� Value$ 0q�67    �� Triggers 53   "   �� 55   &    �� Binding 62   �� *Type+ �� Value Road6K   .a�56   *   ��  � ��$I CD:\baCKUP\SULI\labyrinth\Labyrinth\WPFView\Resources\roadsprite.png��6C   57   '   �� 58   &    62   �� *Type+ Wall6K   .a�59   *   ��  � ��$J DD:\baCKUP\SULI\labyrinth\Labyrinth\WPFView\Resources\greensprite.png��6C   5:   '   �� 5;   &    62   �� *Type+
 Player6K   .a�5<   *   ��  � ��$P JD:\baCKUP\SULI\labyrinth\Labyrinth\WPFView\Resources\250px-007Squirtle.png��6C   5=   '   �� 5>   &    62   �� *
Visibile+	 False6O   .a�5?   *   ��  � ��$J DD:\baCKUP\SULI\labyrinth\Labyrinth\WPFView\Resources\blacksprite.png��6C   5@   '   5B      5D      5E      ��5G      �� 5I      .�5J      ��  � �� 61   �� *X+�� 5K       � �� 64   �� *Y+5L      5N      �� 5P   
   $��2��6   .@�5Q      �� .��5R      �� $��Játékidő: ��6   5S      �� 5T      .��5U      �� ��6   �� *time+5V      �� 5W      �� 5X      5Y      5Z      5\      