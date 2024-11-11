import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import { signInWithGoogle, auth } from './firebaseConfig';
import { onAuthStateChanged, User } from 'firebase/auth';
import './App.css';

function App() {
  const [user, setUser] = useState<null | User>(null);

  onAuthStateChanged(auth, (currentUser) => {
    setUser(currentUser);
  });

  const handleLogin = async () => {
    try {
      await signInWithGoogle();
    } catch (error) {
      console.error("Error signing in with Google", error);
    }
  };

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home handleLogin={handleLogin} user={user} />} />
        <Route path="/dashboard" element={user ? <Dashboard /> : <Navigate to="/" />} />
      </Routes>
    </Router>
  );
}

function Home({ handleLogin, user }: { handleLogin: () => void, user: User | null }) {
  console.log('user', user);
  return (
    <>
      <div className="card">
        <button onClick={handleLogin}>
          {user ? `Logged in as ${user.displayName}` : 'Login with Google'}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  );
}

function Dashboard() {
  return <h2>Welcome to the Dashboard</h2>;
}

export default App;