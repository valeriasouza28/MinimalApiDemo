# MinimalApiDemo

Uma aplicação Minimal API desenvolvida em C# com .NET 8.0, que utiliza banco de dados MySQL e autenticação JWT. A aplicação também conta com testes unitários utilizando MSTest.

## Tecnologias Utilizadas

    - .NET 8.0
    - Minimal API
    - MySQL
    - JWT (JSON Web Token)
    - MSTest (para testes unitários)

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

    - .NET 8.0 SDK
    - MySQL
    - Docker (opcional, caso deseje rodar o MySQL em um contêiner)
    - Um editor de código como Visual Studio Code ou Visual Studio

## Configuração do Projeto
### Passo 1: Clonar o repositório

```bash

git clone https://github.com/usuario/MinimalApiDemo.git
cd MinimalApiDemo
```

### Passo 2: Configuração do Banco de Dados MySQL

Configure o MySQL localmente ou em um contêiner Docker. Exemplo de um contêiner Docker com MySQL:

```bash

docker run --name mysql-container -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=minimalapi -p 3306:3306 -d mysql:8.0
```

### Passo 3: Configurar appsettings.json

No arquivo appsettings.json, configure a string de conexão do MySQL:

```json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=minimalapi;User=root;Password=root;"
  },
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "your-app",
    "Audience": "your-app-users",
    "ExpiresInMinutes": 60
  }
}
```

    Substitua your-secret-key por uma chave segura para assinar os tokens JWT.
    Ajuste as configurações de banco de dados conforme necessário.

### Passo 4: Executar Migrações

Execute as migrações para configurar o banco de dados:

```bash

dotnet ef database update
```

### Passo 5: Executar a Aplicação

Agora, você pode rodar a aplicação:

```bash

dotnet run
```

A aplicação estará disponível em: https://localhost:5001 ou http://localhost:5000.

## Autenticação JWT

A aplicação utiliza autenticação baseada em JWT. Para gerar um token, utilize o endpoint /administradores/login com um administrador cadastrado.

Exemplo de requisição:

```json

POST /administradores/login
{
  "email": "admin@example.com",
  "senha": "adminpassword"
}
```

Após a autenticação, você receberá um token JWT que deve ser utilizado no cabeçalho Authorization para acessar endpoints protegidos:

```makefile

Authorization: Bearer <seu-token-jwt>
```

## Testes Unitários com MSTest

A aplicação inclui testes unitários utilizando MSTest. Para rodar os testes:

```bash

dotnet test
```

Os testes estão localizados no projeto de testes na solution. Eles garantem que os principais métodos do serviço funcionem corretamente.

## Rotas Disponíveis
Administradores

    POST /administradores/login - Login de administradores (gera JWT)
    GET /administradores - Listar administradores (requer token JWT)
    GET /administradores/{id} - Buscar administrador por ID (requer token JWT)
    POST /administradores - Criar novo administrador (requer token JWT)

Veículos

    POST /veiculos - Criar novo veículo (requer token JWT com permissão de Admin/Editor)
    GET /veiculos - Listar todos os veículos (requer token JWT)
    GET /veiculos/{id} - Buscar veículo por ID (requer token JWT)
    PUT /veiculos/{id} - Atualizar veículo (requer token JWT com permissão de Admin)
    DELETE /veiculos/{id} - Deletar veículo (requer token JWT com permissão de Admin)

## Swagger

A aplicação inclui documentação interativa utilizando Swagger. Para acessar a documentação:

    Acesse: https://localhost:5001/swagger ou http://localhost:5000/swagger
