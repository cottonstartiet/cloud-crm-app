import { useState } from "react";
import { useEffect } from "react";
import { auth } from "../firebaseConfig";
import { User } from "firebase/auth";
import React from "react";
import { AuthContext } from "./authContext";


export function AuthProvider ({children}: {children: React.ReactNode}) {
  const [currentUser, setCurrentUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const unsubscribe = auth.onAuthStateChanged(user => {
      setCurrentUser(user);
      setLoading(false);
    });

    return unsubscribe;
  }, []);

  const value = {
    currentUser,
    loading
  }
  
  return (
    <AuthContext.Provider value={value}>
      {children}
    </AuthContext.Provider>
  );
}