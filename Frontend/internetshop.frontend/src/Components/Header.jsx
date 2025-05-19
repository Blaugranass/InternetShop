// src/components/Header.jsx
import React from 'react';
import './Header.css';

const Header = () => {
  return (
    <header className="site-header">
      <div className="header-content">
        <div className="logo">
          <h1>ComputerStore</h1>
        </div>
        <nav className="main-nav">
          <ul>
            <li><a href="/">Главная</a></li>
            <li><a href="/catalog">Каталог</a></li>
            <li><a href="/about">О нас</a></li>
          </ul>
        </nav>
      </div>
    </header>
  );
};

export default Header;