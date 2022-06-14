import React from 'react';
import logo from './logo.svg';
import './style.css';
import { useEffect, useState } from 'react'
import axios from 'axios'

function App() {
  const [guests, setGuests] = useState([]); 
  
  useEffect(() => {
    axios.get("http://localhost:5000/api/Guest").then(response => {
      console.log(response)
      setGuests(response.data)
    })
  }, [])
  
  return (
    <div className="App">
      <h1>Hello, world!</h1>
      <ul>
          {guests.map((guest: any) => (
              <li key={guest.id}>
                  {guest.lastName}, {guest.firstName}
              </li>
          ))}
      </ul>
    </div>
  );
}

export default App;
