import { User } from "firebase/auth";

export interface IAuthContext { currentUser: null | User, loading: boolean }