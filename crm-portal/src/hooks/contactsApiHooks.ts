import { useQuery } from "react-query";
import { getContact, getContacts } from "../services/contactsService";

export function useGetContacts() {
  return useQuery({
    queryKey: ["contacts"],
    queryFn: () => getContacts(),
    refetchOnWindowFocus: false,
  });
}

export function useGetContact(id: string) {
  return useQuery({
    queryKey: ["contact", id],
    queryFn: () => getContact(id),
    refetchOnWindowFocus: false,
  });
}