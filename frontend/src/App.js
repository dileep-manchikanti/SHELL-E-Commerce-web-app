import './App.css';
import './components/Navbar';
import './components/signIn';
import SignIn from './components/signIn';
import Navbar from './components/Navbar';
import SignUp from './components/signUp';

function App() {
  return (
    <div className="App">
      {/* <Navbar />
      <SignIn /> */}
      <SignUp />
    </div>
  );
}

export default App;
