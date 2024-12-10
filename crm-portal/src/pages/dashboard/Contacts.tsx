import { Link } from "react-router-dom";
import Loading from "../components/Loading";
import { IContact } from "../../types";
import { useGetContacts } from "../../hooks/contactsApiHooks";

function Contacts() {
  const {isLoading, isSuccess, data} = useGetContacts();

  if (isLoading) {
    return <Loading/>;
  }

  if (isSuccess) {
    return (
      <div>
        <h1>All Contacts</h1>
        <h3>Click on a contact to edit it.</h3>
        {data.map((contact: IContact) => (
          <p key={contact.id}>
            <Link to={`${contact.id}`}>{contact.firstName} {contact.lastName}</Link>
          </p>
        ))}
      </div>
    );
  }
}

export default Contacts;