import React, { useState, useEffect } from 'react';
import ProdutoService from './ProdutoService';
import './ProdutoStyle/ProdutoCreateUpdate.css';

function ProdutoUpdate() {
    const [produtos, setProdutos] = useState([]);
    const [formState, setFormState] = useState({ nome: '', descricao: '', preco: '' });
    const [currentProduto, setCurrentProduto] = useState(null);

    useEffect(() => {
        buscarProdutos(); // Carrega os produtos ao montar o componente
    }, []);

    const buscarProdutos = async () => {
        try {
            const response = await ProdutoService.getAll();
            setProdutos(response.data);
        } catch (error) {
            console.error('Erro ao buscar produtos:', error);
        }
    };

    const selecionarProdutoParaEdicao = (produto) => {
        setCurrentProduto(produto);
        setFormState(produto);
    };

    const limparFormulario = () => {
        setCurrentProduto(null);
        setFormState({ nome: '', descricao: '', preco: '' });
    };

    const EnviarFormulario = async (e) => {
        e.preventDefault(); // evita comportamento padrão (recarregar pagina)
        if (!currentProduto) return;

        try {
            await ProdutoService.update(currentProduto.id, formState);
            buscarProdutos();
            limparFormulario();
        } catch (error) {
            console.error('Erro ao atualizar produto:', error);
        }
    };

    const DeletarProdutoSelecionado = async (id) => {
        try {
            await ProdutoService.delete(id);
            buscarProdutos();
        } catch (error) {
            console.error('Erro ao deletar produto:', error);
        }
    };

    const ValorDigitado = (e) => {
        const { name, value } = e.target;
        setFormState((prev) => ({ ...prev, [name]: value }));
    };

    return (
        <div>
            {currentProduto && (
                <form onSubmit={EnviarFormulario}>
                    <input
                        name="nome"
                        value={formState.nome}
                        onChange={ValorDigitado}
                        className='Formulario'
                        placeholder='Nome do Produto:'
                    />
                    <input
                        name="descricao"
                        value={formState.descricao}
                        onChange={ValorDigitado}
                        className='Formulario Descricao'
                        placeholder='Descrição do Produto:'
                    />
                    <input
                        name="preco"
                        type="number"
                        value={formState.preco}
                        onChange={ValorDigitado}
                        className='Formulario'
                        placeholder='Preço do Produto:'
                    />
                    <button type="submit" className='ButtonSave'>Salvar</button>
                </form>
            )}
            <ul>
                {produtos.map((produto) => (
                    <li key={produto.id}>
                        {produto.nome} - {produto.descricao} - R${produto.preco}
                        <button onClick={() => selecionarProdutoParaEdicao(produto)}>Editar</button>
                        <button onClick={() => DeletarProdutoSelecionado(produto.id)}>Deletar</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default ProdutoUpdate;