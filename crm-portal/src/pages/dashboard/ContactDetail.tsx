import { useParams } from "react-router-dom";
import { useGetContact } from "../../hooks/contactsApiHooks";
import Loading from "../components/Loading";

function ContactDetail() {
  const {id} = useParams();  

  const {isError, isSuccess, data, isLoading, error} = useGetContact(id as string);

  if (isLoading) {
    return <Loading/>;
  }

  if (isError) {
    return <div>Error: {JSON.stringify(error)}</div>;
  }

  if (isSuccess) {
    return (
      <div>
        <h1>Contact Detail</h1>
        <h1>Id: {data.id}</h1>
        <h1>First Name: {data.firstName}</h1>
        <h1>Last Name: {data.lastName}</h1>
      </div>
    );
  }
}

export default ContactDetail;