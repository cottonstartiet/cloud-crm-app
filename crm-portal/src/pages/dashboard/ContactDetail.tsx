import { useParams } from "react-router-dom";

function ContactDetail() {
  const {id} = useParams();

  return (
    <div>
      <h1>Contact Detail</h1>
      <h1>Id: {id}</h1>
    </div>
  );
}

export default ContactDetail;