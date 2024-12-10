import { RouterProvider } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthProvider';
import router from './pages/routing/Routing';
import { QueryClient, QueryClientProvider } from 'react-query';

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <AuthProvider>
        <RouterProvider router={router}/>
      </AuthProvider>
    </QueryClientProvider>
  );
}

export default App;