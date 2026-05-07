# IveComeToBook API
Sistema robusto focado na gestão de venda e aluguel de livros, desenvolvido com práticas de excelência em engenharia de software no ecossistema .NET 8. O projeto prioriza uma arquitetura desacoplada, segura, de alta performance e preparada para o mercado global.

## Arquitetura e Padrões (Clean Architecture & DDD)
O projeto é estruturado sob os pilares do Domain-Driven Design (DDD) e da Clean Architecture, garantindo que a lógica de negócio seja independente de frameworks e bancos de dados:

Domain: O núcleo do sistema, contendo Entidades puras (User) e uma classe base (EntityBase) para padronização de IDs e auditoria.

Application: Orquestração de serviços e lógica de mapeamento, organizada via Extension Methods para manter o Program.cs limpo e modular.

Infrastructure (Implementação SOLID): Camada de persistência que aplica Interface Segregation (ISP) e Dependency Inversion (DIP).

Suporte Multi-DB: Interfaces intermediárias que permitem a comunicação transparente com SQL Server, PostgreSQL e MySQL, facilitando trocas de infraestrutura sem impacto no core.

API: Gerenciamento de comunicação HTTP, filtros globais e inicialização.
## Persistência de Dados e Multi-DB
Uma das principais evoluções do projeto foi a transição para uma infraestrutura de dados de alto desempenho:

Dapper (Micro-ORM): Substituição estratégica do Entity Framework pelo Dapper, visando performance bruta, controle total sobre o dialeto SQL e redução do overhead de memória.

Suporte Multi-DB Nativo: Interfaces que permitem a comunicação transparente com SQL Server, PostgreSQL e MySQL.

Auto-Bootstrap de Infraestrutura: Implementação de uma lógica de migração personalizada (DatabaseMigration) que identifica o provedor de banco de dados no startup, verifica a existência da base e garante a integridade do schema automaticamente, ideal para ambientes de containers (Docker).
## Camadas Transversais (Shared)
Communication: Camada dedicada exclusivamente aos contratos da API (Requests/Responses), garantindo que mudanças internas não quebrem a integração com o cliente externo.
Communication & Validation: Camada dedicada aos contratos da API (Requests/Responses). Utiliza FluentValidation para implementar uma camada de defesa robusta, garantindo que apenas dados válidos avancem para o processamento de negócio, com mensagens de erro padronizadas e internacionalizadas.

Exceptions & i18n: Centralização de erros com suporte nativo a múltiplos idiomas (Português, Inglês, Espanhol e Francês) via arquivos de recurso (.resx).

## Decisões Técnicas de Engenharia
Mapeamento com Mapster: Escolhido pela alta performance e conformidade com licenciamento MIT.

Segurança: Configuração rigorosa de mapeamento para proteção de credenciais e uso de Fluent Validation para integridade de dados.

Tratamento Global de Erros: Implementação de ExceptionFilter para padronização de respostas e mascaramento de StackTrace em produção.

Engenharia de Software: Uso de Conventional Commits e fluxos de Pull Request para garantir um histórico de código limpo e revisado.

## Propósito do Projeto
Este projeto reflete minha maturidade de mais de 5 anos no mercado de tecnologia. Ao vivenciar sistemas onde a dívida técnica gerava atrasos críticos, projetei o IveComeToBook para ser o oposto: um software onde o SOLID, o DDD e o uso consciente de Micro-ORMs tornam a manutenção ágil, o sistema altamente escalável e o negócio seguro.

## Autor
Mateus Silva - Desenvolvedor Backend .NET
