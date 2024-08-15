import axios from 'axios';

const baseURL = 'http://localhost:5250/Produtos';

const ProdutoService = {
  getAll: () => axios.get(`${baseURL}/GetAll`),
  getById: (id) => axios.get(`${baseURL}/${id}`),
  create: (produto) => axios.post(`${baseURL}/RegistrarProduto`, produto),
  update: (id, produto) => axios.put(`${baseURL}/AtualizarProduto/${id}`, produto),
  delete: (id) => axios.delete(`${baseURL}/${id}`)
};

export default ProdutoService;
