// src/components/ProductCardUser.js
import React from 'react';

const ProductCardUser = ({ product, onAddToCart }) => {
  return (
    <div className="product-card">
      <img src={product.image} alt={product.name} className="product-image" />
      <h3>{product.name}</h3>
      <p className="price">${product.price}</p>
      <p className="description">{product.description}</p>
      <button className="add-to-cart" onClick={() => onAddToCart(product)}>
        Добавить в корзину
      </button>
    </div>
  );
};

export default ProductCardUser;