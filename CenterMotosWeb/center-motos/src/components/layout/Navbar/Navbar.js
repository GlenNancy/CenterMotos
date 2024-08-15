import { Link } from "react-router-dom";
import React, { useState, useEffect } from 'react';
import './Navbar.css'
import Whatsapp from "../../../Icons/zapzap_branco.png"
import Instagram from "../../../Icons/insta_branco.png"
import Telefone from "../../../Icons/fone_branco.png"
import Perfil from "../../../Icons/user.png"
import config from '../../../config.json'

function Navbar() {
    const [clienteNome, setClienteNome] = useState('');

    useEffect(() => {
        fetch(`http://localhost:5250/Clientes/1`)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                setClienteNome(data.nomeCliente);
            })
            .catch(error => console.error('Erro ao buscar o nome do cliente:', error));
    }, []);

    return (
        <div>
            <div className="atendimento-contato">
                <h3 className="horarioAtendimento">{config.horarioAtendimento}</h3>
                <div className="contato">
                    <img src={Whatsapp} alt="whatsapp" title="Logo do whatsapp" className="whatsapp principal" />
                    <p>{config.phoneNumber}</p>
                </div>
            </div>

            <div>
                <ul>
                    <li>
                        <a href="https://www.instagram.com/mauricio_santoszz/" target="_blank" rel="noopener noreferrer">
                            <img src={Instagram} alt="instagram" title="Logo do Insta" className="instagram" />
                        </a>
                    </li>
                    <li>
                        <a
                            href={`https://wa.me/${config.whatsapp}`}
                            target="_blank"
                            rel="noopener noreferrer"
                        >
                            <img src={Whatsapp} alt="whatsapp" title="Logo do whatsapp" className="whatsapp lista" />
                        </a>
                    </li>
                    <li>
                        <a href={`tel:${config.phoneNumber}`}>
                            <img src={Telefone} alt="telefone" title="Logo do telefone" className="telefone" />
                        </a>
                    </li>
                </ul>

                <h1 className="Logo">C͟E͟N͟T͟E͟R͟ MOTOS</h1>

                <div>
                    <img src={Perfil} alt="Perfil" title="Perfil" className="perfil" />
                    <p>Olá {clienteNome}</p>
                </div>
            </div>

            <ul>
                <li>
                    <Link to="/">Inicio</Link>
                </li>
                <li>
                    <Link to="/criarProduto">Cadastrar Produto</Link>
                </li>
                <li>
                    <Link to="/cliente">Clientes</Link>
                </li>
            </ul>
        </div>
    );
}

export default Navbar;