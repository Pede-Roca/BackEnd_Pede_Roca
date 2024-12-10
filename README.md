# BackEnd_Pede_Roca

# Documentação da Arquitetura BackEnd_Pede_Roca

## Introdução

Este documento descreve a arquitetura do backend do projeto Pede Roça, detalhando as camadas e os principais padrões de design utilizados, com foco na Clean Architecture. O objetivo é fornecer uma visão clara e completa sobre a organização do projeto, as responsabilidades de cada camada e como os padrões de design suportam a lógica de negócio e a escalabilidade da aplicação.

## Camadas da Arquitetura

### Domain

A camada de Domain é responsável por encapsular a lógica central do sistema. Ela contém as entidades de domínio, interfaces e regras de negócio.

- **Entidades de Domínio**: Representam os objetos principais do sistema e suas propriedades.
- **Interfaces**: Definem contratos que as outras camadas devem seguir.
- **Regras de Negócio**: Contêm a lógica que rege o comportamento das entidades.

### Application

A camada de Application implementa os casos de uso e serviços de aplicação, interagindo com a camada Domain para implementar a lógica de negócios.

- **Casos de Uso**: Representam as operações que podem ser realizadas no sistema.
- **Serviços de Aplicação**: Coordenam a execução dos casos de uso.
- **DTOs (Data Transfer Objects)**: Utilizados para transferir dados entre a Application e a API.
- **Mediators**: Orquestram as interações entre serviços.

### Infra.Data

A camada de Infra.Data gerencia a persistência dos dados, utilizando o Entity Framework e configurando o banco de dados (Azure SQL Server).

- **Entity Framework**: ORM utilizado para interagir com o banco de dados.
- **Repositórios**: Implementam o acesso aos dados de forma abstrata, mantendo a lógica de acesso ao banco de dados desacoplada.

### Infra.IoC

A camada de Infra.IoC configura a Inversão de Controle (IoC), injetando as dependências no sistema.

- **Dependency Injection**: Mantém a modularidade e a testabilidade do sistema.
- **Configuração de Serviços**: Registra os serviços e repositórios no contêiner de DI.

### API

A camada de API expõe os endpoints para os consumidores externos, organizando e implementando Controllers, Swagger Configuration e Middlewares.

- **Controllers**: Gerenciam as requisições HTTP e chamam os serviços de aplicação.
- **Swagger Configuration**: Documenta os endpoints da API.
- **Middlewares**: Interceptam e processam as requisições HTTP.

## Padrões de Design

### Clean Architecture

A Clean Architecture promove a separação de responsabilidades e a independência entre as camadas, facilitando a manutenção e a escalabilidade do sistema.

### Dependency Injection

O padrão de Dependency Injection é utilizado para injetar dependências no sistema, mantendo a modularidade e a testabilidade.

### Repository Pattern

O Repository Pattern é implementado para acessar dados de forma abstrata, mantendo a lógica de acesso ao banco de dados desacoplada.

### DTOs (Data Transfer Objects)

Os DTOs são utilizados para transferir dados entre a Application e a API, garantindo a segurança e o encapsulamento.

### Mediator Pattern

O Mediator Pattern auxilia na orquestração de interações entre serviços, simplificando o código e mantendo a lógica centralizada.

# Documentação dos Modelos de Dados

## Produto

### Atributos:
- **id** (Guid, PK) – Identificador único do produto.
- **nome** (string) – Nome do produto.
- **descricao** (string) – Descrição detalhada do produto.
- **preco** (decimal) – Preço do produto.
- **idCategoria** (Guid, FK) – Relacionamento com a tabela de categorias.
- **status** (bool) – Status do produto (disponível, indisponível, etc.).
- **estoque** (int) – Quantidade disponível no estoque.
- **idUnidade** (Guid, FK) – Relacionamento com a tabela de unidades de medida.
- **ativo** (bool) – Indica se o produto está ativo ou inativo.
- **fatorPromocao** (decimal) – Fator de desconto aplicado ao preço, se houver.
- **uidFotoProduto** (string) – Identificador da foto associada ao produto.

### Relacionamentos:
- Produto está relacionado a Categoria e Unidade através de chaves estrangeiras.

## Carrinho

### Atributos:
- **id** (Guid, PK) – Identificador único do carrinho.
- **idUsuario** (Guid, FK) – Relacionamento com a tabela de usuários.
- **status** (bool) – Status do carrinho (ativo, inativo).
- **data** (DateTime) – Data de criação do carrinho.

### Relacionamentos:
- Carrinho está relacionado a Produto e Usuário. Cada carrinho pode ter vários itens de produto, e cada item do carrinho está vinculado a um produto específico.

## Pedido

### Atributos:
- **id** (Guid, PK) – Identificador único do pedido.
- **idUsuario** (Guid, FK) – Relacionamento com a tabela de usuários.
- **data** (DateTime) – Data de criação do pedido.
- **status** (string) – Status do pedido (pendente, concluído, etc.).
- **tipoEntrega** (string) – Tipo de entrega do pedido.
- **tipoPagamento** (string) – Tipo de pagamento do pedido.

