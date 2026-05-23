-- CONSULTAS SQL - TORRES BARBER CLUB
-- Projeto PIM III

-- LISTAR CLIENTES
SELECT * FROM Cliente;

-- LISTAR BARBEIROS
SELECT * FROM Barbeiro;

-- LISTAR SERVIÇOS
SELECT * FROM Servico;

-- LISTAR AGENDAMENTOS COM RELACIONAMENTOS
SELECT 
    Cliente.nome AS cliente,
    Barbeiro.nome AS barbeiro,
    Servico.nome AS servico,
    Agendamento.data,
    Agendamento.horario,
    Agendamento.status
FROM Agendamento
INNER JOIN Cliente 
    ON Agendamento.id_cliente = Cliente.id_cliente
INNER JOIN Barbeiro 
    ON Agendamento.id_barbeiro = Barbeiro.id_barbeiro
INNER JOIN Servico 
    ON Agendamento.id_servico = Servico.id_servico;

-- LISTAR PAGAMENTOS
SELECT 
    Pagamento.forma_pagamento,
    Pagamento.valor,
    Pagamento.status
FROM Pagamento;

-- CONSULTA DE FATURAMENTO
SELECT 
    SUM(valor) AS faturamento_total
FROM Pagamento;

-- TOTAL DE AGENDAMENTOS
SELECT 
    COUNT(*) AS total_agendamentos
FROM Agendamento;