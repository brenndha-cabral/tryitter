# Projeto Tryitter :bird:

<div align="center">
   <img src="./public/assets/images/readme-banner.png" alt="" width="1000">
</div>

<h2>Índice</h2>

 :round_pushpin: [Sobre](#sobre)<br />
 :round_pushpin: [Tecnologias](#tecnologias)<br />
 :round_pushpin: [Usabilidade](#usabilidade)<br />
 :round_pushpin: [Documentação](#documentacao)<br />
 :round_pushpin: [Orientações](#orientacoes)<br />
 :round_pushpin: [Scripts](#scripts)<br />
 :round_pushpin: [Testes](#testes)<br />
 :round_pushpin: [DER](#der)<br />
 :round_pushpin: [Referências](#referencias)<br />

<h2 id="sobre">Sobre</h2>

Esta aplicação tem como objetivo gerenciar uma rede social  :iphone:

 - Esta é uma aplicação em `.NET` com `Entity Framework` fazer um CRUD de contas e posts. Infelizmente não foi possível realizar o deploy na `Azure`, consulte a seção [documentação](#documentacao) para entender melhor.
 - Esta aplicação seguiu os princípios do REST e se conecta ao banco de dados `MySQL Server`.
 - Para acessar a API, é necessário que a pessoa usuária faça login com suas credencias e isso será autenticado e autorizado via JWT com a geração de token.
 - É possível também que a pessoa usuária possa se cadastrar e utilizar a API, a partir disso é gerado um token para acesso a API.

<h2 id="tecnologias">Tecnologias</h2>

<div>
  <img title="C#" alt="C#" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />
  <img title=".NET" alt=".NET" height="30" width="40" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" />
  <img title="Entity Framework" alt="Entity Framework" height="30" width="30" src="./public/assets/images/ef.png">
  <img title="JWT" alt="JWT" height="30" width="30" src="./public/assets/images/jwt.png">
  <img title="MySQL Server" alt="Entity Framework" height="30" width="30" src="./public/assets/images/sql-server.png">
  <img title="xUnit" alt="xUnit" height="30" width="30" src="./public/assets/images/xunit.png">
</div>

 <h2 id="usabilidade">Usabilidade</h2>

> Veja a seção de [documentação](#documentacao) para entender melhor como funcionam as rotas.
> Veja a seção de [orientações](#orientacoes) antes de rodar a aplicação.

:round_pushpin: Acessando o local pelo Swagger:

> Faça um clone deste repositório:
- `git@github.com:brenndha-cabral/tryitter.git` 

> Navegue até a pasta do projeto `tryitter.csproj` e rode os scripts `dotnet restore` e `dotnet run` (lembrando que o docker-compose já deve estar iniciado).

> Após rodar a aplicação, você deverá acessar através de:
- `https://localhost:7136/swagger/index.html` 

> Caso prefira outro cliente, aqui estão algumas sugestões:
  :bulb: [HTTPie](https://httpie.io/) | :bulb: [Postman](https://www.postman.com/) | :bulb: [Insomnia](https://insomnia.rest/)


<h2 id="documentacao">Documentação</h2>
<details>

<summary id="env"><strong>:pencil: Clique aqui e tenha uma pré visualização da API</strong></summary><br/>

<div align="center">
    <img src="./public/assets/images/swagger.png" alt="Swagger" width="1000">
</div>

</details>

> :information_source: É necessário possuir `dotnet`, `docker` e `docker-compose` instalados para rodar a aplicação localmente e abrir o Swagger com os endpoints e orientações.

> Caso não tenha conhecimento em Swagger, clique [aqui](https://www.youtube.com/watch?v=cOhguRdlr5A) e veja como é fácil utilizar.

 - _Motivo por não ter realizado o deploy: Criei a conta na Azure mas infelizmente não sou elegível para testar gratuitamente. Informei à Trybe o ocorrido._
 
 - Para que a as rotas sejam consumidas, é necessário que a pessoa usuária faça login.

 - Para fazer login, clique em `Try it out` e com as credenciais de uma pessoa estudante (crie uma na rota `POST /students` previamente) e em seguida clique em `execute`, a aplicação retornará um token.

 - Após o login, o token retornado deve ser inserido em `Authorize` e isso fará com que haja a autenticação e autorização para todas as rotas.

 - Após isso, o token já será validado em todas as rotas. Siga os exemplos e clique em `execute` para retornar as respostas.

 - Exceto a rota `POST /students` que não necessita de login, neste caso após o cadastro, será retornado um token para então a utilização da API.

<h2 id="orientacoes">Orientações</h2>

<details>

<summary id="docker"><strong>:whale2: Rodando com Docker</strong></summary>

### 👉 Com Docker

> :information_source: Rode o serviço `db` com o comando `docker-compose up`.

- Esse comando irá inicializar um container chamado `sql_server_db`;

> :information_source: Ao rodar o docker-compose, ele criará uma imagem do banco de dados `MySQL Server`. 

</details>

<h2 id="scripts">Scripts</h2>

<details>

<summary id="env"><strong>:pencil: Aqui estão os scripts da aplicação para que você possa utilizar</strong></summary><br/>

- `dotnet restore`: Irá instalar os pacotes NuGets;

- `dotnet ef database update`: Irá criar o banco de dados localmente;

- `dotnet run`: Irá rodar a aplicação;

- `dotnet test`: Irá rodar todos os testes de integração da aplicação;

> Sinta-se à vontade para ajustar os scripts de acordo com a sua necessidade.
</details>


<h2 id="testes">Testes</h2>

<details>

<summary id="env"><strong>🧪 Foram realizados testes de integração para atingir a cobertura mínima de 30%</strong></summary><br/>

> Foram realizados testes de integração com `xUnit` e `Fluent Assertions`. Não consegui fazer o mock do banco de dados, por isso os testes foram realizados em cima do bando de dados de desenvolvimento.
<div align="center">
    <img src="./public/assets/images/tests-coverage.png" alt="Relatório de cobertura de testes" width="1000">
    <img src="./public/assets/images/tests.png" alt="Relatório de cobertura de testes" width="1000">
</div>

</details>

<h2 id="der">Diagrama Entidade Relacionamento</h2>

<details>

<summary id="env"><strong>:chart_with_upwards_trend: Students | StudentsPosts | Posts</strong></summary><br/>

  <div align="center">
    <img src="./public/assets/images/der.png" alt="Diagrama Entidade Relacionamento" width="1000">
  </div>

</details>


<h2 id="referencias">Referências</h2>

> :information_source: Este projeto foi a realização de um projeto final da aceleração de C# da [Trybe](https://www.betrybe.com/) em parceria com a [XP Inc.](https://www.linkedin.com/company/xp-inc/)
