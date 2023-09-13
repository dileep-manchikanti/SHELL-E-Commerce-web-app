import './App.css';
import './components/Navbar';
import './components/signIn';
import SignIn from './components/signIn';
import Navbar from './components/Navbar';
import SignUp from './components/signUp';
import Categories from './components/categories';

function App() {
  return (
    <div className="App">
      {/* <Navbar /> */}
      {/* <SignIn />  */}
      {/* <SignUp /> */}
      <Categories />
    </div>
  );
}

export default App;
