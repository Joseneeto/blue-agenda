<h1 align="center">Projeto CRUD de uma Agenda</h1>

Criação de um crud com dois frameworks frontend diferentes consumindo a mesma API para gerenciamento de cadastro de uma agenda.

## 🛠️ Ferramentas e Tecnologias

- ASP.NET 6 
- EntityFramework 
- Vue3
- React
- SQL Server 2022
- Swagger
- VS Code
- Visual Studio Community 2022

## ⚙ Funcionalidades

- Criar cadastro de usuário
- Ler cadastro de usuário
- Atualizar um usuário específico
- Deletar um usuárop específico

## 💻 Como executar o Frontend Vue

- Clone esse repositório:

  ```$ git git@github.com:Joseneeto/blue-agenda.git```

- Entre no diretório do projeto: 

  ```$ cd agenda-blue/frontend/front-vue```
  
- Abrir o git bash no diretorio:

  ```$ code .```

- Instale o gerenciador de pacotes do Node:

  ```$ npm install```

- Execute a aplicação:
 
  ```$ npm run dev```

- URL para acessar servidor local:

  ```acesse http://localhost:5173/``` 
  
## 💻 Como executar o Frontend React

- Clone esse repositório:

  ```$ git git@github.com:Joseneeto/blue-agenda.git```

- Entre no diretório do projeto: 

  ```$ cd agenda-blue/frontend/front-react```
  
- Abrir o git bash no diretório:

  ```$ code .```
  
  - Instale o gerenciador de pacotes do Node:

  ```$ npm install```

- Instale o gerenciador de pacotes do Node:

  ```$ npm start```

- URL para acessar servidor local:

  ```acesse http://localhost:3000/```
  
  
 ## 💻 Como executar o Backend

Antes de iniciar a aplicação é necessário a instalação do banco de dados no SQL Server e alteração das credenciais de acesso User ID=<seu id>;Password=<sua senha> no arquivo BlueDbContext.cs.

- Clone esse repositório:

  ```$ git clone git@github.com:Joseneeto/blue-agenda.git```

- Entre no diretório do projeto: 

  ```cd projeto-blue/backend```

- Execute a aplicação:

  ```$ dotnet run```

- URL local da aplicação:

  ```acesse http://localhost:7294/```


## 🚉 Rotas da API

- Rota ```api/Contato``` (método ```GET```): Retorna todos usários cadastrados na API

- Rota ```api/Contato/id``` (método ```GET```): Retorna um usário cadastrado na API baseado no ```id```

- Rota ```api/Contato/cadastrar``` (método ```POST```): Cria um cadastro de usuário na API

- Rota ```api/Contato/alterar/id``` (método ```PUT```): Atualiza um cadastro de usuário na API baseado no ```id```

- Rota ```api/Contato/remover/id``` (método ```DELETE```): Deleta um cadastro de usuário na API baseado no ```id```
