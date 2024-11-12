import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import './App.css';
import Home from './pages/Home';
import { AuthProvider } from './contexts/AuthProvider';
import NotFound from './pages/NotFound';
import Dashboard from './pages/dashboard';
import PrivateRoute from './pages/routing/PrivateRoute';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    errorElement: <NotFound/>
  },
  {
    path: '/dashboard',
    element: <PrivateRoute children={<Dashboard />} />,
  },
]);

function App() {
  return (
    <AuthProvider>
      <RouterProvider router={router}/>
    </AuthProvider>
  );
}



export default App;