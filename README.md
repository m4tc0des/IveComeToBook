# IveComeToBook API
Sistema robusto focado na gestão de venda e aluguel de livros, desenvolvido com práticas de excelência em engenharia de software no ecossistema .NET 8. O projeto prioriza uma arquitetura desacoplada, segura, de alta performance e preparada para o mercado global.

## Arquitetura e Padrões (Clean Architecture & DDD)
O projeto é estruturado sob os pilares do Domain-Driven Design (DDD) e da Clean Architecture, garantindo que a lógica de negócio seja independente de frameworks e bancos de dados:

Domain: O núcleo do sistema, contendo Entidades puras (User) e uma classe base (EntityBase) para padronização de IDs e auditoria.

Application: Orquestração de serviços e lógica de mapeamento, organizada via Extension Methods para manter o Program.cs limpo e modular.

Infrastructure (Implementação SOLID): Camada de persistência que aplica Interface Segregation (ISP) e Dependency Inversion (DIP).

Suporte Multi-DB: Interfaces intermediárias que permitem a comunicação transparente com SQL Server, PostgreSQL e MySQL, facilitando trocas de infraestrutura sem impacto no core.

API: Gerenciamento de comunicação HTTP, filtros globais e inicialização.

## Camadas Transversais (Shared)
Communication: Camada dedicada exclusivamente aos contratos da API (Requests/Responses), garantindo que mudanças internas não quebrem a integração com o cliente externo.

Exceptions & i18n: Centralização de erros com suporte nativo a múltiplos idiomas (Português, Inglês, Espanhol e Francês) via arquivos de recurso (.resx).

## Decisões Técnicas de Engenharia
Mapeamento com Mapster: Substituição estratégica do AutoMapper visando performance e conformidade com licenciamento MIT.

Segurança de Dados: Configuração para ignorar o campo Password no mapeamento automático, forçando o tratamento manual e seguro de credenciais.

Tratamento Global de Erros: Implementação de ExceptionFilter para capturar exceções, mascarar o StackTrace em produção e padronizar as respostas para o front-end.

Validação Robusta: Uso de Fluent Validation para garantir a integridade dos dados antes que cheguem ao domínio.

## Propósito do Projeto
Este projeto reflete minha maturidade de mais de 5 anos no suporte técnico avançado. Ao vivenciar sistemas onde falhas na organização geravam atrasos de semanas em correções simples, projetei o IveComeToBook para ser o oposto: um software onde o SOLID e o DDD tornam a manutenção ágil, testável e segura para o negócio.

## Autor
Mateus Silva - Desenvolvedor Backend .NET