### Relacionamentos:
- Pedido está relacionado a Usuário e Produto, e cada pedido pode ter múltiplos itens associados, refletindo os produtos adquiridos.

## Plano de Assinatura

### Atributos:
- **id** (Guid, PK) – Identificador único do plano de assinatura.
- **idUsuario** (Guid, FK) – Relacionamento com a tabela de usuários.
- **preco** (decimal) – Preço do plano de assinatura.
- **ativo** (bool) – Indica se o plano de assinatura está ativo ou inativo.

### Relacionamentos:
- Plano de Assinatura está relacionado a Usuário, e um usuário pode ter um ou mais planos de assinatura ativos.

## Diagrama ER (Entidades e Relacionamentos)

![Imagem do WhatsApp de 2024-12-10 à(s) 16 52 54_fe1e9b62](https://github.com/user-attachments/assets/6b34414b-28e7-40b8-8c2e-62c672af8221)

### Estrutura do Diagrama ER:
- **Produto** (relacionamento com Categoria, Unidade)
- **Carrinho** (relacionamento com Usuário, Itens do Carrinho)
- **Pedido** (relacionamento com Usuário, Itens de Pedido)
- **Plano de Assinatura** (relacionamento com Usuário)

### Detalhamento dos Relacionamentos:
- Relacionamentos de 1 para muitos (por exemplo, um Usuário pode ter vários Carrinhos ou Pedidos).
- Relacionamentos de muitos para muitos (se houver, como entre Carrinho e Produto através de Itens do Carrinho).
- Detalhamento de chaves primárias (PK) e estrangeiras (FK) para cada relacionamento.

# Documentação dos Endpoints da API

## Produto - Listar Todos os Produtos

### Método HTTP: GET
### URI: /api/produtos

### Parâmetros:
- Nenhum parâmetro obrigatório.

### Exemplo de Requisição:
  http
GET /api/produtos HTTP/1.1
Host: api.exemplo.com

### Exemplo Resposta:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 38 30_636be19b](https://github.com/user-attachments/assets/3f12ce7e-beaa-46e1-a4c0-c4d13a8aaf5d)

## Status Codes:
- **200 OK** – Se a requisição for bem-sucedida.
- **500 Internal Server Error** – Se ocorrer um erro no servidor.

## Produto - Adicionar Novo Produto
### Método HTTP: POST
### URI: /api/produtos

### Parâmetros:
- **Body**:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 40 50_01483d91](https://github.com/user-attachments/assets/7c12b1f9-3fb9-4ed5-bd62-f69ef584427d)

### Exemplo Requisição:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 41 33_a8734d48](https://github.com/user-attachments/assets/6531a273-8e8a-437a-ba6e-d54dd6b441a6)

### Exemplo Resposta:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 42 06_b74dbcb1](https://github.com/user-attachments/assets/54badf4f-c3b2-47fe-b1a8-8f39daf6bb8a)

## Status Codes:
- **201 Created** – Se o produto for criado com sucesso.
- **400 Bad Request** – Se a requisição contiver dados inválidos.
- **500 Internal Server Error** – Se ocorrer um erro no servidor.

## Produto - Atualizar Produto
### Método HTTP: PUT
### URI: /api/produtos/{id}

### Parâmetros:
- **Path**:
  - id (Guid) – Identificador único do produto.

- **Body**:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 43 00_125ea5c7](https://github.com/user-attachments/assets/e962ae02-7dad-4f1d-8393-63aefab26299)

### Exemplo Requisição:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 43 48_4d137f25](https://github.com/user-attachments/assets/d822aed4-8f53-47b4-b48a-a556c19b2b3b)

### Exemplo Resposta:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 44 34_58aed1a9](https://github.com/user-attachments/assets/1bf0a13a-1e83-42c0-b35e-4cb9046fb964)

## Status Codes:
- **200 OK** – Se o produto for atualizado com sucesso.
- **400 Bad Request** – Se a requisição contiver dados inválidos.
- **404 Not Found** – Se o produto não for encontrado.
- **500 Internal Server Error** – Se ocorrer um erro no servidor.

## Produto - Deletar Produto
### Método HTTP: DELETE
### URI: /api/produtos/{id}

### Parâmetros:
- **Path**:
  - id (Guid) – Identificador único do produto.

### Exemplo de Requisição:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 45 13_cff0c6bc](https://github.com/user-attachments/assets/7e45052d-aad1-4e15-991e-49fdcd57c36e)

### Exemplo Resposta:
![Imagem do WhatsApp de 2024-12-10 à(s) 18 45 38_6512f86e](https://github.com/user-attachments/assets/da72d500-ca59-48b9-b993-5cd8d4330900)

## Status Codes:
- **200 OK** – Se o produto for deletado com sucesso.
- **404 Not Found** – Se o produto não for encontrado.
- **500 Internal Server Error** – Se ocorrer um erro no servidor.
