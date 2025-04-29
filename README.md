🚗 Locadora de Carros - API RESTful
Esta aplicação é uma API para gerenciamento de uma locadora de carros, desenvolvida com ASP.NET Core 8.0, aplicando os conceitos de DDD, CQRS, MediatR, FluentValidation, Entity Framework Core, IdentityServer4 (Client Credentials) e banco de dados PostgreSQL.

📚 Tecnologias utilizadas
ASP.NET Core 8.0

Entity Framework Core

PostgreSQL

FluentValidation

MediatR

IdentityServer4 (Client Credentials Flow)

Swagger (OpenAPI)

AutoMapper

SOLID & Clean Code Principles

📦 Funcionalidades da API
Cadastro de Carros

Listagem de Carros disponíveis e não disponíveis

Aluguel de Carros

Devolução de Carros alugados com aplicação de taxas de atraso

Gestão de Aluguéis

⚙️ Como executar o projeto
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seu-usuario/locadora-de-carros.git
Navegue até a pasta do projeto:

bash
Copiar
Editar
cd locadora-de-carros
Configure o banco de dados PostgreSQL:

Crie um banco de dados chamado LocadoraDb.

Atualize a connection string no Utils.cs

Execute as migrations (opcional, caso já tenha migrations):

bash
Copiar
Editar
dotnet ef database update
Execute o projeto:

bash
Copiar
Editar
dotnet run --project LocadoraDeCarro.API
Acesse o Swagger UI:

bash
Copiar
Editar
https://localhost:5001/swagger

🔐 Autenticação
O projeto utiliza IdentityServer4 para proteção da API usando o fluxo Client Credentials.

Para acessar os endpoints protegidos:

Obtenha um token em /connect/token.

Utilize o token no Bearer Authorization no Swagger ou nas chamadas.

Client Id / Secret para testes:


ClientId	ClientSecret	Scope
locadora_client	super_senha	locadora_api
🛠️ Principais pacotes NuGet usados
Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.Npgsql

MediatR

FluentValidation

FluentValidation.DependencyInjectionExtensions

IdentityServer4

Swashbuckle.AspNetCore

AutoMapper.Extensions.Microsoft.DependencyInjection

👨‍💻 Autor
Lucas Freitas dos Santos

✨
Feito com dedicação e boas práticas de arquitetura para APIs modernas em .NET!



