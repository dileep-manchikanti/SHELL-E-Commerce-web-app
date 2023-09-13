import './App.css';
import { BrowserRouter, Route, Routes,Link } from 'react-router-dom';

import SignIn from './components/signIn';
import Navbar from './components/Navbar';
import SignUp from './components/signUp';
import Categories from './components/categories';

function App() {
  return (
    <BrowserRouter>
      <Routes>
          <Route path="/" exact  element={<SignIn />}/>
          <Route path="/signUp" element={<SignUp />} />
          <Route path="/categories" element={<Categories />} />
      </Routes>
    </BrowserRouter>
  );
}
export default App;
