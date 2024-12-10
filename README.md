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

# Guia de Configuração do Ambiente de Desenvolvimento Back-End

## Objetivo

Fornecer um guia completo para configurar o ambiente de desenvolvimento Back-End, com ênfase na instalação das dependências, execução de migrations e configuração do banco de dados Azure SQL Server. Também será fornecido um conjunto de variáveis de ambiente e instruções de configuração necessárias para o funcionamento adequado do sistema.

## Passo a Passo para Configuração do Ambiente de Desenvolvimento

### 1. Instalação de Dependências

#### Pré-requisitos:

- **.NET SDK**: Certifique-se de que o SDK do .NET (versão recomendada para o projeto) esteja instalado. Caso contrário, faça o download e instale a versão mais recente do site oficial.
- **Editor de Código**: Utilize um editor de código como Visual Studio ou Visual Studio Code com as extensões necessárias para .NET e C#.
- **Ferramentas de CLI**: O CLI do .NET é necessário para executar comandos de build, migrations e testes.

#### Instruções:

 **Clone o Repositório**: Se ainda não fez isso, clone o repositório do projeto:
     bash
   git clone <url-do-repositorio>
   cd <diretorio-do-projeto>

 **Abrir e aguardar instalação de dependências**

## 2. Configuração do Banco de Dados Azure SQL Server

### Pré-requisitos:
- **Conta no Azure**: É necessário ter uma conta no Azure e um banco de dados SQL Server configurado.
- **Azure SQL Server**: Crie um banco de dados SQL Server no portal do Azure, caso ainda não tenha feito.

### Instruções:

#### Criação do Banco de Dados no Azure:
- Acesse o Portal do Azure.
- Crie um novo recurso do tipo SQL Database e siga as etapas para configurar o banco de dados.
- Anote as informações de conexão: Servidor, Banco de Dados, Usuário e Senha.

#### Configuração da String de Conexão:
No arquivo `appsettings.json` (ou `appsettings.Development.json` para ambientes de desenvolvimento), configure a string de conexão para o banco de dados Azure SQL Server:
![Imagem do WhatsApp de 2024-12-10 à(s) 19 03 54_bdb246aa](https://github.com/user-attachments/assets/bed89386-694a-4b12-82a7-f4ac12ab0f7f)

## 3. Execução de Migrations

### Pré-requisitos:
- **Migrations do Entity Framework**: As migrations do EF Core são usadas para criar e atualizar a estrutura do banco de dados a partir das entidades do código.

### Instruções:
- **Criar Migrations (se necessário)**: Caso você esteja criando ou modificando o modelo de dados.
- **Aplicar Migrations ao Banco de Dados**: Para aplicar as migrations ao banco de dados configurado (Azure SQL Server).
- **Verificar a Estrutura do Banco**: Após a execução do comando, verifique no portal do Azure ou utilizando uma ferramenta de gerenciamento SQL como Azure Data Studio se as tabelas foram criadas corretamente.

## 4. Variáveis de Ambiente Específicas do Back-End

As variáveis de ambiente são importantes para configurar comportamentos específicos do ambiente de desenvolvimento, como a configuração de banco de dados, chaves de API e outros parâmetros sensíveis. Para configurar variáveis de ambiente no projeto, siga os passos abaixo:

### Criação de Variáveis de Ambiente (para ambientes locais):
Para ambientes locais, crie um arquivo chamado `.env` na raiz do projeto com as variáveis necessárias.

### Configuração de Variáveis de Ambiente no Azure:
No portal do Azure, vá até o recurso de Configuração do seu aplicativo e adicione as variáveis de ambiente necessárias para produção ou outros ambientes.

### Referência no Código:
No código, utilize as variáveis de ambiente para acessar os valores configurados.

# Documentação dos Testes

## Objetivo

Documentar os testes implementados na camada de domínio, integração e API, incluindo testes unitários, de serviços e de API (usando xUnit). Também incluir instruções sobre como executar os testes e os critérios de sucesso para garantir a qualidade do código.

## Tipos de Testes Implementados

Os testes são fundamentais para garantir a qualidade do código, identificar regressões e validar a lógica do sistema. No projeto, temos três principais tipos de testes implementados:

### 1. Testes Unitários

#### Objetivo
Validar o comportamento de unidades específicas de código, como métodos de serviço ou lógica de negócios, de forma isolada, sem depender de outras partes do sistema, como banco de dados ou APIs externas.

#### Ferramenta Utilizada
xUnit é a framework de testes unitários utilizada.

#### Exemplo de Teste Unitário (para a camada de domínio)
![Imagem do WhatsApp de 2024-12-10 à(s) 19 30 02_f569e5c8](https://github.com/user-attachments/assets/fb9def25-cb92-406f-8455-2ede491e4d63)

### Explicação
O exemplo acima testa a criação de um objeto Produto e verifica se o nome do produto foi corretamente atribuído.

## 2. Testes de Integração

### Objetivo
Validar a interação entre diferentes partes do sistema, como a comunicação entre a aplicação e o banco de dados, garantindo que os componentes funcionem corretamente em conjunto.

### Ferramenta Utilizada
xUnit é a framework de testes de integração utilizada.

### Exemplo de Teste de Integração
![Imagem do WhatsApp de 2024-12-10 à(s) 19 30 37_61a0bb57](https://github.com/user-attachments/assets/6cf69d41-836a-4b66-8e12-558b828a3e74)

## 3. Testes de API

### Objetivo
Validar os endpoints da API, garantindo que as requisições e respostas estejam corretas e que a API funcione conforme esperado.

### Ferramenta Utilizada
xUnit é a framework de testes de API utilizada.

### Exemplo de Teste de API
![Imagem do WhatsApp de 2024-12-10 à(s) 19 31 38_a2446f46](https://github.com/user-attachments/assets/21d57e14-9be5-4e7a-8db5-17780435149f)

## Instruções para Executar os Testes

### Instalar Dependências
Certifique-se de que todas as dependências do projeto estão instaladas.
![Imagem do WhatsApp de 2024-12-10 à(s) 19 32 06_17db60b4](https://github.com/user-attachments/assets/6fe04a0d-afd4-4920-9471-70e4250e63e3)

## Executar Testes
Utilize o comando abaixo para executar todos os testes.
![Imagem do WhatsApp de 2024-12-10 à(s) 19 32 33_d7ced6bb](https://github.com/user-attachments/assets/d708ab9b-1677-4612-9daf-869791352343)

## Critérios de Sucesso para Garantir Qualidade do Código

Os testes devem ser executados com sucesso em todas as condições abaixo para garantir a qualidade do código:

- **100% de cobertura dos testes unitários**: Todos os métodos e funcionalidades principais devem ser cobertos por testes unitários.
- **Testes devem ser rápidos e independentes**: Os testes de unidade e integração devem ser rápidos e não depender uns dos outros para garantir que possam ser executados isoladamente.

## Manutenção de Testes

Manter a qualidade dos testes é crucial para a estabilidade do sistema:

- **Adicionar testes conforme novas funcionalidades são implementadas**: Sempre que uma nova funcionalidade ou alteração significativa for feita, os testes correspondentes devem ser criados ou atualizados.
- **Refatorar testes conforme a evolução do código**: Caso a lógica de negócios ou a estrutura do código seja alterada, os testes devem ser ajustados para refletir essas mudanças.
- **Monitoramento contínuo**: Utilize ferramentas de integração contínua (CI) como GitHub Actions e Azure Pipelines para garantir que os testes sejam executados automaticamente em todas as branches e pull requests.
