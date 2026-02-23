# ToDoAPI

Uma API RESTful para gerenciamento de tarefas e notas, desenvolvida com ASP.NET Core e Entity Framework Core, utilizando Oracle como banco de dados.

## 📋 Descrição

A ToDoAPI fornece endpoints para criar, ler, atualizar e deletar notas/tarefas. Cada nota conta com funcionalidades como:
- Título e descrição
- Prioridade e categoria
- Status de conclusão
- Timestamps de criação e atualização
- Identificador único (GUID)

## 🛠️ Tecnologias

- **Framework**: ASP.NET Core 6+ (C#)
- **ORM**: Entity Framework Core
- **Banco de Dados**: Oracle Database
- **Documentação API**: Swagger/OpenAPI
- **Padrão**: REST

## 📦 Requisitos

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [Oracle Database](https://www.oracle.com/database/) ou Oracle Express Edition
- Visual Studio 2022 ou VS Code

## 🚀 Instalação e Configuração

### 1. Clone o repositório
```bash
git clone https://github.com/JeanCampos1604/ToDoAPI.git
cd ToDoAPI
```

### 2. Configure o banco de dados Oracle

Execute o script SQL para criar as tabelas:
```sql
-- Execute o arquivo: Database/create.sql
```

### 3. Configure a string de conexão

Edite `appsettings.json` com suas credenciais do Oracle:
```json
{
  "ConnectionStrings": {
    "OracleConnection": "User Id=TODOUSER;Password=bdtodouser;Data Source=localhost:1522/XEPDB1;"
  }
}
```

### 4. Restaure as dependências
```bash
dotnet restore
```

### 5. Execute a aplicação
```bash
dotnet run
```

A API estará disponível em `https://localhost:7000` (ou a porta configurada)

## 📚 Endpoints

### Notas

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| **GET** | `/todo/all` | Retorna todas as notas |
| **GET** | `/todo/{id}` | Retorna uma nota por ID |
| **POST** | `/todo` | Cria uma nova nota |
| **PUT** | `/todo/{id}` | Atualiza uma nota |
| **DELETE** | `/todo/{id}` | Deleta uma nota |

### Exemplo de Requisição (POST)
```json
{
  "title": "Minha Tarefa",
  "description": "Descrição detalhada",
  "priority": "Alta",
  "category": "Trabalho",
  "isCompleted": false
}
```

## 🔍 Documentação Interativa

Acesse a documentação Swagger em:
```
https://localhost:7000
```

## 📁 Estrutura do Projeto

```
ToDoAPI/
├── Controllers/
│   └── ToDoController.cs       # Endpoints da API
├── Data/
│   └── ToDoContext.cs          # Contexto EF Core
├── Database/
│   ├── create.sql              # Script de criação de tabelas
│   └── drop.sql                # Script de limpeza
├── Models/
│   └── Notes.cs                # Entidade Notes
├── appsettings.json            # Configurações
├── Program.cs                  # Configuração da aplicação
└── ToDoAPI.csproj              # Arquivo de projeto
```

## 🔧 Troubleshooting

### Erro de conexão com Oracle
- Verifique se o Oracle está rodando
- Valide as credenciais em `appsettings.json`
- Confira o host e porta da conexão

### Erro ao executar migrations
```bash
dotnet ef database update
```

## 📝 Modelo de Dados

**Tabela: NOTES**
- `ID` (VARCHAR2(36)): Identificador único (GUID)
- `TITLE` (VARCHAR2(200)): Título da nota
- `DESCRIPTION` (CLOB): Descrição
- `PRIORITY` (VARCHAR2(50)): Prioridade
- `CATEGORY` (VARCHAR2(100)): Categoria
- `ISCOMPLETED` (NUMBER(1)): Status de conclusão
- `CREATEDAT` (TIMESTAMP): Data de criação
- `UPDATEDAT` (TIMESTAMP): Data de atualização

## 📄 Licença

[Especifique a licença do seu projeto]

## 👤 Autor

Desenvolvido como projeto de aprendizado em ASP.NET Core e Oracle.
