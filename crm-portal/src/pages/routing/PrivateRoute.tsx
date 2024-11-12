import React from 'react';
import { Navigate } from 'react-router-dom';
import 'firebase/auth';
import { useAuth } from '../../contexts/authContext';
import Loading from '../components/Loading';

interface PrivateRouteProps {
  children: React.ReactNode;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ children }) => {
  const {currentUser, loading} = useAuth();

  if (loading) {
    return <Loading/>;
  }

  if (currentUser) {
    return children;
  }

  return <Navigate to="/" />;
};

export default PrivateRoute;