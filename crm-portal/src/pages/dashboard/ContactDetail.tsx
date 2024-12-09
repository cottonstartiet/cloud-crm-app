import { useParams } from "react-router-dom";
import { useGetContact } from "../../hooks/contactsApiHooks";
import Loading from "../components/Loading";

function ContactDetail() {
  const {id} = useParams();  

  const response = useGetContact(id as string);

  if (response.isLoading) {
    return <Loading/>;
  }

  if (response.isError) {
    return <div>Error: {JSON.stringify(response.error)}</div>;
  }

  if (response.isSuccess) {
    return (
      <div>
        <h1>Contact Detail</h1>
        <h1>Id: {response.data.id}</h1>
        <h1>First Name: {response.data.firstName}</h1>
        <h1>Last Name: {response.data.lastName}</h1>
      </div>
    );
  }
}

export default ContactDetail;