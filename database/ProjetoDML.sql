-- DML 

Use Ecommerce


INSERT INTO Produto (NomeProduto, Preco, Estoque, Categoria)
VALUES 
/*('Scanner', 340, 25, 'Perif�ricos');
 ('Monitor LED Full HD 24"', 899.900000, 50, 'Monitores'),
('Notebook Gamer i7 16GB', 6999.990000, 20, 'Notebooks'),
('Teclado Mec�nico RGB', 349.900000, 40, 'Perif�ricos'),
('Mouse �ptico Sem Fio', 129.900000, 80, 'Perif�ricos'),
('Impressora Multifuncional Wi-Fi', 1199.900000, 15, 'Impressoras'),
('HD Externo 1TB', 399.900000, 60, 'Armazenamento'),
('SSD 512GB M.2 NVMe', 499.900000, 100, 'Armazenamento'),
('Placa de V�deo RTX 3060 12GB', 2799.900000, 10, 'Componentes'),
('Headset Gamer Surround', 299.900000, 30, 'Perif�ricos'),
('Fonte 750W Modular', 599.900000, 25, 'Componentes');
('Scanner', 340, 25, 'Perif�ricos');
*/

SELECT * FROM Produto

INSERT INTO Cliente (NomeCompleto, Email, Telefone, Endereco, DataCadastro)
VALUES 
-- ('Josefina da Silva', 'zezinha@gmail.com', '(11)987654444', 'Rua dos Loucos, 0 - Sao Paulo/SP', '05/04/2025'),
('Marcos Vinicius', 'mavini@gmail.com', '(11)987654321', 'Rua Niteroi, 180 - S�o Caetano do Sul/SP', '05/04/2025'),
('Daniel Gutierrez', 'danigu@gmail.com', '(11)987652222', 'Rua Copacabana, 180 - S�o Bernardo do Campo/SP', '05/04/2025'),
('Jessica Silva', 'jesilva@gmail.com', '(11)987651111', 'Rua Amazonas, 180 - S�o Paulo/SP', '05/04/2025');

SELECT * FROM Cliente

INSERT INTO Pagamento (FormaPagamento, StatusPagamento, DataPagamento, IdPedido)
VALUES 
('Cart�o de Cr�dito', 'Pago', '2025-04-05 15:30:00', 101),
('Boleto Banc�rio', 'Pendente', '2025-04-06 10:00:00', 102),
('PIX', 'Cancelado', '2025-04-06 12:45:00', 103);

INSERT INTO Pedido (DataPedido, StatusPedido, ValorTotal, IdCliente)
VALUES 
('05/04/2025', 'Conclu�do', 1299.80, 1), -- Pedido de Marcos Vinicius
('05/05/2025', 'Pendente', 399.90, 2),  -- Pedido de Daniel Gutierrez
('05/06/2025', 'Cancelado', 6999.99, 3); -- Pedido de Jessica Silva

SELECT * FROM Pedido

INSERT INTO Pagamento (FormaPagamento, StatusPagamento, DataPagamento, IdPedido)
VALUES
('Cart�o de Cr�dito', 'Pago', '2025-04-05 16:00:00', 1), -- Pagamento de um pedido de Marcos Vinicius
('Boleto Banc�rio', 'Pendente', '2025-04-06 11:30:00', 2), -- Pagamento de um pedido de Daniel Gutierrez
('PIX', 'Cancelado', '2025-04-07 14:00:00', 3); -- Pagamento de um pedido de Jessica Silva

SELECT * FROM Pagamento

INSERT INTO ItemPedido (Quantidade, IdPedido, IdProduto)
VALUES
(1, 1, 4), -- Teclado Mec�nico RGB no pedido de Marcos Vinicius
(2, 2, 7), -- HD Externo no pedido de Daniel Gutierrez
(1, 3, 3); -- Notebook Gamer no pedido de Jessica Silva

SELECT * FROM ItemPedido

-- Faz um join com todas as tabelas
SELECT 
    Cliente.NomeCompleto,
    Cliente.Email,
    Pedido.IdPedido,
    Pedido.DataPedido,
    Pedido.StatusPedido,
    Pedido.ValorTotal,
    Pagamento.FormaPagamento,
    Pagamento.StatusPagamento,
    Pagamento.DataPagamento,
    Produto.NomeProduto,
    Produto.Categoria,
    Produto.Preco,
    ItemPedido.Quantidade
FROM 
    Cliente
INNER JOIN Pedido ON Cliente.IdCliente = Pedido.IdCliente
INNER JOIN Pagamento ON Pedido.IdPedido = Pagamento.IdPedido
INNER JOIN ItemPedido ON Pedido.IdPedido = ItemPedido.IdPedido
INNER JOIN Produto ON ItemPedido.IdProduto = Produto.IdProduto;

-- Excluir uma linha de cliente
DELETE FROM Cliente WHERE NomeCompleto = 'Josefina da Silva' 
SELECT * from Cliente

-- DQL - Visualizar os dados

SELECT * FROM Cliente
