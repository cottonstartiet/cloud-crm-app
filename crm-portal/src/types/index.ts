import { User } from "firebase/auth";

export interface IAuthContext { currentUser: null | User, loading: boolean }

export interface IContact {
  id: string;
  firstName: string;
  lastName : string;
}