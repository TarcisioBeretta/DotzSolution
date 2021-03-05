<h1>DotzSolution</h1>

<br/>

<h2>Executando a aplicação</h2>

<p>Para criar o banco de dados execute o comando <code>dotnet ef --startup-project Dotz.Api/Dotz.Api.csproj database update</code>.</p>
<p>Após criar o banco de dados, execute o comando <code>dotnet run -p Dotz.Api/Dotz.Api.csproj</code> na raiz do projeto para executar a aplicação.</p>
<p>Ao acessar a URL <code><a href="https://localhost:5001/swagger/index.html" target="_blank">https://localhost:5001/swagger/index.html</a></code> será exibida a documentação da API no Swagger.</p>

<br/>

<h2>Postman</h2>

<p>Dentro da pasta "Postman" na raiz do projeto estão os aquivos contendo a Collection, e o Environment necessários para executar as chamadas aos endpoints da aplicação</p>
<p>Para começar a usar a aplicação, execute os métodos Post contidos nas pastas "Usuarios", e "Produtos".</p>
<p>Após fazer o cadastro de ao menos um usuário e um pedido, será necessário se autenticar usando os dados do usuário cadastrado.</p>
<p>Para se autenticar, execute o método Post contido na pasta "Autenticação".</p>
<p>Após a autenticação é possível cadastrar uma troca usando o método Post contido na pasta "Trocas"</p>

<br/>

<h2>Divisão de camadas</h2>

<h3>Core</h3>

<p>
  A camada core é referenciada por todas as outras camadas.
  <br/>
  Nessa camada ficam os contratos dos Models, Repositories, e Services.
</p>

<h3>Data</h3>

<p>
  A camada data é responsável pelo acesso ao banco de dados.
  <br/>
  Nessa camada ficam as Configurations, Migrations, e as implementações dos Repositories definidos na camada core.
  <br/>
  Foi utilizado o Repository Pattern para encapsular o banco de dados e as operações de acesso dentro da classe UnitOfWork.
  <br/>
  Caso seja necessario fazer uma migração de bancos de dados apenas essa camada será alterada.
</p>

<h3>Services</h3>

<p>
  A camada services é responsável por conter todas as regras de negócio presentes no sistema, e fazer a ligação entre a API e a camada de dados.
  <br/>
  Aqui ficam as implementações dos services definidos na camada core.
</p>

<h3>API</h3>

<p>
  A camada API define e implementa os endpoints, e os Resources, que são modelos de input e output da aplicação.
  <br/>
  Nessa camada foi utilizado o AutoMapper para fazer a conversão [Resources] <-> [Models].
  <br/>
  O cotroller "Troca" só pode ser acessado caso a requisição contenha um Bearer Token, esse token é obtido ao fazer um push com usuário e senha para o endpoint "/auth/login"
</p>

<br/>

