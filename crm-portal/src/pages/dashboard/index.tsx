import { useNavigate } from "react-router-dom";
import { logout } from "../../firebaseConfig";
import { useContext } from "react";
import { AuthContext } from "../../contexts/authContext";

function Dashboard() {

  const navigate = useNavigate();
  const authInfo = useContext(AuthContext);

  const handleLogout = () => {
    logout();
    navigate('/');
  }

  return (
    <>
    <h2>Welcome to the Dashboard</h2>
    <h1>{authInfo.currentUser?.displayName}</h1>
    <button onClick={handleLogout}>Logout</button>
    </>
  );
}

export default Dashboard;