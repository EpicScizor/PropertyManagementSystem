import React from 'react';
import './App.css';
import axios from 'axios';
import {
  useEffect,
  useState
} from "react";

function App() {
  const [guests, setGuests] = useState([]);
  
  useEffect(() => {
    axios.get("https://localhost:5000/api/Guest").then(Response => {
      setGuests(Response.data);
    }) 
  });
  
  return (
    <div>
      <header>Guest Ledger</header>
      
    </div>
  );
}

export default App;
