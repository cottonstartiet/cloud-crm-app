import { createBrowserRouter } from "react-router-dom";
import Home from "../Home";
import NotFound from "../NotFound";
import PrivateRoute from "./PrivateRoute";
import Dashboard from "../dashboard";
import Contacts from "../dashboard/Contacts";
import ContactDetail from "../dashboard/ContactDetail";

const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    errorElement: <NotFound/>
  },
  {
    path: '/dashboard',
    element: <PrivateRoute children={<Dashboard />} />,   
    children: [
      {
        path: 'contacts',
        element: <PrivateRoute children={<Contacts/>} />,
      },
      {
        path: 'contacts/:id',
        element: <PrivateRoute children={<ContactDetail/>} />,
      }
    ]
  },
  {
    path: '*',
    element: <NotFound/>
  }
]);


export default router;