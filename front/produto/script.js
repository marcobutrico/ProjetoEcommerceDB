const produtosContainer = document.getElementById('produtos-container');

// Fazer a requisição GET para a API
fetch('https://localhost:7293/api/produto')
  .then(response => {
    // Verificar se a resposta foi bem-sucedida
    if (!response.ok) {
      throw new Error('Erro ao buscar os dados');
    }
    return response.json(); // Parse do JSON
  })
  .then(produtos => {
    // Verificar se a resposta está vazia
    if (produtos.length === 0) {
      produtosContainer.innerHTML = '<p>Não há produtos disponíveis.</p>';
      return;
    }

    // Iterar sobre os produtos retornados pela API
    produtos.forEach(produto => {
      const card = document.createElement('div');
      card.className = 'produto-card';

      card.innerHTML = `
        <h2>${produto.nomeProduto}</h2>
        <p>Categoria: ${produto.categoria}</p>
        <p class="preco">R$ ${produto.preco.toFixed(2)}</p>
        <p>Estoque: ${produto.estoque}</p>
        ${produto.imagem ? `<img src="${produto.imagem}" alt="${produto.nomeProduto}" class="produto-imagem">` : ''}
      `;

      // Adicionar o card ao container
      produtosContainer.appendChild(card);
    });
  })
  .catch(error => {
    // Caso ocorra um erro, exibir uma mensagem
    console.error('Erro ao carregar os produtos:', error);
    produtosContainer.innerHTML = '<p>Ocorreu um erro ao carregar os produtos.</p>';
  });
