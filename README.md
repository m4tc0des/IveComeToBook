# IveComeToBook API

Sistema focado na gestão de venda e aluguel de livros, desenvolvido com práticas modernas de engenharia de software no ecossistema **.NET 8**. O projeto prioriza uma arquitetura desacoplada, segura e de alta performance.

---

## Funcionalidades e Implementações Atuais

### Domínio Base
* **EntityBase:** Estruturação de uma classe base para padronização de identificadores (IDs) e propriedades de auditoria.
* **User Entity:** Implementação da entidade central de usuários, servindo como base para autenticação e perfis no sistema.

### Tratamento Global de Erros
* **ExceptionFilter:** Implementação de um filtro customizado para captura de exceções em toda a API.
* **Segurança:** Garante que erros internos críticos não exponham detalhes sensíveis (StackTrace) ao cliente.
* **Padronização:** Respostas de erro consistentes e amigáveis para o consumo do front-end.

### Mapeamento de Objetos com Mapster
* **Conversão Inteligente:** Uso do Mapster para transformar DTOs (Requests) em Entidades de Domínio de forma eficiente.
* **Decisão Técnica:** Substituição estratégica do *AutoMapper* para evitar vulnerabilidades de segurança presentes em versões legadas gratuitas e garantir conformidade com licenciamento MIT.
* **Segurança de Dados:** Configuração específica para **ignorar o campo Password** durante o mapeamento automático, forçando o tratamento seguro e manual de credenciais.

### Arquitetura e Injeção de Dependência (DI)
* **Extension Methods:** Organização da injeção de dependência da camada de *Application* via métodos de extensão.
* **Clean Program.cs:** O arquivo de inicialização da API permanece limpo, delegando as configurações internas para suas respectivas camadas.

---

## Arquitetura Implementada

O projeto segue os princípios da **Clean Architecture**, dividindo responsabilidades para facilitar a manutenção:

* **Domain:** Entidades de negócio puras (`User`, `EntityBase`).
* **Application:** Regras de mapeamento e lógica de injeção de serviços.
* **API:** Gerenciamento de comunicação HTTP, filtros globais e inicialização.

---

## 👨‍💻 Autor

**Mateus Silva Santos** *Desenvolvedor Backend .NET*
