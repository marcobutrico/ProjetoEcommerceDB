USE Ecommerce 
-- Define o banco de dados correto para as atividades a serem executadas - depois de criado!

-- Linguagem SQL (Structured Query Language)
-- Linguagens de programacao baseadas em SQL: T-SQL (Microsoft) e PL/SQL (Oracle)
-- SQL Comandos: 

--> DDL (Data Definition Language):
--> Criar, alterar, editar ou apagar banco de dados e tabelas
-- Comandos: CREATE, ALTER e DROP
----------------------------------------
--> DML (Data Manipulation Language):
--> Criar, alterar, editar ou apagar dados
-- Comandos: INSERT, DELETE e UPDATE
----------------------------------------
--> DQL (Data Query Language)
--> Comandos de consulta: SELECT
----------------
-- DTL (Data Transaction Language) - Linguagem de Transação de Dados.
--> São os comandos para controle de transação.
-- São comandos DTL : BEGIN TRANSACTION, COMMIT E ROLLBACK
----------------
-- DCL (Data Control Language) - Linguagem de Controle de Dados.
-- São os comandos para controlar a parte de segurança do banco de dados.
-- São comandos DCL : GRANT, REVOKE E DENY.

CREATE DATABASE Ecommerce
--DROP DATABASE Ecommerce (exclui o banco de dados / tabela)

-- Nome da tabela no singular, começando com a primeira letra em maiúscula
CREATE TABLE Cliente (
	-- PRIMARY KEY - coluna que identifica o cliente
	IdCliente INT PRIMARY KEY IDENTITY, 
	NomeCompleto VARCHAR(150),
	Email VARCHAR(100), 
	Telefone VARCHAR(20),
	Endereco VARCHAR(200),
	DataCadastro DATE,
)

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY, 
	DataPedido DATE,
	StatusPedido VARCHAR(20), 
	ValorTotal DECIMAL(18, 6),
    IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
)

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY, 
	NomeProduto VARCHAR(255),
	Email VARCHAR(100), 
	Preco Decimal(12,6),
	Estoque INT,
	Categoria VARCHAR(100), 
	Imagem VARCHAR(100)
)

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR(20),
	StatusPagamento VARCHAR(20),
	DataPagamento DATETIME,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido)
)

CREATE TABLE ItemPedido (
	IdItem INT PRIMARY KEY IDENTITY, 
	Quantidade INT,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto)
)

-- ALTER TABLE TabelaFilho
-- ADD CONSTRAINT FK_TabelaFilho_TabelaPai FOREIGN KEY (IdPai)
-- REFERENCES TabelaPai(Id);