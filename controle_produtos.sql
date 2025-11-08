-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 08/11/2025 às 04:43
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

CREATE DATABASE IF NOT EXISTS `controle_produtos` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `controle_produtos`;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";




/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `controle_produtos`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `log_produto`
--

CREATE TABLE `log_produto` (
  `idLog` int(11) NOT NULL,
  `idProduto` int(11) DEFAULT NULL,
  `Nome_Produto` varchar(45) DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `log_produto`
--

INSERT INTO `log_produto` (`idLog`, `idProduto`, `Nome_Produto`, `DataExclusao`) VALUES
(1, 1, 'Pen Drive', '2025-11-08 00:39:51');

-- --------------------------------------------------------

--
-- Estrutura para tabela `produto`
--

CREATE TABLE `produto` (
  `idProduto` int(11) NOT NULL,
  `Nome_Produto` varchar(45) DEFAULT NULL,
  `Preco_Normal` decimal(10,2) DEFAULT NULL,
  `Preco_Desconto` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `produto`
--

INSERT INTO `produto` (`idProduto`, `Nome_Produto`, `Preco_Normal`, `Preco_Desconto`) VALUES
(2, 'L?pis', 1.00, 0.90),
(3, 'Apontador', 1.20, 1.08);

--
-- Acionadores `produto`
--
DELIMITER $$
CREATE TRIGGER `trg_delete_produto` AFTER DELETE ON `produto` FOR EACH ROW BEGIN
  INSERT INTO Log_Produto (idProduto, Nome_Produto, DataExclusao)
  VALUES (OLD.idProduto, OLD.Nome_Produto, NOW()); 
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_insert_produto` BEFORE INSERT ON `produto` FOR EACH ROW BEGIN
  SET NEW.Preco_Desconto = NEW.Preco_Normal * 0.9;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `trg_update_produto` BEFORE UPDATE ON `produto` FOR EACH ROW BEGIN
  
  IF NEW.Preco_Normal <> OLD.Preco_Normal THEN
    SET NEW.Preco_Desconto = NEW.Preco_Normal * 0.9;
  END IF;
END
$$
DELIMITER ;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `log_produto`
--
ALTER TABLE `log_produto`
  ADD PRIMARY KEY (`idLog`);

--
-- Índices de tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`idProduto`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `log_produto`
--
ALTER TABLE `log_produto`
  MODIFY `idLog` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `idProduto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
