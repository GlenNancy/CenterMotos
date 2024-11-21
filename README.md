<h1>CenterMotos API</h1>
  <p>Bem-vindo à documentação do projeto <strong>CenterMotos API</strong>. Este sistema backend foi desenvolvido para gerenciar uma oficina mecânica, resolvendo problemas reais e otimizando processos.</p>

  <h2>Descrição do Projeto</h2>
  <p>O projeto oferece funcionalidades para gerenciar peças, avaliações, comentários e pedidos, utilizando boas práticas de desenvolvimento e uma arquitetura bem estruturada (MVC).</p>

  <h2>Funcionalidades</h2>
  <h3>Para o Mecânico (Administrador)</h3>
  <ul>
    <li>CRUD completo para peças: registrar, visualizar, editar e deletar peças.</li>
    <li>Gerenciar informações das peças: adicionar valor, descrição e imagem.</li>
    <li>Moderação de comentários: visualizar e deletar comentários.</li>
  </ul>

  <h3>Para o Cliente</h3>
  <ul>
    <li>Visualizar peças disponíveis com detalhes (preço e descrição).</li>
    <li>Criar pedidos/carrinhos para compra.</li>
    <li>Adicionar ou excluir comentários em peças.</li>
  </ul>

  <h2>Tecnologias Utilizadas</h2>
  <ul>
    <li><strong>Backend:</strong> C#, .NET Core, Entity Framework Core, ASP.NET MVC, JWT, FluentValidation.</li>
    <li><strong>Banco de Dados:</strong> SQL Server (migrações com Entity Framework).</li>
    <li><strong>Outras Ferramentas:</strong> Insomnia, Git/GitHub.</li>
  </ul>

  <h2>Guia de Instalação</h2>
  <h3>Pré-requisitos</h3>
  <ol>
    <li>Instale o .NET SDK 6.0 ou superior: <a href="https://dotnet.microsoft.com/download" target="_blank">Download do .NET SDK</a>.</li>
    <li>Tenha o SQL Server instalado e rodando em sua máquina.</li>
  </ol>

  <h3>Passos para rodar o projeto</h3>
  <ol>
    <li>Clone o repositório:
      <pre><code>git clone https://github.com/GlenNancy/CenterMotos.git</code></pre>
    </li>
    <li>Navegue até a pasta do projeto:
      <pre><code>cd CenterMotos</code></pre>
    </li>
    <li>Restaure os pacotes:
      <pre><code>dotnet restore</code></pre>
    </li>
    <li>Configure o banco de dados:
      <pre><code>{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CenterMotosDb;Trusted_Connection=True;"
  }
}</code></pre>
    </li>
    <li>Execute as migrações para criar o banco:
      <pre><code>dotnet ef database update</code></pre>
    </li>
    <li>Inicie a aplicação:
      <pre><code>dotnet run</code></pre>
    </li>
  </ol>

    <h2>Endpoints da API</h2>
  <h3>Autenticação</h3>
  <ul>
    <li><strong>POST /api/auth/login</strong>
      <p>Descrição: Realiza o login do usuário.</p>
      <p><strong>Body:</strong></p>
      <pre><code>{
  "email": "usuario@example.com",
  "password": "senha123"
}</code></pre>
      <p><strong>Resposta:</strong></p>
      <pre><code>{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}</code></pre>
    </li>
  </ul>

  <h3>Gerenciamento de Produtos</h3>
  <ul>
    <li><strong>GET /api/Produtos/GetAll</strong> - Lista todos os produtos disponíveis.</li>
    <li><strong>POST /api/Produtos/GetAll</strong> - Cadastrar um novo produto (restrito ao administrador).
      <p><strong>Body:</strong></p>
      <pre><code>{
  "nome": "Pneu",
  "descricao": "Pneu aro 16",
  "preco": 350.00,
  "imagem": "url-da-imagem"
}</code></pre>
    </li>
  </ul>

  <h3>Comentários</h3>
  <ul>
    <li><strong>POST /api/comentarios/GetAll</strong> - Adiciona um comentário a um produto.
      <p><strong>Body:</strong></p>
      <pre><code>{
  "idPeca": 1,
  "texto": "Ótima qualidade!"
}</code></pre>
    </li>
    <li><strong>DELETE /api/comentarios/{id}</strong> - Exclui um comentário (restrito ao administrador ou autor).</li>
  </ul>

  <h2>Testes Unitários</h2>
  <p>Os testes foram escritos usando <strong>xUnit</strong> e cobrem as principais funcionalidades da aplicação.</p>
  <p><strong>Rodar os testes:</strong></p>
  <pre><code>dotnet test</code></pre>

  <h2>Melhorias Futuras</h2>
  <ul>
    <li>Sistema de avaliação de peças pelos clientes (estrelas).</li>
    <li>Notificação de esgotamento de itens no estoque.</li>
    <li>Popular as peças mais visualizadas/compradas.</li>
  </ul>

  <h2>Contribuições</h2>
  <p>Contribuições são bem-vindas! Para contribuir:</p>
  <ol>
    <li>Faça um fork do repositório.</li>
    <li>Crie uma nova branch:
      <pre><code>git checkout -b minha-feature</code></pre>
    </li>
    <li>Faça as alterações e envie um pull request.</li>
  </ol>

  <h2>Licença</h2>
  <p>Este projeto está licenciado sob a <a href="LICENSE" target="_blank">MIT License</a>.</p>

  <h2>Links úteis</h2>
  <ul>
    <li><a href="https://learn.microsoft.com/pt-br/dotnet/" target="_blank">Documentação oficial do .NET</a></li>
    <li><a href="https://github.com/GlenNancy/CenterMotos" target="_blank">GitHub do projeto</a></li>
  </ul>
