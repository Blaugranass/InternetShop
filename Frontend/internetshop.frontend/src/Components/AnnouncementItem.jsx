import React, { useState, useEffect } from 'react';

const AnnouncementItem = ({ announcement, onEdit, onDelete }) => {
  // Все хуки в верхней части
  const [showModal, setShowModal] = useState(false);
  const [newPrice, setNewPrice] = useState(0);
  const [newQuantity, setNewQuantity] = useState(0);
  const [newStatus, setNewStatus] = useState(0);

  // Инициализация состояний при изменении announcement
  useEffect(() => {
    if (announcement) {
      setNewPrice(announcement.price || 0);
      setNewQuantity(announcement.quantity || 0);
      setNewStatus(announcement.status || 0);
    }
  }, [announcement]);

  const handleSave = () => {
    const dto = {
      newPrice,
      newQuantity,
      newStatus,
    };
    onEdit(announcement?.id, dto); // Защита от undefined
    setShowModal(false);
  };

  // Проверка на undefined
  if (!announcement || !announcement.product) return null;

  const {
    id,
    price,
    quantity,
    status,
    product: { name, description },
  } = announcement;

  return (
    <div
      className={`announcement-item ${status === 0 ? 'active' : 'inactive'}`}
    >
      <h2>{name}</h2>
      <p>Цена: {price}$</p>
      <p>Описание: {description || 'Нет описания'}</p>
      <p>Количество: {quantity} шт.</p>
      <button className="edit-btn" onClick={() => setShowModal(true)}>
        Редактировать
      </button>
      <button
        className="delete-btn"
        onClick={() => {
          if (window.confirm('Вы уверены?')) {
            onDelete(id);
          }
        }}
      >
        Удалить
      </button>

      {showModal && (
        <div className="modal">
          <div className="modal-content">
            <h3>Редактировать объявление</h3>
            <label>
              Новая цена:
              <input
                type="number"
                value={newPrice}
                onChange={(e) => setNewPrice(Number(e.target.value))}
              />
            </label>
            <label>
              Новое количество:
              <input
                type="number"
                value={newQuantity}
                onChange={(e) => setNewQuantity(Number(e.target.value))}
              />
            </label>
            <label>
              Статус:
              <select
                value={newStatus}
                onChange={(e) => setNewStatus(Number(e.target.value))}
              >
                <option value="0">Активное</option>
                <option value="1">Неактивное</option>
              </select>
            </label>
            <div className="button-group">
              <button className="save-btn" onClick={handleSave}>
                Сохранить
              </button>
              <button
                className="cancel-btn"
                onClick={() => setShowModal(false)}
              >
                Отмена
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default AnnouncementItem;