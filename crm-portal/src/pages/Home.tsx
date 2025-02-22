import { useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/authContext";
import { signInWithGoogle } from "../firebaseConfig";
import { useEffect } from "react";

const handleLogin = async () => {
  try {
    await signInWithGoogle();
  } catch (error) {
    console.error("Error signing in with Google", error);
  }
};

function Home() {
  const navigate = useNavigate();
  const {currentUser} = useAuth();

  useEffect(() => {
    if (currentUser) {
      navigate('/dashboard');
    }
  }, [navigate, currentUser]);

  return (
    <>
      <div className="card">
        <button onClick={handleLogin}>
          {'Login with Google'}
        </button>
      </div>
      <>Home Page</>
    </>
  );
}

export default Home;