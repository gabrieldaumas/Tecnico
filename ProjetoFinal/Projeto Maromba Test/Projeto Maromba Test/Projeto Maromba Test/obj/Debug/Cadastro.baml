   M S B A M L   `   `   `  ����  Projeto Maromba Test#    Projeto_Maromba_Test.Cadastro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Window1��5   	   $	��492��6   $	��635��6&    � 
ResizeMode$ CanMinimize=�62    � WindowStyle$
 None=�6K    � WindowStartupLocation$ CenterScreen=�6^    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   CloseWindowCommand   Command# Z 5      6y     5   
   -   5           MinimizeWindowCommand# Z 5      6|   .��5
      � .+�5   
   �� .+�5      �� -   5         ��Name$ VoltarButton��5      #��Z 6+   $��Close��6b   	 �� Left$		 582��6r   

 �� Top$
 7��6�   
�������$��43��6�   $��30��6�   �� 5      -   5        $ MinimizarButton��5      #��Z 6.   $��Minimize��6h   $		 518��6{   $
 7��6�   
�������$��58��6�   $��29��6�   �� 5      -   5        $ EnviarButao��5      $��Enviar��6*   $		 284��6;   $	
 462��6M   $��75��6^   $��28��6~   �� 5      $	��418��6   $	��635��6&   $
 27��62   .@�5      �� $��Informações��6   $��
-3,0,-1,-2q�6/   .��5      � 
�������$��0,3,2,0q�6.   $	��384��6?   $	��Top=�6L    � ColumnDefinitions 5      �� 5      $	��26* �6/   �� 5      $��6* �6/   �� 5      $��53 �6/   �� 5      $	��15* �6/   �� 5      $
��527* �6/   .+�5      �� -   5         ��Name$ NomeText��5   "   $
��Left=�64   $��23��6O   $��	71,33,0,0q�6[   $	��Top=�6n   $	��120��6�   $��4��6�    �� 	MaxLength$ 42��6�    �� MaxLines$ 1��6�   $��1��6�   �� 5      -   5        $ SobreNomeText��5   "   $
��Left=�69   $��23��6T   $��
360,33,0,0q�6`   $	��Top=�6t   $	��120��6�   $��4��6�   $ 42��6�   $ 1��6�   $��2��6�   �� 5      -   5        $ ConfEmailText��5   "   $
��Left=�69   $��23��6T   $��360,163,0,0q�6`   $	��Top=�6u   $	��120��6�   $��4��6�   $ 1��6�   $ 42��6�   $��5��6
  �� 5      -	   5        $ 	EmailText��5   "   $
��Left=�65   $��23��6P   $��
71,163,0,0q�6\   $	��Top=�6p   $	��120��6�   $��4��6�   $ 42��6�   $ 1��6�   $��4��6�   	� 5      -
   5         	�Name$ 	MascRadio��5   &    	� 	GroupName$
 Sexo��69   $��	Masculino��6K   $
��Left=�6_   $	��Top=�6z   $��4��6�   $��
71,293,0,0q�6�   $��8��6�   6�   	� 5      -   5        $ FemRadio��5   &   $
 Sexo��68   $��Feminino��6J   $
��Left=�6]   $	��Top=�6x   $��4��6�   $��213,293,0,0q�6�   $��9��6�   6�   �� 5       $
��Nome��6    $��2��6/   $
��Left=�6?   $��0,30,0,0q�6Z   $	��Top=�6l   $��3��6�   $��93��6�   �� 5!      $��Data de Nascimento��6    $��2��6=   $
��Left=�6M   $��0,98,0,0q�6h   $	��Top=�6z   $��3��6�   $	��118��6�   �� 5"      $��Email��6    $��2��60   $
��Left=�6@   $��	0,159,0,0q�6[   $	��Top=�6n   �� 5#      $
��Sexo��6    $��2��6/   $��Right=�6?   $��
0,287,18,0q�6[   $	��Top=�6o   �� 5$      $��Nivel de Atividade��6    $��2��6=   $
��Left=�6M   $��	0,352,0,0q�6h   $	��Top=�6{   $��3��6�   $	��118��6�   �� 5%      $��Confirmar Email��6    $��4��6:   $
��Left=�6J   $��230,159,0,0q�6e   $	��Top=�6z   �� 5&      $��	Sobrenome��6    $��4��64   $
��Left=�6D   $��
230,30,0,0q�6_   $	��Top=�6s   �� 5'      $��Senha��6    $��2��60   $
��Left=�6@   $��	0,228,0,0q�6[   $	��Top=�6n   �� 5(      $��Confirmar Senha��6    $��4��6:   $
��Left=�6J   $��230,228,0,0q�6e   $	��Top=�6z   	� 5)      -   5        $ LevAtivRadio��5)   &   $ 	Atividade��6<   $��Levemente Ativo��6R   $
��Left=�6l   $	��Top=�6�   $��4��6�   $��177,358,0,0q�6�   $��12��6�   	� 5*      -   5        $ 
SedenRadio��5*   &   $ 	Atividade��6:   $��
Sedentario��6P   $
��Left=�6e   $	��Top=�6�   $��4��6�   $��
71,358,0,0q�6�   $��11��6�   	� 5+      -   5        $ MuitoAtivRadio��5+   &   $ 	Atividade��6>   $��Muito Ativo��6T   $
��Left=�6j   $	��Top=�6�   $��388,358,0,0q�6�   $��4��6�   $��14��6�   	� 5,      -   5        $ 	AtivRadio��5,   &   $ 	Atividade��69   $��Ativo��6O   $
��Left=�6_   $	��Top=�6z   $��313,358,0,0q�6�   $��4��6�   $��13��6�   �� 5-      -   5         ��Name$ 
CheckEmail��5-       $�� ��64   $��4��6?   $
��Left=�6O   $��343,193,0,0q�6j   $	��Top=�6   $	��126��6�   �� 5.      -   5         ��Name$ ImagemCheck��5.       $
��Left=�65   $��19��6P   $	��Top=�6\   $��23��6t   $��4��6   $��315,198,0,0q�6�   �� 5/      -   5        $ 
CheckSenha��5/       $�� ��64   $��4��6?   $
��Left=�6O   $��343,261,0,0q�6j   $	��Top=�6   $	��126��6�   �� 50      -   5        $ ImagemCheckSenha��50       $
��Left=�6:   $��19��6U   $	��Top=�6a   $��23��6y   $��4��6�   $��315,266,0,0q�6�   �� 51      -   5        $ LabelInformativo��51       $,��&Como descobrir meu nivel de atividade?��6:   $��2��6k   $��0,327,405,32q�6{   $��10(�6�   ���	#FF767676$��3��6�   6�   G� 52      -   5         G�Name$ ConfSenhaText��52   &   $
��Left=�6=   $	��Top=�6X   $��23��6p   $	��120��6|   $��360,228,0,0q�6�   $��4��6�    G� 	MaxLength$ 20��6�   $��7��6�   G� 53      -   5        $ 	SenhaText��53   &   $
��Left=�69   $	��Top=�6T   $��23��6l   $	��120��6x   $��
71,228,0,0q�6�   $��4��6�   $ 20��6�   $��6��6�   (  "System.Windows.Controls.DatePicker  54      -   5          Name$ DataNascText��54   %   $
��Left=�6;   $	��Top=�6V   $	��120��6n   $��4��6z   $��	71,98,0,0q�6�   $��26��6�      IsTodayHighlighted .     DisplayDateEnd$ 
2006-12-31X�6�      DisplayDateStart$ 
1900-01-01X�6�   $��3��6�   55      56      �� 57      $��Medidas��6   $��	4,0,-8,-2q�6+   .��58      � 
�������$��0,0,0,-1q�6.   $	��419��6@   $	��Top=�6M    59      �� 5:      $	��31* �6/   �� 5;      $
��163* �6/   �� 5<      $
��321* �6/   �� 5=      $
��114* �6/   .+�5?      �� $��Torax��6    $
��Left=�60   $��1,15,0,0q�6K   $	��Top=�6]   $��1��6u   �� 5@      $��Cintura��6    $
��Left=�62   $��2,75,0,0q�6M   $	��Top=�6_   $��1��6w   �� 5A      $��Abdomen��6    $
��Left=�62   $��	0,135,0,0q�6M   $	��Top=�6`   $��1��6x   �� 5B      $��Quadril��6    $
��Left=�62   $��	0,195,0,0q�6M   $	��Top=�6`   $��1��6x   �� 5C      $��Altura��6    $
��Left=�61   $��	0,255,0,0q�6L   $	��Top=�6_   $��1��6w   �� 5D      $
��Peso��6    $
��Left=�6/   $��	0,315,0,0q�6J   $	��Top=�6]   $��1��6u   �� 5E      $
��Left=�6    $	��390��6;   $	��Top=�6H   $	��187��6`   $��	191,0,0,0q�6l   $��Resource/MAROMBEIRO.png��6   $��2��6�   $��2��6�    � BindingGroup 5F      &   System.Windows.Data.BindingGroup  5G   "      Name$ 
ImagemLogo��6/   5I      $  Xceed.Wpf.Toolkit.SingleUpDown  5J      -   5          Name$ CinturaText��5J   ,   $
��Left=�6A   $	��Top=�6\   $��2��6t   $��0,75,0,0q�6�    J� RenderTransformOrigin$ 	1.488,2.7&�6�   $��26��6�   $��71��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$	 160X�6�      Minimum$ 1X�6�   $��16��6�     5K      -   5        $ AbdomenText��5K   ,   $
��Left=�6A   $	��Top=�6\   $��2��6t   $��	0,135,0,0q�6�   $��26��6�   $��71��6�   $	 180X�6�   $ 1X�6�   $��17��6�     5L      -   5        $ QuadrilText��5L   ,   $
��Left=�6A   $	��Top=�6\   $��2��6t   $��	0,195,0,0q�6�   $��26��6�   $��71��6�   $	 180X�6�   $ 1X�6�   $��18��6�     5M      -   5        $ 
AlturaText��5M   ,   $
��Left=�6@   $	��Top=�6[   $��2��6s   $��	0,255,0,0q�6�   $��26��6�   $��71��6�   $	 220X�6�   $ 1X�6�   $��19��6�     5N      -   5        $ PesoText��5N   ,   $
��Left=�6>   $	��Top=�6Y   $��2��6q   $��	0,315,0,0q�6�   $��26��6�   $��71��6�   $	 220X�6�   $ 1X�6�   $��20��6�     5O      -   5        $ 	ToraxText��5O   ,   $
��Left=�6?   $	��Top=�6Z   $��2��6r   $��0,15,0,0q�6�   $ 	1.488,2.7&�6�   $��26��6�   $��71��6�   $	 160X�6�   $ 1X�6�   $��15��6�   �� 5P      $��cm��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��	85,15,0,0q�6p   �� 5Q      $��cm��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��	85,75,0,0q�6p   �� 5R      $��cm��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��
85,135,0,0q�6p   �� 5S      $��cm��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��
85,195,0,0q�6p   �� 5T      $��cm��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��
85,255,0,0q�6p   �� 5U      $��kg��6    $
��Left=�6-   $	��Top=�6H   $��2��6`   $��
85,315,0,0q�6p   5V      5W      �� 5X      $��Recuperação de Senha��6   $��11,0,-17,-2q�68   .��5Y      � 
�������$��0,0,0,-1q�6.   $	��419��6@   $	��Top=�6M    5Z      �� 5[      $	��31* �6/   �� 5\      $
��163* �6/   �� 5]      $��8* �6/   �� 5^      $
��427* �6/   .+�5`      �� -   5        $ 	Resp3Text��5`   "   $
��Left=�65   $��23��6P   $	��Top=�6\   $	��252��6t   $��	0,360,0,0q�6�   $ 1.067,0.304&�6�   $��2��6�   $ 20��6�   $��2��6�   $��26��6
  �� 5a      -   5        $ Pergunta2Text��5a   "   $
��Left=�69   $��23��6T   $��	0,150,0,0q�6`   $	��Top=�6s   $	��252��6�   $��2��6�   $	 100��6�   $��2��6�   $��23��6�   �� 5b      -    5        $ 	Resp2Text��5b   "   $
��Left=�65   $��23��6P   $��	0,220,0,0q�6\   $	��Top=�6o   $	��252��6�   $��2��6�   $ 20��6�   $��2��6�   $��24��6�   �� 5c      -!   5        $ Pergunta3Text��5c   "   $
��Left=�69   $��23��6T   $��	0,290,0,0q�6`   $	��Top=�6s   $	��252��6�   $��2��6�   $	 100��6�   $��2��6�   $��25��6�   �� 5d      -"   5        $ 	Resp1Text��5d   "   $
��Left=�65   $��23��6P   $��0,80,0,0q�6\   $	��Top=�6n   $	��252��6�   $��2��6�   $ 20��6�   $��2��6�   $��22��6�   �� 5e      -#   5        $ Pergunta1Text��5e   "   $
��Left=�69   $��23��6T   $��0,19,0,0q�6`   $	��Top=�6r   $	��252��6�   $��2��6�   $	 100��6�   $��2��6�   $��21��6�   �� 5f      $��
Pergunta I��6    $
��Left=�65   $	��Top=�6P   $��1��6h   $��	10,16,0,0q�6x   �� 5g      $��
Resposta I��6    $
��Left=�65   $	��Top=�6P   $��1��6h   $��	10,77,0,0q�6x   �� 5h      $��Pergunta II��6    $
��Left=�66   $	��Top=�6Q   $��1��6i   $��
10,147,0,0q�6y   �� 5i      $��Resposta II��6    $
��Left=�66   $	��Top=�6Q   $��1��6i   $��
10,217,0,0q�6y   �� 5j      $��Pergunta III��6    $
��Left=�67   $	��Top=�6R   $��1��6j   $��
10,287,0,0q�6z   �� 5k      $��Resposta III��6    $
��Left=�67   $	��Top=�6R   $��1��6j   $��
10,357,0,0q�6z   5l      5m      �� 5n      $��Termo de Responsabilidade��6   $
��Left=�6=   $��20��6X   $	��Top=�6d   $	��158��6|   $��
19,0,-19,0q�6�   .��5o      � ���	#FFE5E5E5 5p      �� 5q      $
��533* �6/   �� 5r      $	��96* �6/   .+�5t      �� $
��Left=�6'   $	��304��6B   $��
127,19,0,0q�6O   $	��Top=�6c   $	��379��6{   $
��Auto=�6�   $��Stretch=�6�   ��. .��5u      �� $
��Auto=�6(   ��. $	��379��6}   $
��Wrap=�6�   �� 6�   $���Este "Termo de Uso" aplica-se ao uso da Rede Software Livre Brasil. Este sistema é um ambiente digital, livre e colaborativo que visa contribuir para o fortalecimento da rede de comunidades de software livre em todo o Brasil, facilitando os fluxos de informação sobre produtos, serviços, projetos e ações relacionados. Este documento apresenta, portanto, as condições de uso deste sistema digital, tanto para pesquisa como para a inclusão de dados e informações. A aceitação deste "Termo de Uso" é requisito necessário para a utilização da Rede Software Livre Brasil, com todas as suas funcionalidades. Toda/os a/os Usuária/os são informados deste Termo de Uso, o qual devem ler, certificar-se de tê-lo entendido e aceitar as condições nele estabelecidas. Desta forma, fica claro que a utilização da Rede Software Livre Brasil implicará na expressa e inequívoca aceitação integral das condições estabelecidas no presente "Termo de Uso".��6�   �� 6r  �� 6~  �� 6�  �� 6�  �� 6�  �� 6�  $5�/1. Da Conta da/o Usuária/o, senha e segurança��6�  �� 6�  �� 6�  �� 6�  �� 6�  $���1.1 Para o registro de sua conta, a/o Usuária/o deverá indicar  uma identificação e uma senha, tornando-se responsável por mantê-las em sigilo, assumindo a total responsabilidade pelas atividades que se realizam por meio delas.��6�  �� 6�  �� 6�  �� 6�  �� 6
  $���1.2 O Usuário compromete-se igualmente em sair ("deslogar") de sua conta ao final de cada sessão. Além disso, concorda em notificar, imediatamente, o administrador da Rede Software Livre Brasil sobre qualquer uso não autorizado por meio da sua senha e conta pessoal ou sobre qualquer quebra de segurança que perceba.��6  �� 6^  �� 6j  �� 6p  �� 6|  �� 6�  �� 6�  $ �2. Do Registro do Usuário��6�  �� 6�  �� 6�  �� 6�  �� 6�  $���2.1 A/O Usuária/o se compromete a fornecer informações verdadeiras, exatas, atuais e completas quando do preenchimento dos campos solicitados no Registro, bem como a conservar e atualizar essas informações, a fim de mantê-las verdadeiras, exatas, atuais e completas.��6�  �� 6�  �� 6�  �� 6�  �� 6		  $���2.2 Caso haja informações falsas, incorretas, desatualizadas ou incompletas no registro do Usuário, a Rede Software Livre Brasil não se responsabiliza pela correção desses Dados inseridos por suas/eus Usuárias/os. A Rede Software Livre Brasil também se reserva o direito de solicitar dados adicionais e documentos que entenda serem pertinentes, a fim de conferir os dados informados pelo Usuário, assim como inabilitar, temporária ou definitivamente o usuário que apresente alguma informação que não seja verdadeira, podendo, ainda, fazê-lo em relação às/os usuárias/os cuja Rede Software Livre Brasil não consiga contatar para a verificação dos dados. Ao ser cancelado o cadastro da/o usuária/o, automaticamente será cancelado seu acesso ao uso deste sistema e também a qualquer serviço a ele relacionado, não sendo devido ao usuário, por esse motivo, o direito a qualquer sorte de indenização ou ressarcimento.��6	  �� 6�  �� 6�  �� 6�  �� 6�  �� 6�  �� 6�  $#�3. Da Conduta da/o Usuária/o��6�  �� 6  �� 6  �� 6  �� 6  $���3.1 A/O Usuária/o concorda que qualquer informação por ela/e publicada ou armazenada por meio deste sistema será de sua total responsabilidade, sendo vedado o uso para a prática de atos que violem qualquer lei ou regulamento local, estadual, nacional ou internacional que lhe seja aplicável.��6#  �� 6P  �� 6\  �� 6b  �� 6n  $���3.2 A/O Usuária/o concorda em não transmitir, exibir ou disponibilizar conteúdo ilegal, ofensivo à honra alheia, que invada a privacidade alheia, que seja obsceno, racista, homofóbico ou de qualquer natureza discriminatória, bem como é igualmente vedado assumir a "personalidade" de outra pessoa, física ou jurídica ou ainda falsamente apresentar-se como membro de entidade ou organização de qualquer natureza da qual não faça parte.��6r  �� 67  �� 6C  �� 6I  �� 6U  $���3.3 A/O Usuária/o concorda em respeitar as pessoas e instituições, não agindo, portanto, de forma a praticar os crimes de calúnia, injúria ou difamação descritos nos artigos 138, 139 e 140 do Código Penal Brasileiro. Portanto, caso a/o usuária/o desrespeite tais normas, estará sujeito à exclusão do perfil, como às penalidades previstas na lei pela parte prejudicada.��6Y  �� 6�  �� 6�  �� 6�  �� 6�  $���3.4 A Rede Software Livre Brasil não se responsabilizará civil ou penalmente em virtude de eventuais danos moral ou material causados pelo conteúdo inserido e publicado no site, sejam tais danos causados a outras/os usuárias/os cadastradas/os ou a terceiros que porventura não estejam cadastrados como usuária/os na Rede Software Livre Brasil.��6�  �� 6V  �� 6b  �� 6h  �� 6t  $���3.5 Quando do recebimento de denúncia sobre violação às condições estabelecidas neste Termo, especialmente quanto à prática de ilícitos, a Rede Software Livre Brasil inabilitará o usuário, no prazo de 24 (vinte e quatro horas), bem como tornará indisponível o conteúdo por ele transmitido, sem que a este seja devido, por esse motivo, o direito a qualquer sorte de indenização ou ressarcimento.��6x  �� 6  �� 6  �� 6  �� 6*  �� 60  �� 6<  $�4. Dos Direitos Autorais��6@  �� 6b  �� 6n  �� 6t  �� 6�  $���4.1 A/O Usuária/o não poderá infringir direitos de terceiros, sobretudo os direitos autorais tais como reproduzir, modificar ou divulgar obra alheia sem autorização prévia do titular.��6�  �� 6E  �� 6Q  �� 6W  �� 6c  $���4.2 A/O Usuária/o, ao aceitar o presente Termo de Uso, autoriza o acesso público aos materiais inseridos no sistema, por meio de uma licença de uso que deve ser explicitada por ela/e no conteúdo publicado.��6g  �� 6>  �� 6J  �� 6P  �� 6\  $���4.3 O usuário se responsabiliza pelas obras que inserir na Rede Software Livre Brasil e deverá observar a legislação em vigor, tanto sob o aspecto formal (como a questão dos direitos autorais) quanto para o conteúdo. O usuário envolvido em denúncias de irregularidades ou infrações a direitos de terceiros desde já, exime a Rede Software Livre Brasil de eventuais litígios decorrentes dos danos que causar. Caso a Rede Software Livre Brasil seja imputada responsabilidade por qualquer dano, moral ou material, em virtude de inserção irregular e consequente danos a terceiros, a Rede Software Livre Brasil moverá a competente ação judicial contra a/o usuária/o infrator, declarando este, desde já, que arcará com todas os ônus processuais decorrentes.��6`  6Y  5v      �� 5w      -$   5         ��Name$ AceitoCheck��5w   #   $9��3Aceito todos os termos do Termo de Responsabilidade��68   $��166,348,57,27q�6v   $��Center=�6�   $��27��6�   5x      5y      �� 5z      $��Percentual de gordura��6   $
��Left=�69   $��20��6T   $	��Top=�6`   $	��129��6x   $��
22,0,-97,0q�6�   .��5{      � ���	#FFE5E5E5 5|      �� 5}      $	��29* �6/   �� 5~      $
��600* �6/   .+�5�      �� -%   5        $ FotoBFM��5�       $��19,138,10,49q�61   $��
Image1.png��6G   $
��Fill=�6[   $��2��6j   $y�Hidden=�6~   �� 5�      -&   5        $ FotoBFF��5�       $��19,138,10,49q�61   $��
Image2.png��6G   $
��Fill=�6[   $��2��6j   $y�Hidden=�6~   	� 5�      -'   5        $ _35M45FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��
22,145,0,0q�6z   $��2��6�   $y�Hidden=�6�   	� 5�      -(   5        $ _30M40FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��
65,145,0,0q�6z   $��1��6�   $y�Hidden=�6�   	� 5�      -)   5        $ _25M35FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��150,145,0,0q�6z   $��1��6�   $y�Hidden=�6�   	� 5�      -*   5        $ _20M30FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��238,145,0,0q�6z   $��1��6�   $y�Hidden=�6�   	� 5�      -+   5        $ _15M25FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��321,145,0,0q�6z   $��1��6�   $y�Hidden=�6�   	� 5�      -,   5        $ _12M20FRadio��5�   &   $�� ��6<   $
��Left=�6G   $	��Top=�6b   $��411,145,0,0q�6z   $��1��6�   $y�Hidden=�6�   	� 5�      --   5        $ _8M15FRadio��5�   &   $�� ��6;   $
��Left=�6F   $��509,145,0,0q�6a   $	��Top=�6v   $��1��6�   $y�Hidden=�6�   	� 5�      -.   5        $ SimRadio��5�   &   $ SimNao��68   $	��Sim��6K   $
��Left=�6Y   $	��Top=�6t   $��
301,27,0,0q�6�   $��1��6�   6�   	� 5�      -/   5        $ NaoRadio��5�   &   $ SimNao��68   $
��Não��6K   $
��Left=�6Y   $	��Top=�6t   $��
388,27,0,0q�6�   $��1��6�   6�   �� 5�      $9��3Você tem conhecimento do seu Percentual de Gordura��6    $
��Left=�6]   $	��Top=�6x   $��	19,21,0,0q�6�   $��2��6�   %  Xceed.Wpf.Toolkit.MaskedTextBox  5�      -0   5           Name$  
QuantoText��5�   -   $
��Left=�6A   $��
301,71,0,0q�6\   ! �� TextWrapping$
! Wrap=�6p   $��MaskedTextBox��6�   $	��Top=�6�   "   Mask$" 00,00%��6�   $��1��6�   $y�Hidden=�6�   �� 5�      -1   5        $ QuantoLabel��5�       $��Quanto?��65   $
��Left=�6G   $	��Top=�6b   $��
244,65,0,0q�6z   # � Cursor$#  ��6�   $��1��6�   $y�Hidden=�6�   �� 5�      -2   5        $ 	CasoLabel��5�       $]��WCaso não conheça, olhe-se no espelho e tente comparar-se a uma dessas figuras humanas��63   $
��Left=�6�   $	��Top=�6�   $��
49,107,0,0q�6�   $��1��6�   $y�Hidden=�6�   �� 5�      -3   5        $ LabelInformativoBF��5�       $*��$Meu percentual de gordura está bom?��6<   $��164,355,246,10q�6j   $��10(�6�   ���	#FF767676$��1��6�   $y�Hidden=�6�   5�      5�      5�      5�      5�      5�      