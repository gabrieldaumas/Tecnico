-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 13-Out-2016 às 07:35
-- Versão do servidor: 10.1.10-MariaDB
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tcc`
--
CREATE DATABASE IF NOT EXISTS `tcc` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `tcc`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `alimento`
--

CREATE TABLE `alimento` (
  `CodigoAlimento` text NOT NULL,
  `Nome` text NOT NULL,
  `quantidade` text NOT NULL,
  `Caloria` text NOT NULL,
  `Proteinas` int(11) NOT NULL,
  `Carboidratos` int(11) NOT NULL,
  `Fibra` int(11) NOT NULL,
  `Acucares` int(11) NOT NULL,
  `Gorduras` int(11) NOT NULL,
  `Saturada` int(11) NOT NULL,
  `Poliinsaturada` int(11) NOT NULL,
  `Monoinsaturada` int(11) NOT NULL,
  `Trans` int(11) NOT NULL,
  `Colesterol` int(11) NOT NULL,
  `Sodio` int(11) NOT NULL,
  `Potassio` int(11) NOT NULL,
  `VitaminaA` int(11) NOT NULL,
  `VitaminaC` int(11) NOT NULL,
  `Calcio` int(11) NOT NULL,
  `Ferro` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `alimento`
--

INSERT INTO `alimento` (`CodigoAlimento`, `Nome`, `quantidade`, `Caloria`, `Proteinas`, `Carboidratos`, `Fibra`, `Acucares`, `Gorduras`, `Saturada`, `Poliinsaturada`, `Monoinsaturada`, `Trans`, `Colesterol`, `Sodio`, `Potassio`, `VitaminaA`, `VitaminaC`, `Calcio`, `Ferro`) VALUES
('1', 'oie', 'oi', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
('1', 'oie', 'oi', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
('2', 'oie', '1', '50', 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `atividade`
--

CREATE TABLE `atividade` (
  `codigoatividade` varchar(70) NOT NULL,
  `Nome` text NOT NULL,
  `dia` text NOT NULL,
  `tipoatividade` text NOT NULL,
  `gastocalorico` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `foto_diario`
--

CREATE TABLE `foto_diario` (
  `Email` varchar(70) NOT NULL,
  `Data_foto` date NOT NULL,
  `Foto_dia` blob NOT NULL,
  `Peso` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `imc`
--

CREATE TABLE `imc` (
  `Inicio` text NOT NULL,
  `Fim` text NOT NULL,
  `Classificacao` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `imc`
--

INSERT INTO `imc` (`Inicio`, `Fim`, `Classificacao`) VALUES
('0', '18,49', 'Abaixo do peso ideal'),
('18,5', '24,99', 'Peso ideal'),
('25', '29,99', 'Sobrepeso'),
('30', '34,99', 'Obesidade I ou leve'),
('35', '39,99', 'Obesidade II ou severa'),
('40', '100', 'Obesidade III ou mórbida');

-- --------------------------------------------------------

--
-- Estrutura da tabela `lembrete`
--

CREATE TABLE `lembrete` (
  `Email` varchar(70) NOT NULL,
  `Tipo_lembrete` text NOT NULL,
  `Lembrete_Texto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `rcq`
--

