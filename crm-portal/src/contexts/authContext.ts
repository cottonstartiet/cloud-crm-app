import { createContext, useContext } from "react";
import { IAuthContext } from "../types";

export const AuthContext = createContext<IAuthContext>({ currentUser: null, loading: true });

export function useAuth() {
  return useContext(AuthContext);
}
