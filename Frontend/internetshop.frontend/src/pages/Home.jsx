import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Header from '../components/Header';
import ProductCardUser from '../components/ProductCardUser'; 
import ProductCategory from '../components/ProductCategory'; 
import { FaSearch, FaShoppingCart, FaUser } from 'react-icons/fa';
import './Home.css';

const Home = () => {
  const [popularProducts, setPopularProducts] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');

  useEffect(() => {
    axios.get('/api/announcements/all')
      .then(response => {
        setPopularProducts(response.data);
      })
      .catch(error => {
        console.error('Ошибка:', error);
      });
  }, []);

  const categories = [
    { id: 1, title: 'Ноутбуки', icon: '💻', link: '/laptops' },
  ];

  return (
    <div className="home-container">
      <Header />
      
      {/* Блок с поиском и действиями */}
      <div className="top-actions">
        {/* Поиск */}
        <div className="search-bar">
          <FaSearch className="search-icon" /> {/* Иконка лупы */}
          <input 
            type="text" 
            placeholder="Поиск..." 
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
          />
        </div>
        
        {/* Корзина и аккаунт */}
        <div className="user-actions">
          <button className="cart-btn">
            <FaShoppingCart size={24} color="#333" />
          </button>
          <button className="account-btn">
            <FaUser size={24} color="#333" />
          </button>
        </div>
      </div>

      <section className="product-categories">
        <h2>Категории</h2>
        <div className="category-grid">
          {categories.map(category => (
            <ProductCategory 
              key={category.id}
              title={category.title}
              icon={category.icon}
              link={category.link}
            />
          ))}
        </div>
      </section>

      <section className="popular-products">
        <h2>Популярные товары</h2>
        <div className="product-grid">
          {popularProducts.map(product => (
            <ProductCardUser 
              key={product.id}
              product={product}
              onAddToCart={() => console.log("Добавить в корзину")}
            />
          ))}
        </div>
      </section>
    </div>
  );
};

export default Home;