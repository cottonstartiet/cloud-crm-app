import axios from "axios";
import { IContact } from "../types";

const API_BASE_URL = import.meta.env.VITE_FIREBASE_API_BASE_URL
const CONTACTS_URL = `${API_BASE_URL}/contacts`;

const axiosInstance = axios.create({
  baseURL: API_BASE_URL,
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});

export function getContacts(): Promise<IContact[]> {
  return axiosInstance.get(CONTACTS_URL).then((response) => response.data);
};

export function getContact(id: string): Promise<IContact> {
  return axiosInstance.get(`${CONTACTS_URL}/${id}`).then((response) => response.data);
};