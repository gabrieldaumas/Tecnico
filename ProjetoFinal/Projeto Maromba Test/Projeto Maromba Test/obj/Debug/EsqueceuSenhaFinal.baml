   M S B A M L   `   `   `  ����  Projeto Maromba Test-    'Projeto_Maromba_Test.EsqueceuSenhaFinal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window1��5   	   $	��492��6   $	��635��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � WindowStyle$
 None=�6m    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   CloseWindowCommand   Command# Z 5      6y     5   
   -   5           MinimizeWindowCommand# Z 5      6|   .��5	      � .+�5   
   �� .+�5      �� #��Z 6   $��Close��6L    �� Left$	 582��6\   
	 �� Top$	 5��6n   
�������$��43��6�   �� 5      #��Z 6   $��Minimize��6O   $	 518��6b   $	 5��6t   
�������$��58��6�   �� 5      $	��100��6   $	 272��6!   $	��100��63   $��Resource/maromba.png��6?   �� 5      $5��/Chegou na última etapa para modificar a senha!��6   $	 200��6M   $		 100��6_   $	��259��6p   �� 5      $B��<Basta você colocar a senha, confirmá-la e clique no botão��6   $	 166��6X   $		 150��6j   $	��315��6{   �� 5      $��Senha��6   $
��Left=�6$   $	��Top=�6?   $��93��6W   $	 166��6b   $		 217��6t   �� 5      $��Confirmar Senha��6   $
��Left=�6.   $	��Top=�6I   $	 166��6a   $		 317��6s   5      �� 5   
   -   5        $��Atualizar a senha��5      $
��Left=�6-   $��258,420,0,0q�6H   $	��Top=�6]   $	��125��6u   $��27��6�   G� 5   
   -   5        
 G�Name$
 ConfSenhaText��5      $
��Left=�6-   $	��Top=�6H   $��23��6`   $	��120��6l   $��289,318,0,0q�6x    G� 	MaxLength$ 20��6�   $��7��6�   6�   G� 5   
   -   5        $
 	SenhaText��5      $
��Left=�6)   $	��Top=�6D   $��23��6\   $	��120��6h   $��289,217,0,0q�6t   $ 20��6�   $��6��6�   6�   5      5      