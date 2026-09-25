# InventoryHub - Desafio Backend C#

Web API de gerenciamento de estoque e produtos.

## Visão técnica (rápida)

Este projeto utiliza a plataforma **.NET 8** e é escrito 100% em linguagem **C#**.

- **C#**: linguagem de programação usada em todos os arquivos `.cs` do projeto.
- **.NET 8**: plataforma / SDK que compila e executa o código C#. Inclui o CLI (`dotnet build`, `dotnet run`) e as bibliotecas padrão do ecossistema.
- **ASP.NET Core**: framework web oficial do .NET utilizado para construir a API REST (Controllers, pipeline HTTP e injeção de dependência).
- **Entity Framework Core (EF Core)**: ORM utilizado para persistência de dados no banco (neste projeto, em memória — InMemory), sem necessidade de escrever SQL manualmente.

---

## Pré-requisitos

- .NET 8.0 SDK instalado na máquina.
    - Verificação: execute `dotnet --version` no terminal.

---

## Como rodar o projeto

### 1. Restaurar dependências

Na pasta raiz do projeto (onde se encontra `InventoryHub.csproj`):

```bash
dotnet restore
```

### 2. Build do projeto

```bash
dotnet build
```

Corrija todos os erros e warnings do compilador antes de prosseguir.

### 3. Executar a aplicação

```bash
dotnet run
```

A aplicação irá exibir no terminal as URLs de escuta (ex.: `http://localhost:5000` e `https://localhost:5001`).

### 4. Acessar a documentação Swagger

Abra no navegador a URL exibida no terminal, acrescida de `/swagger`:

```
http://localhost:50xx/swagger
```

Utilize a interface do Swagger para testar os endpoints da API.

---

## Reconstrução do projeto (clean build)

Para limpar artefatos de compilação antigos e fazer uma reconstrução do zero:

```bash
dotnet clean
dotnet restore
dotnet build --no-incremental
```

---

## Endpoints principais

| Método HTTP | Rota                         | Descrição                                  |
|-------------|------------------------------|--------------------------------------------|
| GET         | `/api/products`              | Lista todos os produtos                    |
| GET         | `/api/products/{id}`         | Retorna um produto pelo seu ID             |
| POST        | `/api/products`              | Cria um novo produto                       |
| PUT         | `/api/products/{id}/stock`   | Atualiza (baixa) o estoque de um produto   |

---

## Comportamento esperado ao final do live code

Ao fim da sessão, ao testar a API através da interface do Swagger, espera-se que:

- `GET /api/products` retorne a lista de produtos cadastrados com sucesso.
- `GET /api/products/{id}` retorne os dados de um produto existente e informe quando um produto não for encontrado.
- `POST /api/products` crie um novo produto e retorne os dados persistidos, incluindo o identificador gerado.
- `PUT /api/products/{id}/stock` efetue a baixa de estoque de um produto existente com quantidade válida e informe adequadamente quando o produto não for encontrado ou a entrada for inválida.
- Todos os cenários acima retornem códigos de status HTTP apropriados para cada situação (sucesso, recurso não encontrado e entrada inválida).

---

Boa sorte! 🌟 Estamos animados para ver você em ação e conhecer um pouco mais do seu potencial. Conte com a gente — respire fundo, faça no seu ritmo e dê o seu melhor. Estamos torcendo por você! 💙🚀
