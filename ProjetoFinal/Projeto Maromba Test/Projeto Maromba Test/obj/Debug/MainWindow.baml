   M S B A M L   `   `   `  ����  Projeto Maromba Test%    Projeto_Maromba_Test.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Projeto Maromba Login��5   	   $��432.098��6'   $	��420��68    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ CanMinimize=�6i   .��5      � -   5        $��0,0,0,0q�5      $	��398��6   $	��Top=�6)   .+�5   
   �� $
��Left=�6   $	��100��6+   $	��Top=�68   $	��120��6P   $��
146,61,0,0q�6\   $��/Resource/maromba.png��6p    � BindingGroup 5      &   System.Windows.Data.BindingGroup  5         Name$ 
ImagemLogo��6   5
      �� 5   
   -   5         ��Name$ 	EmailText��5      $
��Left=�6%   $��23��6@   $	��Top=�6L   $	��206��6d   $��112,181,0,0q�6p    �� MaxLines$ 1��6�    �� 	MaxLength$ 42��6�   6�   �� 5   
   -   5         ��Name$ LoginButton��5      $��Entrar��6&   $
��Left=�67   $��173,289,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   $��Senha:��6   $
��Left=�6!   $	��Top=�6<   $��
25,231,0,0q�6T   $��23��6h   �� 5   
   $��Email:
��6   $
��Left=�6+   $	��Top=�6F   $��
25,179,0,0q�6^   $��64��6r   $��25��6}   �� 5   
   -   5        	 ��Name$	 
SenhaLabel��5      

 � Tag$
 Esqueceu a senha?��6$   $
��Left=�6<   $��155,331,0,0q�6W   $	��Top=�6l   $	��120��6�   .��5      �� -   5         ��Name$ 
SenhaBlock��5      $��	Underline{�6,   ��6H   ��  �� Path$	 Tag� �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" ��6�   5      �� 5   
   -   5        $	 CadastroLabel��5      $
 Não possui cadastro?��6'   $
��Left=�6B   $	��Top=�6]   $��146,362,0,0q�6u   $	��129��6�   $��Italic$�6�   .��5      �� -   5        $ CadastroBlock��5      $��	Underline{�6/   ��6K   �� $	 Tag� �� $ FindAncestor=�" ��6�   5      G� 5   
   -   5         G�Name$ 	SenhaText��5      $
��Left=�6)   $	��Top=�6D   $��23��6\   $	��206��6h   $��112,231,0,0q�6t    G� 	MaxLength$ 20��6�   $��6��6�   5      5      