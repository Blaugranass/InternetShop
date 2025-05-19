// src/pages/ActiveAnnouncements.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ProductCardUser from './components/ProductCardUser';
import './ActiveAnnouncements.css';

const ActiveAnnouncements = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    // Получаем только активные объявления (статус 0)
    axios.get('/api/announcements/active') // Используйте отдельный endpoint
      .then(response => {
        setProducts(response.data);
      })
      .catch(error => {
        console.error('Ошибка:', error);
      });
  }, []);

  return (
    <div className="active-announcements">
      <h1>Активные объявления</h1>
      <div className="product-grid">
        {products.map(product => (
          <ProductCardUser
            key={product.id}
            product={product}
            onAddToCart={() => console.log("Добавить в корзину")}
          />
        ))}
      </div>
    </div>
  );
};

export default ActiveAnnouncements;