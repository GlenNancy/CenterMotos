import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ProdutoService from './ProdutoService';

function ProdutoList() {
    const [produtos, setProdutos] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        buscarProdutos();
    }, []);

    const buscarProdutos = async () => {
        try {
            const response = await ProdutoService.getAll();
            setProdutos(response.data);
        } catch (error) {
            console.error('Erro ao buscar produtos:', error);
        }
    };

    return (
        <ul>
            {produtos.map((produto) => (
                <li key={produto.id}>
                    {produto.nome} - {produto.descricao} - R${produto.preco}
                    <button onClick={() => navigate(`/editarProduto`)}>Editar</button>
                </li>
            ))}
        </ul>
    );
}

export default ProdutoList;
