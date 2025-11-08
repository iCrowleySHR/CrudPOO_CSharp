<div align="center">

# 🛍️ ProdutosSQL – Sistema de Controle de Produtos  
### C# · Windows Forms · MySQL · POO · CRUD  

![C#](https://img.shields.io/badge/C%23-.NET%20Framework-512BD4?logo=csharp)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-UI-blue)
![MySQL](https://img.shields.io/badge/MySQL-Database-00758F?logo=mysql)
![POO](https://img.shields.io/badge/POO-Object%20Oriented%20Programming-orange)
![CRUD](https://img.shields.io/badge/CRUD-Create%20Read%20Update%20Delete-success)
![GitHub](https://img.shields.io/badge/GitHub-Version%20Control-black?logo=github)
![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio-5C2D91?logo=visualstudio)

</div>

---

## Sobre o projeto

Este projeto é uma aplicação Windows Forms desenvolvida em **C# (.NET Framework)**, utilizando **Programação Orientada a Objetos (POO)** e **MySQL** como banco de dados.  
Ele permite **cadastrar, listar, editar e excluir produtos**, exibindo os dados em um **DataGridView** com botões de ação e um formulário de detalhes.

---

## Funcionalidades

- 🧾 **Cadastro de produtos**
- 📋 **Listagem automática dos produtos cadastrados**
- ✏️ **Edição de informações diretamente em um formulário de detalhes**
- ❌ **Exclusão de produtos com confirmação**
- 💰 **Cálculo e exibição de preço com desconto na criação de produtos**
- 🔄 **Atualização automática do grid após operações**

---

## Estrutura do Projeto

```bash
ProdutosSQL/
├── DAL/
│   ├── DAL.cs                  # Classe genérica para operações CRUD (Insert, Read)
│   ├── ProdutoDAL.cs           # Classe específica para operações com Produto
│
├── Connection/
│    └── Conexao.cs              # Classe de conexão com o banco MySQL
│
├── Models/
│   └── Produto.cs              # Modelo da entidade Produto
│
├── Forms/
│   ├── Form1.cs                # Tela principal (lista os produtos)
│   ├── FormCadProdutos.cs      # Tela para cadastrar novos produtos
│   └── FormEditarExcluirProduto.cs # Tela de detalhes (editar/excluir)
│
└── Program.cs                  # Ponto de entrada do sistema
```

---

## Estrutura do Banco de Dados

O banco utilizado é **MySQL/MariaDB**.  
Crie o banco e a tabela com o seguinte script SQL:

```bash
CREATE DATABASE Controle_Produtos;

USE Controle_Produtos;

CREATE TABLE Produto (
  idProduto INT NOT NULL AUTO_INCREMENT,
  Nome_Produto VARCHAR(45) NOT NULL,
  Preco_Normal DECIMAL(10,2) NOT NULL,
  Preco_Desconto DECIMAL(10,2) NULL,
  PRIMARY KEY (idProduto)
);
```

---

## Configuração da Conexão

No arquivo `Conexao.cs`, configure a string de conexão conforme o seu ambiente local:

'''
string connectionString = "server=localhost;database=Controle_Produtos;user=root;password=;";
'''

>  Se estiver usando o XAMPP ou WAMP, o usuário padrão é `root` e a senha geralmente está vazia.

---

## Padrão de Código

O projeto segue boas práticas de **POO e camadas**:
- **Models:** representam as entidades do sistema.  
- **DAL (Data Access Layer):** camada de acesso ao banco de dados (CRUD genérico e específico).  
- **Forms:** camada de interface com o usuário (Windows Forms).

---

## Interface do Sistema

**Tela principal (Form1):**
- Exibe a lista de produtos em um `DataGridView`.
- Contém botões de ação para abrir o formulário de **cadastro** e **detalhes**.

**FormCadProdutos:**
- Permite inserir novos produtos.
- Calcula e mostra o preço com desconto automaticamente.

**FormEditarExcluirProduto:**
- Exibe detalhes do produto selecionado.
- Permite **editar** ou **excluir** o produto diretamente.
