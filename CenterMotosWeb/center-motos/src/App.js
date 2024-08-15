import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import ProdutoCreate from './components/Produtos/ProdutoCreate';
import ProdutoUpdate from './components/Produtos/ProdutoUpdate';
import Navbar from './components/layout/Navbar/Navbar';
import Home from './Pages/Home';

function App() {
  return (
    <Router>
      <Navbar />

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/criarProduto" element={<ProdutoCreate />} />
        <Route path="/editarProduto" element={<ProdutoUpdate />} />
        <Route path="/cliente" element={<ProdutoUpdate />} />
      </Routes>
    </Router>
  );
}

export default App;
