# MeetingRoomScheduler

Este é um projeto de API RESTful desenvolvido em .NET para gerenciar reservas de salas de reunião. A API permite o cadastro de usuários, salas e reservas, garantindo validação de conflitos de horários e listagem com filtros.

## Tecnologias Utilizadas

- .NET 8
- PostgreSQL
- Entity Framework Core
- Swagger para documentação da API
- Autenticação via JWT

## Estrutura do Projeto

```
📦 MeetingRoomScheduler
 ┣ 📂 MeetingRoomScheduler.API          # API principal
 ┣ 📂 MeetingRoomScheduler.Application  # Regras de negócio
 ┣ 📂 MeetingRoomScheduler.Domain       # Entidades e contratos
 ┣ 📂 MeetingRoomScheduler.Infrastructure  # Persistência e serviços externos
 ┣ 📂 MeetingRoomScheduler.Middlewares  # Middlewares personalizados
 ┣ 📂 MeetingRoomScheduler.Util         # Utilitários gerais (por enquanto tem as mensagens utilizadas no codigo)
 ┣ 📄 README.md                         # Documentação do projeto
 ┗ 📄 MeetingRoomScheduler.sln          # Solução do projeto
```

## Configuração do Banco de Dados

Para configurar o PostgreSQL, siga os passos abaixo:

1. Crie um banco de dados no PostgreSQL.
2. Configure a **connection string** no `appsettings.json` da API:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=meetingroomscheduler;Username=seu_usuario;Password=sua_senha"
   }
   ```
3. Aplique as migrations do Entity Framework:
   ```sh
   dotnet ef database update
   ```

## Como Executar a API

1. Clone o repositório:
   ```sh
   git clone https://github.com/seuusuario/MeetingRoomScheduler.git
   ```
2. Acesse o diretório do projeto:
   ```sh
   cd MeetingRoomScheduler
   ```
3. Restaure os pacotes:
   ```sh
   dotnet restore
   ```
4. Compile e execute o projeto:
   ```sh
   dotnet run --project MeetingRoomScheduler.API
   ```

A API estará disponível em `http://localhost:5000`

## Autenticação e Segurança

A API utiliza autenticação JWT. Para acessar os endpoints protegidos, obtenha um token realizando login e envie-o no header `Authorization` das requisições:

```
Authorization: Bearer <seu_token>
```

## Documentação da API

A documentação via Swagger estará disponível em:

- `http://localhost:5000/swagger`

