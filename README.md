## Descrição da Aplicação de Gerenciamento de Inventário de Produtos
Esta aplicação foi desenvolvida para fins didáticos, permitindo operações de CRUD (Criar, Ler, Atualizar e Excluir) para gerenciar um inventário de produtos de maneira eficiente. O foco principal está em gerenciar os dados de produtos, que incluem informações como tipo, marca, modelo e quantidade.

## Tecnologias Utilizadas
- **.NET 8**: Framework utilizado para o desenvolvimento da aplicação.
- **Entity Framework Core**: Biblioteca de ORM para interagir com o banco de dados.
- **SQL Server**: Banco de dados utilizado para armazenar informações dos produtos.
- **Swagger**: Para documentação (em breve) e testes da API.
- **Postman**: Para realizar testes das rotas da API.

## Funcionalidades Implementadas

1. **Gerenciamento de Produtos**:
   - **Criar Produto**: Endpoint para adicionar novos produtos ao inventário, com verificação para evitar duplicidades com base em tipo, marca e modelo.
   - **Buscar Produtos**: 
     - Busca por tipo e/ou marca, permitindo que apenas um ou todos os campos sejam preenchidos para realizae a busca. Retorna todos os produtos que correspondem aos critérios de pesquisa.
     - Caso não sejam encontrados produtos, retorna uma mensagem apropriada.
   - **Atualizar Produto**: Endpoint para atualizar as informações de um produto existente.
   - **Excluir Produto**: Endpoint para remover um produto do inventário.

2. **Validação**:
   - Implementação de validações para garantir que os dados enviados nas requisições atendam aos requisitos especificados.
   - Retorno de erros apropriados ao usuário, como mensagens de conflito (HTTP 409) caso um produto já exista ou erros de validação.

3. **Documentação da API (em breve)**:
   - Utilização do Swagger para gerar a documentação interativa da API, facilitando testes e entendimento das rotas disponíveis.

## Considerações
- A aplicação atualmente não é sensível a maiúsculas e minúsculas e não requer acentuação nos campos de busca, melhorando a usabilidade.
- A arquitetura segue boas práticas de desenvolvimento, com separação de responsabilidades e implementação de um padrão RESTful.
- Aplicação recomendada para lojas de departamento de pequeno porte, para controle de seu estoque.
