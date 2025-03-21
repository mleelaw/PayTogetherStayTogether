import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const [currentHouseholdId, setCurrentHouseholdId] = useState(null);

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);
  
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar 
        loggedInUser={loggedInUser} 
        setLoggedInUser={setLoggedInUser} 
        currentHouseholdId={currentHouseholdId}
        setCurrentHouseholdId={setCurrentHouseholdId}
      />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
        setCurrentHouseholdId={setCurrentHouseholdId}
      />
    </>
  );
}
export default App;