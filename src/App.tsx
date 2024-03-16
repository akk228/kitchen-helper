import React, { Component } from 'react';
import './App.css';
import Fridge from './Fridge/Fridge';
import Home from './Home';
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';
import { Recipes } from './Recipes/Recipes';

export default class App extends Component {
  render (){
    return(
      <Router>
        <div className="App">
          <header className="App-header">
            <h1>Help you with your kitchen</h1>
          </header>
          <nav className='nav'>
          <ul className='ul'>
            <li className='li'>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/fridge">Fridge</Link>
            </li>
            <li>
              <Link to="/recipes">Recipes</Link>
            </li>
          </ul>
        </nav>
        </div>
        
        <Routes>
          <Route path="/fridge" element={<Fridge/>}/>
          <Route path="/recipes" element={<Recipes/>}/>
          <Route path="/" element={<Home/>}/>
        </Routes>
      
       
      </Router>
  );
}
}
