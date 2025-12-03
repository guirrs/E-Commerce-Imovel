CREATE DATABASE ECommerceImovel;
GO

USE ECommerceImovel;
GO

CREATE TABLE TipoCompra
(
    TipoCompraId INT IDENTITY(1,1),
    TipoCompra VARCHAR(250) NOT NULL,
    CONSTRAINT PK_TipoCompra PRIMARY KEY (TipoCompraId)
);
GO

CREATE TABLE TipoImovel
(
    TipoImovelId INT IDENTITY(1,1),
    TipoImovel VARCHAR(250) NOT NULL,
    CONSTRAINT PK_TipoImovel PRIMARY KEY (TipoImovelId)
);
GO

CREATE TABLE Usuario
(
    UsuarioId INT IDENTITY(1,1),
    Nome VARCHAR(250) NOT NULL,
    Telefone VARCHAR(250) NOT NULL,
    Email NVARCHAR(250) UNIQUE,
    Senha VARBINARY(128) NOT NULL,
    FotoURL NVARCHAR(500),
    CriadoEM DATETIME2(0) NOT NULL DEFAULT sysutcdatetime(),
    CONSTRAINT PK_Usuario PRIMARY KEY (UsuarioId)
);
GO

CREATE TABLE Caracteristica
(
    CaracteristicaId INT IDENTITY(1,1),
    Ambiente VARCHAR(70),
    Mobiliado BIT,
    Varanda BIT,
    Churrasqueira BIT,
    Piscina BIT,
    Jardim BIT,
    QuantidadeBanheiros INT,
    QuantidadeQuartos INT,

    CONSTRAINT PK_Caracteristica PRIMARY KEY (CaracteristicaId)
);
GO

CREATE TABLE Domicilio
(
    DomicilioId INT IDENTITY(1,1),
    CaracteristicaId INT NOT NULL,
    Preco MONEY NOT NULL,
    Sobre VARCHAR(2000),
    Publicacao DATETIME2 NOT NULL DEFAULT sysutcdatetime(),
    Estado VARCHAR(70),
    Cidade VARCHAR(100),

    CONSTRAINT PK_Domicilio PRIMARY KEY (DomicilioId),
    CONSTRAINT FK_Domicilio_Caracteristica FOREIGN KEY (CaracteristicaId)
        REFERENCES Caracteristica(CaracteristicaId) ON DELETE CASCADE
);
GO

-- TABELAS RELACIONAMENTO

CREATE TABLE DomicilioTipoCompra
(
    DomicilioId INT,
    TipoCompraId INT,

    CONSTRAINT FK_DTC_Domicilio FOREIGN KEY (DomicilioId)
        REFERENCES Domicilio(DomicilioId) ON DELETE CASCADE,
    CONSTRAINT FK_DTC_TipoCompra FOREIGN KEY (TipoCompraId)
        REFERENCES TipoCompra(TipoCompraId) ON DELETE CASCADE
);
GO

CREATE TABLE DomicilioTipoImovel
(
    DomicilioId INT,
    TipoImovelId INT,

    CONSTRAINT FK_DTI_Domicilio FOREIGN KEY (DomicilioId)
        REFERENCES Domicilio(DomicilioId) ON DELETE CASCADE,
    CONSTRAINT FK_DTI_TipoImovel FOREIGN KEY (TipoImovelId)
        REFERENCES TipoImovel(TipoImovelId) ON DELETE CASCADE
);
GO

CREATE TABLE DomicilioUsuario
(
    DomicilioId INT,
    UsuarioId INT,

    CONSTRAINT FK_DU_Domicilio FOREIGN KEY (DomicilioId)
        REFERENCES Domicilio(DomicilioId) ON DELETE CASCADE,
    CONSTRAINT FK_DU_Usuario FOREIGN KEY (UsuarioId)
        REFERENCES Usuario(UsuarioId) ON DELETE CASCADE
);
GO

-- INSERTS

-- TIPO COMPRA
INSERT INTO TipoCompra (TipoCompra) VALUES
('Aluguel'),
('Terreno'),
('Compra');
GO

-- TIPO IMÓVEL
INSERT INTO TipoImovel (TipoImovel) VALUES
('Casa'),
('Apartamento'),
('Escritorio'),
('Salao'),
('Estabelecimento');
GO

-- USUÁRIOS
INSERT INTO Usuario (Nome, Telefone, Email, Senha) VALUES
('Carlos Souza', '11988887777', 'carlos@email.com', 0x1234),
('Maria Lima',  '11977776666', 'maria@email.com', 0x1234),
('João Pedro',  '11955554444', 'joao@email.com', 0x1234),
('Ana Clara',   '11922221111', 'ana@email.com', 0x1234),
('Eduardo Reis','11999998888', 'edu@email.com', 0x1234); -- este terá 2 domicílios
GO



-- CARACTERÍSTICAS

INSERT INTO Caracteristica (Ambiente, Mobiliado, Varanda, Churrasqueira, Piscina, Jardim, QuantidadeBanheiros, QuantidadeQuartos)
VALUES
('Residencial', 1, 1, 1, 0, 1, 2, 3),
('Residencial', 0, 1, 0, 1, 0, 1, 1),
('Comercial',   0, 0, 0, 0, 0, 1, 0),
('Residencial', 1, 0, 1, 1, 1, 3, 4),
('Comercial',   0, 0, 0, 0, 0, 2, 1);
GO


-- DOMICÍLIOS

INSERT INTO Domicilio (CaracteristicaId, Preco, Sobre, Estado, Cidade)
VALUES
(1, 550000, 'Casa grande com área de lazer completa.', 'SP', 'São Paulo'),
(2, 1800,    'Apartamento compacto, ideal para casal.', 'RJ', 'Rio de Janeiro'),
(3, 3500,    'Sala comercial ampla.', 'MG', 'Belo Horizonte'),
(4, 1200000, 'Casa de alto padrão com piscina.', 'SP', 'Campinas'),
(5, 9000,    'Estabelecimento comercial em avenida movimentada.', 'PR', 'Curitiba');
GO


-- RELACIONAMENTOS DOS DOMICÍLIOS

-- DomicilioTipoCompra
INSERT INTO DomicilioTipoCompra VALUES
(1, 3),  -- casa venda
(2, 1),  -- ap aluguel
(3, 3),  -- sala compra
(4, 3),  -- mansão compra
(5, 1);  -- estabelecimento para aluguel
GO

-- DomicilioTipoImovel
INSERT INTO DomicilioTipoImovel VALUES
(1, 1), -- casa
(2, 2), -- apartamento
(3, 3), -- escritório
(4, 1), -- casa alto padrão
(5, 5); -- estabelecimento
GO

-- DomicilioUsuario
INSERT INTO DomicilioUsuario VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 5), -- usuário com mais de um domicílio
(5, 5); -- segundo imóvel do mesmo usuário
GO
