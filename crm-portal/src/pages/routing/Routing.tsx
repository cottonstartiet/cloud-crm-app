import { createBrowserRouter } from "react-router-dom";
import Home from "../Home";
import NotFound from "../NotFound";
import Dashboard from "../components/dashboard/Dashboard";

const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    errorElement: <NotFound/>
  },
  {
    path: '/dashboard',
    element: <Dashboard />
  },
  {
    path: '*',
    element: <NotFound/>
  }
]);


export default router;