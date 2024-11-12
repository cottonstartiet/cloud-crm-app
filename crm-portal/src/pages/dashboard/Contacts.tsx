import { Link } from "react-router-dom";

function Contacts() {
  return (
    <div>
      <h1>All Contacts</h1>
      <h3>Click on a contact to edit it.</h3>
      <p><Link to={`${1}`} >Contact 1</Link></p>
      <p><Link to={`${2}`} >Contact 2</Link></p>
      <p><Link to={`${3}`} >Contact 3</Link></p>
    </div>
  );
}

export default Contacts;