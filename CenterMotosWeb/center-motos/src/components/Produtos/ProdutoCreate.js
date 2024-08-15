import React, { useState, useEffect } from 'react';
import ProdutoService from './ProdutoService';
import './ProdutoStyle/ProdutoCreateUpdate.css';

function ProdutoCreate() {
    const [formState, setFormState] = useState({ nome: '', descricao: '', preco: '' });
    const [produtos, setProdutos] = useState([]);

    // Função para buscar todos os produtos da API
    const fetchProdutos = async () => {
        try {
            const response = await ProdutoService.getAll();
            setProdutos(response.data);
        } catch (error) {
            console.error('Erro ao buscar produtos:', error);
        }
    };

    useEffect(() => {
        fetchProdutos();
    }, []);

    const ValorDigitado = (e) => {
        const { name, value } = e.target;
        setFormState(prev => ({ ...prev, [name]: value }));
    };

    const EnvioFormulario = async (e) => {
        e.preventDefault();
        try {
            await ProdutoService.create(formState);
            fetchProdutos(); // Atualiza a lista de produtos após a criação
            setFormState({ nome: '', descricao: '', preco: '' });
        } catch (error) {
            console.error('Erro ao criar produto:', error);
        }
    };

    return (
        <div>
            <h1 className='CadastrarProduto'>Cadastrar Produto</h1>
            
            <form onSubmit={EnvioFormulario}>
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
                <button type="submit" className='ButtonRegister'>Registrar</button>
            </form>
        </div>
    );
}

export default ProdutoCreate;
