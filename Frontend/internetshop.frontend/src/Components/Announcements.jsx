import React, { useEffect, useState } from 'react';
import axios from 'axios';
import AnnouncementItem from './AnnouncementItem';
import './AnnouncementItem.css';

const Announcements = () => {
  const [announcements, setAnnouncements] = useState([]);

  useEffect(() => {
    axios.get('/api/announcements/all')
      .then(response => {
        const validAnnouncements = response.data.filter(a => a.product);
        setAnnouncements(validAnnouncements);
      })
      .catch(error => {
        console.error('Ошибка:', error);
      });
  }, []);

  const handleEdit = async (id, dto) => {
    try {
      await axios.patch(`/api/announcements/edit/${id}`, dto);
      setAnnouncements(prev => prev.map(a => 
        a.id === id ? { ...a, ...dto } : a
      ));
    } catch (error) {
      console.error('Ошибка:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`/api/announcements/delete/${id}`);
      setAnnouncements(prev => prev.filter(a => a.id !== id));
    } catch (error) {
      console.error('Ошибка:', error);
    }
  };

  return (
    <div>
      <h1>Объявления</h1>
      <div className="announcement-list">
        {announcements.map(announcement => (
          <AnnouncementItem
            key={announcement.product.id} // Используйте product.id как key
            announcement={announcement}
            onEdit={handleEdit}
            onDelete={handleDelete}
          />
        ))}
      </div>
    </div>
  );
};

export default Announcements;