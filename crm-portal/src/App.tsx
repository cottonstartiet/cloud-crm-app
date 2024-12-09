import { RouterProvider } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthProvider';
import router from './pages/routing/Routing';
import { QueryClient, QueryClientProvider } from 'react-query';

function App() {
  const queryClient = new QueryClient();
  
  return (
    <QueryClientProvider client={queryClient}>
      <AuthProvider>
        <RouterProvider router={router}/>
      </AuthProvider>
    </QueryClientProvider>
  );
}

export default App;