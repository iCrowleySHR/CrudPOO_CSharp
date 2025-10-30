create database Controle_Produtos;

use Controle_Produtos;

CREATE TABLE Produto (
idProduto INT NOT NULL AUTO_INCREMENT,
Nome_Produto VARCHAR(45) NULL,
Preco_Normal DECIMAL(10,2) NULL,
Preco_Desconto DECIMAL(10,2) NULL,
PRIMARY KEY (idProduto));


INSERT INTO Produto (Nome_Produto, Preco_Normal, Preco_Desconto) VALUES ('Pen Drive', 18.00, 18.00* 0.9);
INSERT INTO Produto (Nome_Produto, Preco_Normal, Preco_Desconto) VALUES ('Lápis', 1.00, 1.00 * 0.9);
INSERT INTO Produto (Nome_Produto, Preco_Normal, Preco_Desconto) VALUES ('Apontador', 1.20, 1.20 * 0.90);