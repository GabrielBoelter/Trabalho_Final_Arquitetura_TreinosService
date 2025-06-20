# 🏋️ Academia - Microsserviço: TreinosService

Este repositório faz parte de um sistema de academia construído com **C# (.NET 8)**, baseado em **microsserviços**, com comunicação via **HTTP POST** e persistência em **SQLite**.

## 🎯 Propósito do Microsserviço

Gerenciar os treinos personalizados atribuídos aos alunos da academia. Cada treino está vinculado a um aluno e pode ser consultado, atualizado ou removido. O serviço também se integra ao AlunosService para validar se o aluno está ativo antes de criar treinos.

## 👥 Usuários do Sistema

- **Instrutores**: criam, atualizam e excluem treinos dos alunos.
- **Administradores**: acessam informações de treino por aluno.

---

## ✅ Requisitos Funcionais Atendidos

- RF02: Cadastrar treinos para alunos ativos.
- RF04: Consultar treinos de um aluno.
- RF06: Ao cadastrar um treino, validar via POST se o aluno está ativo.

---

## 🔁 Integrações Entre Microsserviços

| Tipo de Integração | Serviço Origem     | Serviço Destino     | Ação Realizada                                                |
|--------------------|--------------------|----------------------|----------------------------------------------------------------|
| POST (busca)       | TreinosService     | AlunosService        | Verifica se o aluno está ativo antes de cadastrar um treino    |

---

## 📦 Estrutura do Projeto

O projeto é organizado em camadas com responsabilidades bem definidas:

```
TreinosService/
├── Controllers/               # Exposição de endpoints REST
│   └── TreinoController.cs
├── DTOs/                      # Objetos de entrada/saída
│   ├── TreinoRequestDTO.cs
│   └── TreinoResponseDTO.cs
├── Models/                    # Entidade de domínio
│   └── Treino.cs
├── Repositories/              # Acesso ao banco de dados
│   ├── ITreinoRepository.cs
│   └── TreinoRepository.cs
├── Services/                  # Lógica de negócio
│   ├── ITreinoService.cs
│   └── TreinoService.cs
├── Data/                      # DbContext para SQLite
│   ├── AppDbContext.cs
│   └── AppDbContextFactory.cs
├── Migrations/                # Histórico do banco
│   ├── 20250618021916_InitialCreate.cs
│   └── AppDbContextModelSnapshot.cs
├── appsettings.json           # Configuração de conexão
├── treinos.db                 # Arquivo SQLite gerado
├── Program.cs                 # Setup do app e DI
└── TreinosService.http        # Arquivo de testes HTTP
```

---

## 🔗 Endpoints Disponíveis

| Verbo | Rota                 | Ação                                         |
|-------|----------------------|----------------------------------------------|
| POST  | `/api/treinos`       | Cria um novo treino (com validação via POST) |
| GET   | `/api/treinos`       | Lista todos os treinos                       |
| GET   | `/api/treinos/{id}`  | Busca um treino pelo ID                      |
| DELETE| `/api/treinos/{id}`  | Remove um treino                             |

---

## 💾 Banco de Dados

- Banco utilizado: **SQLite**
- Gerenciado com **Entity Framework Core**
- Migrations aplicadas via CLI ou Visual Studio

---

## 🛠️ Tecnologias Utilizadas

- **.NET 8 Web API**
- **C#**
- **Entity Framework Core**
- **SQLite**
- **Arquitetura em camadas**
- **Swagger** (documentação automática)
- **HttpClient** para integração entre microsserviços

---

## 🚀 Como Executar Localmente

1. Clone o repositório:
   ```bash
   git clone https://github.com/GabrielBoelter/Trabalho_Final_Arquitetura_TreinosService/tree/main
   ```

2. Execute a aplicação pelo **Visual Studio 2022**.

3. Acesse a interface Swagger via:
   ```
   https://localhost:xxxx/swagger
   ```

---

## 📂 Repositórios Relacionados

- [`academia-alunos-service`](https://github.com/GabrielBoelter/Trabalho_Final_Arquitetura_AlunosService)
- [`academia-pagamentos-service`](https://github.com/GabrielBoelter/Trabalho_Final_Arquitetura_PagamentosService)

---

## 👨‍🏫 Projeto acadêmico para a disciplina de Arquitetura de Software  
**Centro Universitário SATC** – Prof. Eduardo Cizeski Meneghel  
