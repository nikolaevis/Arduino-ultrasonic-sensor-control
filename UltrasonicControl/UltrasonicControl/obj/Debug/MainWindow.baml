   M S B A M L   `   `   `  ����M  ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M3clr-namespace:System.ComponentModel;assembly=SystemSystem.ComponentModel  5   	   L HUltrasonicControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UltrasonicControlUltrasonicControl 5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5   	   "   UltrasonicControl.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bcm3clr-namespace:System.ComponentModel;assembly=System     5   	   1localclr-namespace:UltrasonicControl     5   	   Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     5   	   -   5          � Title$  Ultrasonic Sensor monitor��5
   	   $	��350��6+   $	��525��68    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ SensorSwitch��5      $
��Left=�6'   $��46��6B   $��
10,241,0,0q�6N   $	��Top=�6b   $	��129��6z   .��5      ��  �� Orientation$ 
Horizontal=�6   $	��119��62    J� RenderTransformOrigin$ 
0.095,0.55&�6>   .+�5      �� $ 0.5,0.5&�5   E   $��24��6e   ��5      �� *
CurrentLed+ 
  RedLed �� TargetNullValue# [  1  +System.Diagnostics.PresentationTraceSources   
TraceLevel$
 High=�5   e   �� 5      $��20��6f   $��91��6r   $ 0.863,1.734&�6}   ��6   �� *	Content+  SensorSwitchOn# [ 6}   5      5      �� 5   
   -   5        $ BoardInitialize��5      $
��Left=�6*   $��46��6E   $��368,241,0,0q�6Q   $	��Top=�6f   $	��139��6~   .��5      �� $ 
Horizontal=�6   $	��120��62   $ 
0.095,0.55&�6>   .+�5      �� $ 0.5,0.5&�6`   $��24��6�   ��6   �� *
CurrentLed+# [  6�   �� 5      $��20��6i   $��98��6u   $ 0.863,1.734&�6�   ��6   �� *	Content+  BoardInitializeOn# [ 6�   5      5      �� 5   
   -   5        $ StartStopRead��5      $
��Left=�6(   $��46��6C   $��182,241,0,0q�6O   $	��Top=�6d   $	��155��6|   .��5       �� $ 
Horizontal=�6   $	��152��62   $ 
0.095,0.55&�6>   .+�5!      �� $ 0.5,0.5&�6`   $��24��6�   ��6   �� *
CurrentLed+# [  6�   �� 5"      $��20��6g   $	��111��6s   $ 0.863,1.734&�6   ��6   �� *	Content+  StartStopReadOn# [ 6   5#      5$      �� 5%   
   -   5         ��Name$	 Far��5%      $
��Left=�5&      $	��Top=�6/   $��24��6G   $��	19,24,0,0q�6S   $	��111��6f   ��5%   !   �� *	Content+ J� Effect 5'      -  'System.Windows.Media.Effects.BlurEffect  5(      	   Radius$	 5Q�6   5*      �� 5+   
   -   5        $ Middle��5+      $
��Left=�5,      $	��Top=�6/   $��24��6G   $��	19,53,0,0q�6S   $	��111��6f   ��5+   %   �� *	Content+ 5-        5.      $	 5Q�6   50      �� 51   
   -   5        $ Close��51      $
��Left=�52      $	��Top=�6/   $��24��6G   $��	19,82,0,0q�6S   $	��111��6f   ��51   #   �� *	Content+ 53        54      $	 5Q�6   56      �� 57   
   -   5        
 ��Name$
 Distance��57      $
��Left=�58      $��32��6/   $��261,0,0,257q�6;   $
��Wrap=�6P   $��Bottom=�6d   $	��127��6   $��20(�59   a   $
��Bold"�6o   ��6   �� *	Content+ �� FallbackValue$ Distance��$ Distance��5:      5;       � 	Resources 5<      ,   &System.ComponentModel.BackgroundWorker  backgroundWorker!   WorkerSupportsCancellation   WorkerReportsProgress��%=   &	         5=   
   -	   5         .  . 5A      5B      5C      