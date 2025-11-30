# DevTrail-BankSystem
# 🏦 Sistema Bancário DevTrail

![.NET 9](https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

Um sistema bancário desenvolvido em **.NET 8** para gerenciar clientes, contas e transações financeiras. O projeto segue boas práticas de arquitetura, separação de camadas, uso de DTOs, validação e persistência de dados com **Entity Framework Core**.

O projeto foi desenvolvido como parte do desafio **DevTrail**, utilizando uma arquitetura limpa e modular, pronta para crescimento e manutenção profissional.

---

## 📌 Sumário
- [Sobre o projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Arquitetura do projeto](#-arquitetura-do-projeto)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Como executar o projeto](#-como-executar-o-projeto)
  - [Docker (SQL Server)](#-executando-o-sql-server-via-docker)
  - [Configuração](#-configuração)
  - [Migrations](#-migrations)
- [Autor](#-autor)

---

## 📘 Sobre o projeto

O **Sistema Bancário DevTrail** tem como objetivo simular as principais operações bancárias, como criação de contas, cadastro de clientes, depósitos, saques e transferências, oferecendo uma API REST construída com práticas modernas de desenvolvimento.

A arquitetura foi planejada para ser escalável, utilizando camadas independentes (**Domain, Application, Infra e API**), garantindo um código limpo, organizado e preparado para expansão.

---

## ⚙️ Funcionalidades

### 👤 Clientes
- [x] Cadastro de cliente
- [x] Consulta de cliente por ID
- [x] Atualização de dados cadastrais
- [x] Relacionamento com contas bancárias

### 🏦 Contas
- [x] Criar conta bancária
- [x] Consultar conta específica
- [x] Listar todas as contas
- [x] Atualizar saldo (via transações)
- [x] Alterar status (Ativa/Inativa)

### 💰 Transações
- [x] Depósito
- [x] Saque (com validação de saldo)
- [x] Transferência entre contas (atômica)
- [x] Registro e histórico de transações

---

## 🧱 Arquitetura do projeto

O projeto segue uma arquitetura baseada em camadas para garantir a separação de responsabilidades:

📂 SistemaBancarioDevTrail│├── 

📂 ProjetoDevTrail.Api → Camada de apresentação (Controllers, Swagger, Mappers)
📂 ProjetoDevTrail.Application  → Serviços
📂 ProjetoDevTrail.Domain → Entidades, Enums, DTOs Interfaces de Serviço
📂 ProjetoDevTrail.Infra → Contexto (EF Core), Repositórios, Migrations

## 🛠 Tecnologias utilizadas

- **.NET 9**
- **Entity Framework Core**
- **SQL Server** (via Docker)
- **Swagger / Swashbuckle** (Documentação)
- **Injeção de Dependência** (Nativa)
- **AutoMapper** (se utilizado) & **LINQ**

---

## ▶️ Como executar o projeto

### 1. Clonar o repositório

🐳 Executando o SQL Server via DockerCaso não tenha o SQL Server instalado localmente, suba um container Docker:Bashdocker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Passw0rd" \
   -p 1433:1433 --name sqlserver-devtrail \
   -d [mcr.microsoft.com/mssql/server:2022-latest](https://mcr.microsoft.com/mssql/server:2022-latest)
   
Verifique se o container está rodando:Bashdocker ps
⚙️ ConfiguraçãoNo arquivo appsettings.json da API, configure a connection string:JSON"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=DevTrailDB;User=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
}

🛢 MigrationsGere e aplique as tabelas no banco de dados:Bash# Criar a migration
dotnet ef migrations add InitialCreate --project ProjetoDevTrail.Infra --startup-project ProjetoDevTrail.Api

# Aplicar ao banco
dotnet ef database update --project ProjetoDevTrail.Infra --startup-project ProjetoDevTrail.Api

🚀 Rodando a APINa pasta raiz do projeto, 
execute:Bashdotnet run --project ProjetoDevTrail.Api

👨‍💻 Autor
<img style="border-radius: 50%;" src="https://www.google.com/url?sa=E&source=gmail&q=https://avatars.githubusercontent.com/u/9919?s=200%26v=4" width="100px;" alt=""/><br />
Rafael Luis Caldas Vaz

🚀 Desenvolvedor | Estudante de Ciência & Tecnologia | Técnico em Desenvolvimento de Sistemas📍 Salvador – Bahia
<img width="800" height="800" alt="Image" src="https://github.com/user-attachments/assets/d1233425-7e68-4154-bec1-6a37a27a90ac" />

