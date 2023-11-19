import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import GRN from './pages/Pharmacy/GRN';
import Login from '../src/pages/Login/Login';
import Navbar from './pages/Navbar/Navbar';
import POS from './pages/Pharmacy/PhrPOS';
import Phr_Requisition from './pages/Pharmacy/PharmacyRequisition';

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route
            path="/grn"
            element={
              <>
                <Navbar />
                <GRN />
              </>
            }
          />

          <Route
            path="/phrPOS"
            element={
              <>
                <Navbar />
                <POS />
              </>
            }
          />

          <Route
            path="/PurchaseRequisition"
            element={
              <>
                <Navbar />
                <Phr_Requisition />
              </>
            }
          />

        </Routes>
      </Router>
    </div>
  );
}

export default App;
