   M S B A M L   `   `   `  ����  Projeto Maromba Test1    +Projeto_Maromba_Test.EsqueceuSenhaPerguntas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window1��5   	   $	��492��6   $	��635��6&    � WindowStartupLocation$ CenterScreen=�62    � 
ResizeMode$ NoResize=�6W    � WindowStyle$
 None=�6m    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   CloseWindowCommand   Command# Z 5      6y     5   
   -   5           MinimizeWindowCommand# Z 5      6|   .��5	      � .+�5   
   �� .+�5      �� #��Z 6   $��Close��6L    �� Left$	 582��6\   
	 �� Top$	 5��6n   
�������$��43��6�   �� 5      #��Z 6   $��Minimize��6O   $	 518��6b   $	 5��6t   
�������$��58��6�   �� 5      $	��100��6   $	 272��6!   $	��100��63   $��Resource/maromba.png��6?   �� 5      $4��.Falta só mais um passo para a troca da senha!��6   $	 187��6L   $		 100��6^   $	��259��6o   �� 5      $V��PResponda as perguntas cadastradas e suas respectivas respostas para continuarmos��6   $	 103��6o   $		 151��6�   $	��457��6�   �� 5      -   5        
 ��Name$
 Pergunta3Text��5      $
��Left=�6-   $��23��6H   $	��Top=�6T   $	��203��6l    �� 	MaxLength$	 100��6x   $��23��6�   $ 88��6�   $		 378��6�    �� 
IsReadOnly . 6�   �� 5      -   5        $
 Pergunta2Text��5      $
��Left=�6-   $��23��6H   $	��Top=�6T   $	��203��6l   $ 20��6x   $��22��6�   $ 88��6�   $		 301��6�    . 6�   �� 5      -   5        $
 Pergunta1Text��5      $
��Left=�6-   $��23��6H   $	��Top=�6T   $	��203��6l   $	 100��6x   $��21��6�   $ 88��6�   $		 222��6�    . 6�   5      �� 5   
   -   5         ��Name$ ContinuaButton��5      $��	Continuar��6)   $
��Left=�6=   $��282,462,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5   
   -   5        $
 	Resp3Text��5      $
��Left=�6%   $��23��6@   $	��Top=�6L   $	��217��6d   $��408,380,0,0q�6p    J� RenderTransformOrigin$ 1.067,0.304&�6�   $ 20��6�   $��26��6�   �� 5   
   -   5        $
 	Resp2Text��5      $
��Left=�6%   $��23��6@   $��408,300,0,0q�6L   $	��Top=�6a   $	��217��6y   $ 20��6�   $��24��6�   �� 5   
   -	   5        $
 	Resp1Text��5      $
��Left=�6%   $��23��6@   $��408,220,0,0q�6L   $	��Top=�6a   $	��217��6y   $ 20��6�   $��22��6�   �� 5   
   $��
Pergunta I��6   $
��Left=�6%   $	��Top=�6@   $��
10,217,0,0q�6X   �� 5   
   $��
Resposta I��6   $
��Left=�6%   $	��Top=�6@   $��305,220,0,0q�6X   $��75��6m   �� 5   
   $��Pergunta II��6   $
��Left=�6&   $	��Top=�6A   $��
10,297,0,0q�6Y   �� 5   
   $��Resposta II��6   $
��Left=�6&   $	��Top=�6A   $��305,300,0,0q�6Y   �� 5   
   $��Pergunta III��6   $
��Left=�6'   $	��Top=�6B   $��
10,380,0,0q�6Z   �� 5   
   $��Resposta III��6   $
��Left=�6'   $	��Top=�6B   $��305,380,0,0q�6Z   $��75��6o   5       5!      