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

