import React, { useState, useEffect } from 'react';
import ProdutoService from './ProdutoService';

function ProdutoList() {
    const [produtos, setProdutos] = useState([]);

    const fetchProdutos = async () => {
        try {
            const response = await ProdutoService.getAll();
            setProdutos(response.data);
        } catch (error) {
            console.error('Erro ao buscar produtos:', error);
        }
    };

    useEffect(() => {
        fetchProdutos(); // Carrega os produtos quando o componente é montado
    }, []);

    return (
        <div>
            <ul>
                {produtos.map((produto) => (
                    <li key={produto.id}>
                        {produto.nome} - {produto.descricao} - R${produto.preco}
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default ProdutoList;