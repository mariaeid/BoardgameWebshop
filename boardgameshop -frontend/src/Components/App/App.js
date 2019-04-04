import React, { Component } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import Routes from '../../routes';

const App = () => (
  <BrowserRouter>
    <div>
      <Routes />
    </div>
  </BrowserRouter>
);

export default App;
