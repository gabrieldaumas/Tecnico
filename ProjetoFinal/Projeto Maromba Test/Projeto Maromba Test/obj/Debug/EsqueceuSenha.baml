   M S B A M L   `   `   `  ����  Projeto Maromba Test(    "Projeto_Maromba_Test.EsqueceuSenha   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window1��5   	   $	��492��6   $	��635��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � WindowStyle$
 None=�6m    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   CloseWindowCommand   Command# Z 5      6y     5   
   -   5           MinimizeWindowCommand# Z 5      6|   .��5	      � .+�5   
   �� .+�5      �� #��Z 6   $��Close��6L    �� Left$	 582��6\   
	 �� Top$	 5��6n   
�������$��43��6�   �� 5      #��Z 6   $��Minimize��6O   $	 518��6b   $	 5��6t   
�������$��58��6�   �� 5      $	��100��6   $	 272��6!   $	��100��63   $��Resource/maromba.png��6?   �� 5      $@��:Esqueceu a sua senha? Desespere-se não! É muito simples!��6   $	 166��6W   $		 100��6i   $	��324��6z   �� 5      $N��HDigite seu sobrenome, email e data de nascimento abaixo para comecarmos.��6   $	 121��6g   $		 153��6y   $	��424��6�   �� 5      -   5        
 ��Name$
 NomeText��5      $
��Left=�6(   $��23��6C   $	��Top=�6O   $	��120��6g    �� 	MaxLength$ 42��6�    �� MaxLines$ 1��6�   $��1��6�   $	 305��6�   $		 220��6�   �� 5      -   5        $
 	EmailText��5      $
��Left=�6)   $��23��6D   $	��Top=�6P   $	��120��6h   $ 42��6�   $ 1��6�   $��4��6�   $	 305��6�   $		 350��6�   �� 5      $��	SobreNome��6   $
��Left=�6(   $	��Top=�6C   $��93��6[   $	 166��6f   $		 217��6x   �� 5      $��Data de Nascimento��6   $
��Left=�61   $	��Top=�6L   $	��118��6d   $	 166��6p   $		 285��6�   �� 5      $��Email��6   $
��Left=�6$   $	��Top=�6?   $	 166��6W   $		 346��6i   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DataNascText��5      $
��Left=�6/   $	��Top=�6J   $	��120��6b   $��26��6n      IsTodayHighlighted .     DisplayDateEnd$ 
2006-12-31X�6�      DisplayDateStart$ 
1900-01-01X�6�   $��3��6�   $	 305��6�   $		 285��6�   5      �� 5   
   -   5        $��	Continuar��5      $
��Left=�6%   $��282,462,0,0q�6@   $	��Top=�6U   $��75��6m   6x   5      5      