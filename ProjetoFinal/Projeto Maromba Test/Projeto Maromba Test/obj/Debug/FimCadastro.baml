   M S B A M L   `   `   `  ����  Projeto Maromba Test&     Projeto_Maromba_Test.FimCadastro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4h dXceed.Wpf.AvalonDock.Themes.Metro, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[ WXceed.Wpf.AvalonDock, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4=xcad,http://schemas.xceed.com/wpf/xaml/avalondock     5   	     � Title$  Window1��5   	   $	��492��6   $	��635��6&    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W   .��5      � .+�5   
   � $��10,-19,-10,0q�6   .+�5      �� $��Label��6   $
��Left=�6$   $��3��6?   $��342,154,0,0q�6J   $	��Top=�6_   $��5��6w   �� 5	      -   5         ��Name$ 	IMCLabel1��5	      $�� ��6'   $
��Left=�62   $��
284,70,0,0q�6M   $	��Top=�6a   $	��241��6y   �� 5
      -   5        $ 	RCQLabel1��5
      $�� ��6'   $
��Left=�62   $��284,170,0,0q�6M   $	��Top=�6b   $	��241��6z   �� 5      -   5        $ 	TMBLabel1��5      $�� ��6'   $
��Left=�62   $��284,270,0,0q�6M   $	��Top=�6b   $	��241��6z   �� 5      -   5        $ 
MetaLabel1��5      $�� ��6(   $
��Left=�63   $��284,400,0,0q�6N   $	��Top=�6c   $	��241��6{   �� 5      -   5        $ PesoAtualLabel1��5      $�� ��6-   $
��Left=�68   $	��Top=�6S   $��284,320,0,0q�6k   $	��208��6�   �� 5      -   5        $ PesoIdealLabel2��5      $��Label��6-   $
��Left=�6=   $	��Top=�6X   $��284,350,0,0q�6p   $	��241��6�   ���	#FF5D5D5D6�   �� 5      $��Label��6   $
��Left=�6$   $��3��6?   $��330,151,0,0q�6J   $	��Top=�6_   $��5��6w   �� 5      $%��Índice de Massa Corporal (IMC)��6   $
��Left=�6=   $��	18,67,0,0q�6X   $	��Top=�6k   $	��175��6�   �� 5      $%��Relação Cintura-Quadril (RCQ)��6   $
��Left=�6<   $��
18,167,0,0q�6W   $	��Top=�6k   $	��175��6�   �� 5      $��Taxa de Metabolismo Basal��6   $
��Left=�68   $��
18,267,0,0q�6S   $	��Top=�6g   $	��175��6   �� 5      $��Meta de Peso em 1 mês��6   $
��Left=�64   $��
18,397,0,0q�6O   $	��Top=�6c   �� 5      -   5        $ IMCLabel��5      $�� ��6&   $
��Left=�61   $��
272,67,0,0q�6L   $	��Top=�6`   $	��241��6x   �� 5      -   5        $ RCQLabel��5      $�� ��6&   $
��Left=�61   $��272,167,0,0q�6L   $	��Top=�6a   $	��241��6y   �� 5      -	   5        $ TMBLabel��5      $�� ��6&   $
��Left=�61   $��272,267,0,0q�6L   $	��Top=�6a   $	��241��6y   �� 5      -
   5        $ 	IMCLabel3��5      $��Tabela do IMC��6'   $
��Left=�6?   $��
18,117,0,0q�6Z   $	��Top=�6n   $��88��6�   ���	#FF5D5D5D6�   �� 5      -   5        $ 	MetaLabel��5      $�� ��6'   $
��Left=�62   $��272,399,0,0q�6M   $	��Top=�6b   $	��241��6z   �� 5      $��*estimativa��6   $
��Left=�6*   $��
18,428,0,0q�6E   $	��Top=�6Y   ���	#FF5D5D5D6q   �� 5      -   5        $ 	IMCLabel2��5      $�� ��6'   $
��Left=�62   $��384,117,0,0q�6M   $	��Top=�6b   $	��157��6z   �� 5      -   5        $ 	RCQLabel2��5      $�� ��6'   $
��Left=�62   $��384,217,0,0q�6M   $	��Top=�6b   $��96��6z    J� RenderTransformOrigin$ -0.368,0.583&�6�   �� 5      $��Classificação:��6   $
��Left=�6-   $��272,117,0,0q�6H   $	��Top=�6]   $��82��6u   $ 0.851,0.665&�6�   �� 5      $��Classificação:��6   $
��Left=�6-   $��272,217,0,0q�6H   $	��Top=�6]   $��82��6u   $ 0.851,0.665&�6�   �� 5      -   5        $ 	TabelaRCQ��5      $��Tabela do RCQ��6'   $
��Left=�6?   $��
18,217,0,0q�6Z   $	��Top=�6n   $��88��6�   ���	#FF5D5D5D6�   �� 5      $��
Peso Atual��6   $
��Left=�6)   $	��Top=�6D   $��
18,317,0,0q�6\   $��88��6p   �� 5       -   5        $ PesoAtualLabel��5       $�� ��6,   $
��Left=�67   $	��Top=�6R   $��272,317,0,0q�6j   $	��208��6   �� 5!      -   5         ��Name$ 
VoltarMenu��5!      $��Voltar para o menu��6)   $
��Left=�6F   $	��Top=�6a   $	��129��6y   $��241,473,0,0q�6�   6�   5"      5#      5$      