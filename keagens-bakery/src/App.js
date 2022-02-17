import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar';
import Home from './components/Home';
import About from './components/About';
import Bakery from './components/Bakery';
import Login from './components/Login';

function App() {
  return (
    <Router>
    <Navbar/>
    <Routes>
      <Route path='/' element={<Home />} />
      <Route path = '/Bakery' element={<Bakery />} />
      <Route path='/About' element= {<About />} /> 
      <Route path='/Login' element= {<Login />} />
    </Routes>
    </Router>

  );
}

export default App;