CREATE TABLE `rcq` (
  `Idade_Inicio` text NOT NULL,
  `Idade_Fim` text NOT NULL,
  `Inicio` text NOT NULL,
  `Fim` text NOT NULL,
  `Sexo` text NOT NULL,
  `Classificacao` text NOT NULL,
  `Texto` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `rcq`
--

INSERT INTO `rcq` (`Idade_Inicio`, `Idade_Fim`, `Inicio`, `Fim`, `Sexo`, `Classificacao`, `Texto`) VALUES
('0', '29', '0', '0,82', 'Masculino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,82\n Risco Moderado: Entre 0,83 e 0,88 \n Risco Alto: Entre 0,89 e 0,94 \n Risco Muito Alto: Maior que 0,95'),
('30', '39', '0', '0,83', 'Masculino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,83\n Risco Moderado: Entre 0,84 e 0,91 \n Risco Alto: Entre 0,92 e 0,96 \n Risco Muito Alto: Maior que 0,97'),
('40', '49', '0', '0,87', 'Masculino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,87\n Risco Moderado: Entre 0,88 e 0,95 \n Risco Alto: Entre 0,96 e 1,00 \n Risco Muito Alto: Maior ou igual a 1,01'),
('50', '59', '0', '0,89', 'Masculino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,89\n Risco Moderado: Entre 0,90 e 0,96 \n Risco Alto: Entre 0,97 e 1,02 \n Risco Muito Alto: Maior ou igual a 1,03'),
('60', '200', '0', '0,90', 'Masculino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,90 \n Risco Moderado: Entre 0,91 e 0,98 \n Risco Alto: Entre 0,99 e 1,03 \n Risco Muito Alto: Maior ou igual a 1,04'),
('0', '29', '0,83', '0,88', 'Masculino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,82\n Risco Moderado: Entre 0,83 e 0,88 \n Risco Alto: Entre 0,89 e 0,94 \n Risco Muito Alto: Maior que 0,95'),
('30', '39', '0,84', '0,91', 'Masculino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,83\n Risco Moderado: Entre 0,84 e 0,91 \n Risco Alto: Entre 0,92 e 0,96 \n Risco Muito Alto: Maior que 0,97'),
('40', '49', '0,88', '0,95', 'Masculino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,87\n Risco Moderado: Entre 0,88 e 0,95 \n Risco Alto: Entre 0,96 e 1,00 \n Risco Muito Alto: Maior ou igual a 1,01'),
('50', '59', '0,90', '0,96', 'Masculino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,89\n Risco Moderado: Entre 0,90 e 0,96 \n Risco Alto: Entre 0,97 e 1,02 \n Risco Muito Alto: Maior ou igual a 1,03'),
('60', '200', '0,91', '0,98', 'Masculino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,90 \n Risco Moderado: Entre 0,91 e 0,98 \n Risco Alto: Entre 0,99 e 1,03 \n Risco Muito Alto: Maior ou igual a 1,04'),
('0', '29', '0,89', '0,94', 'Masculino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,82\n Risco Moderado: Entre 0,83 e 0,88 \n Risco Alto: Entre 0,89 e 0,94 \n Risco Muito Alto: Maior que 0,95'),
('30', '39', '0,92', '0,96', 'Masculino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,83\n Risco Moderado: Entre 0,84 e 0,91 \n Risco Alto: Entre 0,92 e 0,96 \n Risco Muito Alto: Maior que 0,97'),
('40', '49', '0,96', '1,00', 'Masculino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,87\n Risco Moderado: Entre 0,88 e 0,95 \n Risco Alto: Entre 0,96 e 1,00 \n Risco Muito Alto: Maior ou igual a 1,01'),
('50', '59', '0,97', '1,02', 'Masculino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,89\n Risco Moderado: Entre 0,90 e 0,96 \n Risco Alto: Entre 0,97 e 1,02 \n Risco Muito Alto: Maior ou igual a 1,03'),
('60', '200', '0,99', '1,03', 'Masculino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,90 \n Risco Moderado: Entre 0,91 e 0,98 \n Risco Alto: Entre 0,99 e 1,03 \n Risco Muito Alto: Maior ou igual a 1,04'),
('0', '29', '0,95', '3,20', 'Masculino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,82\n Risco Moderado: Entre 0,83 e 0,88 \n Risco Alto: Entre 0,89 e 0,94 \n Risco Muito Alto: Maior que 0,95'),
('30', '39', '0,97', '3,20', 'Masculino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,83\n Risco Moderado: Entre 0,84 e 0,91 \n Risco Alto: Entre 0,92 e 0,96 \n Risco Muito Alto: Maior que 0,97'),
('40', '49', '1,01', '3,20', 'Masculino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,87\n Risco Moderado: Entre 0,88 e 0,95 \n Risco Alto: Entre 0,96 e 1,00 \n Risco Muito Alto: Maior ou igual a 1,01'),
('50', '59', '1,03', '3,20', 'Masculino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,89\n Risco Moderado: Entre 0,90 e 0,96 \n Risco Alto: Entre 0,97 e 1,02 \n Risco Muito Alto: Maior ou igual a 1,03'),
('60', '200', '1,04', '3,20', 'Masculino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,90 \n Risco Moderado: Entre 0,91 e 0,98 \n Risco Alto: Entre 0,99 e 1,03 \n Risco Muito Alto: Maior ou igual a 1,04'),
('0', '29', '0', '0,70', 'Feminino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,70\n Risco Moderado: Entre 0,71 e 0,77 \n Risco Alto: Entre 0,78 e 0,82 \n Risco Muito Alto: Maior que 0,83'),
('30', '39', '0', '0,71', 'Feminino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,71\n Risco Moderado: Entre 0,72 e 0,78 \n Risco Alto: Entre 0,79 e 0,84 \n Risco Muito Alto: Maior que 0,85'),
('40', '49', '0', '0,72', 'Feminino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,72\n Risco Moderado: Entre 0,73 e 0,79 \n Risco Alto: Entre 0,80 e 0,87 \n Risco Muito Alto: Maior ou igual a 0,88'),
('50', '59', '0', '0,73', 'Feminino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,73\n Risco Moderado: Entre 0,74 e 0,81 \n Risco Alto: Entre 0,82 e 0,88 \n Risco Muito Alto: Maior ou igual a 0,89'),
('60', '200', '0', '0,75', 'Feminino', 'Risco Baixo', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,75 \n Risco Moderado: Entre 0,76 e 0,83 \n Risco Alto: Entre 0,84 e 0,90 \n Risco Muito Alto: Maior ou igual a 0,91'),
('0', '29', '0,71', '0,77', 'Feminino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,70\n Risco Moderado: Entre 0,71 e 0,77 \n Risco Alto: Entre 0,78 e 0,82 \n Risco Muito Alto: Maior que 0,83'),
('30', '39', '0,72', '0,78', 'Feminino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,71\n Risco Moderado: Entre 0,72 e 0,78 \n Risco Alto: Entre 0,79 e 0,84 \n Risco Muito Alto: Maior que 0,85'),
('40', '49', '0,73', '0,79', 'Feminino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,72\n Risco Moderado: Entre 0,73 e 0,79 \n Risco Alto: Entre 0,80 e 0,87 \n Risco Muito Alto: Maior ou igual a 0,88'),
('50', '59', '0,74', '0,81', 'Feminino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,73\n Risco Moderado: Entre 0,74 e 0,81 \n Risco Alto: Entre 0,82 e 0,88 \n Risco Muito Alto: Maior ou igual a 0,89'),
('60', '200', '0,76', '0,83', 'Feminino', 'Risco Moderado', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,75 \n Risco Moderado: Entre 0,76 e 0,83 \n Risco Alto: Entre 0,84 e 0,90 \n Risco Muito Alto: Maior ou igual a 0,91'),
('0', '29', '0,78', '0,82', 'Feminino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,70\n Risco Moderado: Entre 0,71 e 0,77 \n Risco Alto: Entre 0,78 e 0,82 \n Risco Muito Alto: Maior que 0,83'),
('30', '39', '0,79', '0,84', 'Feminino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,71\n Risco Moderado: Entre 0,72 e 0,78 \n Risco Alto: Entre 0,79 e 0,84 \n Risco Muito Alto: Maior que 0,85'),
('40', '49', '0,80', '0,87', 'Feminino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,72\n Risco Moderado: Entre 0,73 e 0,79 \n Risco Alto: Entre 0,80 e 0,87 \n Risco Muito Alto: Maior ou igual a 0,88'),
('50', '59', '0,82', '0,88', 'Feminino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,73\n Risco Moderado: Entre 0,74 e 0,81 \n Risco Alto: Entre 0,82 e 0,88 \n Risco Muito Alto: Maior ou igual a 0,89'),
('60', '200', '0,84', '0,90', 'Feminino', 'Risco Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,75 \n Risco Moderado: Entre 0,76 e 0,83 \n Risco Alto: Entre 0,84 e 0,90 \n Risco Muito Alto: Maior ou igual a 0,91'),
('0', '29', '0,83', '3,20', 'Feminino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,70\n Risco Moderado: Entre 0,71 e 0,77 \n Risco Alto: Entre 0,78 e 0,82 \n Risco Muito Alto: Maior que 0,83'),
('30', '39', '0,85', '3,20', 'Feminino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,71\n Risco Moderado: Entre 0,72 e 0,78 \n Risco Alto: Entre 0,79 e 0,84 \n Risco Muito Alto: Maior que 0,85'),
('40', '49', '0,88', '3,20', 'Feminino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,72\n Risco Moderado: Entre 0,73 e 0,79 \n Risco Alto: Entre 0,80 e 0,87 \n Risco Muito Alto: Maior ou igual a 0,88'),
('50', '59', '0,89', '3,20', 'Feminino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,73\n Risco Moderado: Entre 0,74 e 0,81 \n Risco Alto: Entre 0,82 e 0,88 \n Risco Muito Alto: Maior ou igual a 0,89'),
('60', '200', '0,91', '3,20', 'Feminino', 'Risco Muito Alto', 'Relação Cintura-Quadril \n\n Risco Baixo: Até 0,75 \n Risco Moderado: Entre 0,76 e 0,83 \n Risco Alto: Entre 0,84 e 0,90 \n Risco Muito Alto: Maior ou igual a 0,91');

-- --------------------------------------------------------

--
-- Estrutura da tabela `refeicao`
--

CREATE TABLE `refeicao` (
  `Email` varchar(70) NOT NULL,
  `nome_refeicao` text NOT NULL,
  `hora_refeicao` varchar(70) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarioalimento`
--

CREATE TABLE `usuarioalimento` (
  `Email` text NOT NULL,
  `dia` text NOT NULL,
  `codigoalimento` text NOT NULL,
  `codigorefeicao` text NOT NULL,
  `quantidade` text NOT NULL,
  `caloriasingeridas` text NOT NULL,
  `carbsingeridos` text NOT NULL,
  `proteinasingeridas` text NOT NULL,
  `gordurasingeridas` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuarioalimento`
--

INSERT INTO `usuarioalimento` (`Email`, `dia`, `codigoalimento`, `codigorefeicao`, `quantidade`, `caloriasingeridas`, `carbsingeridos`, `proteinasingeridas`, `gordurasingeridas`) VALUES
('asdasdasd', '', 'asdasdasd', 'hllhl', 'hklhklhkl', 'hklhklhkl', 'hlhklhkl', 'hlhklhkl', 'hkllkhkl');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarioatividade`
--

CREATE TABLE `usuarioatividade` (
  `Email` int(11) NOT NULL,
  `codigoatividade` int(11) NOT NULL,
  `tempoatividade` int(11) NOT NULL,
  `gastocalorico` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariocalculos`
--

CREATE TABLE `usuariocalculos` (
  `Email` varchar(70) NOT NULL,
  `IMC` text NOT NULL,
  `RCQ` text NOT NULL,
  `TMB` text NOT NULL,
  `Meta` text NOT NULL,
  `RegistroAtividade` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariocalculos`
--

INSERT INTO `usuariocalculos` (`Email`, `IMC`, `RCQ`, `TMB`, `Meta`, `RegistroAtividade`) VALUES
('robertogomes@gmail.com', '18', '1', '2804', '57', '31/08/2016 00:00:00'),
('gabrieldaumas@outlook.com', '30', '0', '3043', '83', '01/09/2016 00:00:00'),
('veiga.marcelle@gmail.com', '17', '0', '1866', '49', '01/09/2016 00:00:00'),
('higormendes@gmail.com', '24', '1', '2642', '75', '01/09/2016 00:00:00'),
('flaviocosta@gmail.com', '29', '0', '3350', '93', '01/09/2016 00:00:00'),
('lucas.dantaz@gmail.com', '25', '1', '2626', '79', '01/09/2016 00:00:00'),
('gg@gg.com', '29', '0', '3011', '81', '13/09/2016 00:00:00'),
('gge@gg.com', '27', '0', '2986', '77', '02/10/2016 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariofeed`
--

CREATE TABLE `usuariofeed` (
  `Email` text NOT NULL,
  `dia` text NOT NULL,
  `frase` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarioinfo`
--

CREATE TABLE `usuarioinfo` (
  `Email` varchar(70) NOT NULL,
  `Nome` text NOT NULL,
  `Sobrenome` text NOT NULL,
  `DataNascimento` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuarioinfo`
--

INSERT INTO `usuarioinfo` (`Email`, `Nome`, `Sobrenome`, `DataNascimento`) VALUES
('robertogomes@gmail.com', 'Roberto', 'Gomes', '21/03/1999'),
('gabrieldaumas@outlook.com', 'Gabriel', 'Daumas', '30/01/1999'),
('veiga.marcelle@gmail.com', 'Marcelle', 'Veiga', '17/03/1999'),
('higormendes@gmail.com', 'Higor', 'Mendes', '11/12/2006'),
('flaviocosta@gmail.com', 'Flavio', 'Costa', '21/02/1999'),
('lucas.dantaz@gmail.com', 'Lucas', 'Dantas do Nascimento', '26/05/1994'),
('gg@gg.com', 'asdfas', 'qsdasd', '30/01/1999'),
('gge@gg.com', 'Gabriel', 'Daumas', '19/12/2006');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarioinfodetalhes`
--

CREATE TABLE `usuarioinfodetalhes` (
  `Email` varchar(70) NOT NULL,
  `Sexo` text NOT NULL,
  `NivelAtividade` text NOT NULL,
  `RegistroAtividade` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuarioinfodetalhes`
--

INSERT INTO `usuarioinfodetalhes` (`Email`, `Sexo`, `NivelAtividade`, `RegistroAtividade`) VALUES
('robertogomes@gmail.com', 'Masculino', 'Muito Ativo', '31/08/2016 00:00:00'),
('gabrieldaumas@outlook.com', 'Masculino', 'Ativo', '01/09/2016 00:00:00'),
('veiga.marcelle@gmail.com', 'Feminino', 'Levemente Ativo', '01/09/2016 00:00:00'),
('higormendes@gmail.com', 'Masculino', 'Levemente Ativo', '01/09/2016 00:00:00'),
('flaviocosta@gmail.com', 'Masculino', 'Ativo', '01/09/2016 00:00:00'),
('lucas.dantaz@gmail.com', 'Masculino', 'Levemente Ativo', '01/09/2016 00:00:00'),
('gg@gg.com', 'Masculino', 'Ativo', '13/09/2016 00:00:00'),
('gge@gg.com', 'Masculino', 'Ativo', '02/10/2016 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariologin`
--

CREATE TABLE `usuariologin` (
  `Email` varchar(70) NOT NULL,
  `Senha` varchar(70) NOT NULL,
  `RegistroCadastro` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariologin`
--

INSERT INTO `usuariologin` (`Email`, `Senha`, `RegistroCadastro`) VALUES
('robertogomes@gmail.com', 'roberto1234', '31/08/2016 00:00:00'),
('gabrieldaumas@outlook.com', 'G300199Da', '01/09/2016 00:00:00'),
('veiga.marcelle@gmail.com', 'abcdefghi', '01/09/2016 00:00:00'),
('higormendes@gmail.com', 'higor1234', '01/09/2016 00:00:00'),
('flaviocosta@gmail.com', '12345678', '01/09/2016 00:00:00'),
('lucas.dantaz@gmail.com', 'macaxeraaimpimemandi', '01/09/2016 00:00:00'),
('gg@gg.com', '12345678', '13/09/2016 00:00:00'),
('1', '1', '1'),
('1@1.com', '1', '1'),
('gg@gg.com', '1', '1'),
('gge@gg.com', 'G300199Da', '02/10/2016 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariomedidas`
--

CREATE TABLE `usuariomedidas` (
  `Email` varchar(70) NOT NULL,
  `Altura` int(11) NOT NULL,
  `Peso` int(11) NOT NULL,
  `Torax` int(11) NOT NULL,
  `Abdomen` int(11) NOT NULL,
  `Cintura` int(11) NOT NULL,
  `Quadril` int(11) NOT NULL,
  `BF` int(11) NOT NULL,
  `RegistroAtividade` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariomedidas`
--

INSERT INTO `usuariomedidas` (`Email`, `Altura`, `Peso`, `Torax`, `Abdomen`, `Cintura`, `Quadril`, `BF`, `RegistroAtividade`) VALUES
('robertogomes@gmail.com', 175, 58, 60, 45, 55, 50, 20, '31/08/2016 00:00:00'),
('gabrieldaumas@outlook.com', 168, 85, 99, 102, 89, 108, 20, '01/09/2016 00:00:00'),
('veiga.marcelle@gmail.com', 168, 50, 100, 70, 60, 80, 20, '01/09/2016 00:00:00'),
('higormendes@gmail.com', 175, 76, 60, 50, 60, 55, 20, '01/09/2016 00:00:00'),
('flaviocosta@gmail.com', 180, 95, 98, 102, 99, 108, 20, '01/09/2016 00:00:00'),
('lucas.dantaz@gmail.com', 178, 80, 90, 90, 90, 90, 20, '01/09/2016 00:00:00'),
('gg@gg.com', 168, 83, 97, 100, 86, 106, 20, '13/09/2016 00:00:00'),
('gge@gg.com', 168, 78, 97, 98, 86, 106, 20, '02/10/2016 00:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariometanutricao`
--

CREATE TABLE `usuariometanutricao` (
  `Email` text NOT NULL,
  `Proteinas` int(11) NOT NULL,
  `Carboidratos` int(11) NOT NULL,
  `Fibra` int(11) NOT NULL,
  `Acucares` int(11) NOT NULL,
  `Gorduras` int(11) NOT NULL,
  `Saturada` int(11) NOT NULL,
  `Poliinsaturada` int(11) NOT NULL,
  `Monoinsaturada` int(11) NOT NULL,
  `Trans` int(11) NOT NULL,
  `Colesterol` int(11) NOT NULL,
  `Sodio` int(11) NOT NULL,
  `Potassio` int(11) NOT NULL,
  `VitaminaA` int(11) NOT NULL,
  `VitaminaC` int(11) NOT NULL,
  `Calcio` int(11) NOT NULL,
  `Ferro` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariometarestart`
--

CREATE TABLE `usuariometarestart` (
  `Email` text NOT NULL,
  `Inicio` text NOT NULL,
  `Final` text NOT NULL,
  `Calorias` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariometarestart`
--

INSERT INTO `usuariometarestart` (`Email`, `Inicio`, `Final`, `Calorias`) VALUES
('gge@gg.com', '02/10/2016 00:00:00', '17/10/2016 00:00:00', '2986,57');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariorecuperacao`
--

CREATE TABLE `usuariorecuperacao` (
  `Email` varchar(70) NOT NULL,
  `Pergunta1` text NOT NULL,
  `Resposta1` text NOT NULL,
  `Pergunta2` text NOT NULL,
  `Resposta2` text NOT NULL,
  `Pergunta3` text NOT NULL,
  `Resposta3` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariorecuperacao`
--

INSERT INTO `usuariorecuperacao` (`Email`, `Pergunta1`, `Resposta1`, `Pergunta2`, `Resposta2`, `Pergunta3`, `Resposta3`) VALUES
('robertogomes@gmail.com', 'Gol', 'Flamengo', 'Tem', 'Dinheiro', 'Não', 'Que Pena'),
('gabrieldaumas@outlook.com', 'Qual é o nome da sua mãe?', 'Conceição', 'Qual é o nome do seu pai?', 'Antonio', 'Qual é o seu esporte predileto?', 'Futebol'),
('veiga.marcelle@gmail.com', 'qual o nome do seu cachorro?', 'Bela', 'Qual o nome do seu professor de eng de soft?', 'flavio', 'Qual a pessoa mais chata da sala?', 'Renan'),
('higormendes@gmail.com', 'Qual é o nome do seu professor de ES?', 'Flavio', 'Qual é o nome do seu cachorro?', 'Bela', 'Qual é o seu esporte predileto?', 'Nada'),
('flaviocosta@gmail.com', 'a', 'a', 'a', 'a', 'a', 'a'),
('lucas.dantaz@gmail.com', 'Qual o nome do meu primeiro cachorro ?', 'Max', 'Qual o nome do seu primeiro colégio ?', 'João Lyra Filho', 'Sua cor preferida ?', 'Azul'),
('gg@gg.com', 'as', 'as', 'as', 'as', 'as', 'as'),
('gge@gg.com', 'dasdasd', 'dasdasd', 'dasdasd', 'dasdasd', 'dasdasd', 'dasdasd');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuariorotina`
--

CREATE TABLE `usuariorotina` (
  `Email` text NOT NULL,
  `codigorefeicao` text NOT NULL,
  `dia` text NOT NULL,
  `nome` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `usuariorotina`
--

INSERT INTO `usuariorotina` (`Email`, `codigorefeicao`, `dia`, `nome`) VALUES
('gabrieldaumas@outlook.com', '0', '12/10/2016', 'tudo bem'),
('gabrieldaumas@outlook.com', '0', '13/10/2016', '');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
