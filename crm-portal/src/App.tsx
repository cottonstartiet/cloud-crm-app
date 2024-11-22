import { RouterProvider } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthProvider';
import router from './pages/routing/Routing';

function App() {
  return (
    <AuthProvider>
      <RouterProvider router={router}/>
    </AuthProvider>
  );
}

export default App;