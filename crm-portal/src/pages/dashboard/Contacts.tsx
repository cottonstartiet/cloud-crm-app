import { Link } from "react-router-dom";
import Loading from "../components/Loading";
import { IContact } from "../../types";
import { useGetContacts } from "../../hooks/contactsApiHooks";

function Contacts() {
  const response = useGetContacts();

  if (response.isLoading) {
    return <Loading/>;
  }

  if (response.isSuccess) {
    return (
      <div>
        <h1>All Contacts</h1>
        <h3>Click on a contact to edit it.</h3>
        {response.data.map((contact: IContact) => (
          <p key={contact.id}>
            <Link to={`${contact.id}`}>{contact.firstName} {contact.lastName}</Link>
          </p>
        ))}
      </div>
    );
  }
}

export default Contacts;