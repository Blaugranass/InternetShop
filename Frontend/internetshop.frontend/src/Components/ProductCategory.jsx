// src/components/ProductCategory.jsx
import React from 'react';
import './ProductCategory.css';

const ProductCategory = ({ title, icon, link }) => {
  return (
    <div className="category-card">
      <div className="category-icon">{icon}</div>
      <h3>{title}</h3>
    </div>
  );
};

export default ProductCategory;