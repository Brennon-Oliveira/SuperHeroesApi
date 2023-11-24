# Documentação da API SuperHeroes

## Arquitetura

A arquitetura da API foi projetada para ser simples de compreender, mas robusta o suficiente para suportar o crescimento do sistema. Utilizamos o padrão Domain-Driven Design (DDD) para garantir que as responsabilidades de cada projeto sejam respeitadas.

A estrutura do projeto é dividida em quatro partes principais:

1. **Controllers**: Responsáveis por expor as rotas da API e redirecionar as requisições para a camada de Application.

2. **Application**: Aqui estão os services, que são responsáveis por operações de consulta e por chamar os actions que estão no projeto Domain.

3. **Domain**: Aqui estão os actions que farão alterações no banco de dados.

4. **Infra.Data**: Aqui, os repositórios e controle do banco de dados são feitos, é para onde o domain redireciona as requests de banco, tal qual o Application

A injeção de dependências é utilizada para a chamada dos services, garantindo um baixo acoplamento e uma maior facilidade para realizar testes unitários.

## Testes

Implementamos um conjunto básico de testes para demonstrar como eles funcionariam na prática. A ideia é expandir essa base de testes à medida que o sistema cresce e novas funcionalidades são adicionadas.

## Escalabilidade

A arquitetura foi pensada para extrair o melhor do MVC (a separação de camadas de apresentação, serviços e modelos), mas com uma abordagem que permite a escalabilidade. Isso significa que podemos adicionar vários projetos de exportação de rotas e interfaces, como GraphQL, outras APIs, etc., sem alterar o core do sistema. Da mesma forma, podemos adicionar novos domínios conforme necessário.

## Banco de Dados

O projeto foi desenvolvido utilizando SQLite para simplificar o processo de configuração, eliminando a necessidade de um servidor para subir o projeto. No entanto, graças à inversão de dependências, o sistema pode ser facilmente alterado para usar outro banco de dados, como PostgreSQL, MySQL, etc.