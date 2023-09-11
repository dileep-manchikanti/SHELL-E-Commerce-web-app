import './App.css';
import './components/Navbar';
import './components/signIn';
import SignIn from './components/signIn';
import Navbar from './components/Navbar';

function App() {
  return (
    <div className="App">
      <Navbar />
      <SignIn />
    </div>
  );
}

export default App;
