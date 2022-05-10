import React from 'react';
import logo from './logo.svg';
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
    <div className="App">
      <header className="App-header">
        <p>Hello, world!</p>
        <ul>
          {guests.map((guests: any) => (
              <li key = {guests.id}>
                {guests.firstname}
              </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
