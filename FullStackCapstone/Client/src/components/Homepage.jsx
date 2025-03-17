import { useState, useEffect } from "react";
import { addNewHousehold, createNewHousehold, getAvailableUserHouseholds, getUserHouseholds } from "../managers/householdManager";
import { useNavigate } from "react-router-dom";
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Container, Card, Button, Alert, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from "reactstrap";
import { DeleteHouseholdUser } from "../managers/householdUserManager";

export default function Home() {
  const [households, setHouseholds] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const [isOpenTwo, setIsOpenTwo] = useState(false);
  const [isOpenThree, setIsOpenThree] = useState(false);
  const [availableHouseholds, setAvailableHouseholds] = useState([]);
  const [modalVis, setModalVis] = useState(false);
  const [modalVisTwo, setModalVisTwo] = useState(false);
  const [modalVisThree, setModalVisThree] = useState(false);
  const [household, setHousehold] = useState({ name: "" });
  const [householdClicked, setHouseholdClicked] = useState();
  const [householdNameClicked, setHouseholdNameClicked] = useState("");
  const [householdClickedThree, setHouseholdClickedThree] = useState();
  const [householdNameClickedThree, setHouseholdNameClickedThree] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    getUserHouseholds().then(data => setHouseholds(data));
    getAvailableUserHouseholds().then(data => setAvailableHouseholds(data));
  }, []);


  const handleHouseholdClick = (household) => {
    setHouseholdClicked(household.id);
    setHouseholdNameClicked(household.name);
    setModalVis(true);
  };

  const handleHouseholdClickThree= (household) => {
    setHouseholdClickedThree(household.id);
    setHouseholdNameClickedThree(household.name);
    setModalVisThree(true);
  };

  const confirmJoinHousehold = (householdClicked) => {
    addNewHousehold(householdClicked)
      .then(() => {
        getUserHouseholds().then(data => setHouseholds(data));
        getAvailableUserHouseholds().then(data => setAvailableHouseholds(data));
        setModalVis(false)
      })
  };

  const addHousehold = (household) => {
    createNewHousehold(household).then(() => {
      getUserHouseholds().then(data => setHouseholds(data));
      setModalVisTwo(false);
    });
  }

  const deleteMyselfFromHousehold = (householdClickedThree) => {
    DeleteHouseholdUser(householdClickedThree).then(() => {
      getUserHouseholds().then(data => setHouseholds(data));
      getAvailableUserHouseholds().then(data => setAvailableHouseholds(data));
      setModalVisThree(false);
    });
  }

  return (
    <Container>
      <h2>Welcome!</h2>
      <Card>
        <h4>Select a Household To View</h4>
        {households.length > 0 ? (
          <Dropdown isOpen={isOpen} toggle={() => setIsOpen(!isOpen)}>
            <DropdownToggle caret>Select Household</DropdownToggle>
            <DropdownMenu>
              {households.map(h => (
                <DropdownItem key={h.id} onClick={() => navigate(`/household/${h.id}`)}>
                  {h.name}
                </DropdownItem>
              ))}
            </DropdownMenu>
          </Dropdown>
        ) : (
          <p>Yopu currebnlty Are Not A Mmber Of A Household, Add Yourself To An Existing Household or Create A nNew Oe To Start Budgeting</p>
        )}
      </Card>
      <Card>
      <h4>Add Yourself to An Existing Household</h4>
      {availableHouseholds.length > 0 ? (
        <Dropdown isOpen={isOpenTwo} toggle={() => setIsOpenTwo(!isOpenTwo)}><DropdownToggle caret>Add Yourself to An Existing Household</DropdownToggle>
          <DropdownMenu>{availableHouseholds.map(h => (
            <DropdownItem key={h.id} onClick={() => handleHouseholdClick(h)}>
              {h.name} </DropdownItem>))}
          </DropdownMenu>
          </Dropdown>
      ) : (
        <p>No Other Households Available To Join</p>
      )}
      
      </Card>
      
      

        {/*remove */}

        <Card>
      <h4>Remove Myself From A household</h4>
      {households.length > 0 ? (
        <Dropdown isOpen={isOpenThree} toggle={() => setIsOpenThree(!isOpenThree)}><DropdownToggle caret>Remove Myself</DropdownToggle>
          <DropdownMenu>{households.map(h => (
            <DropdownItem key={h.id} onClick={() => handleHouseholdClickThree(h)}>
              {h.name} </DropdownItem>))}
          </DropdownMenu>
          </Dropdown>
      ) : (
        <p>No households to remove myself from</p>
      )}
      
      </Card>
      
      <Card>
  <Button onClick={() => setModalVisTwo(true)}>Create A New Household</Button>
</Card>
      

<>
      {/*Modal for adding myself to an existing house*/}
      <Modal isOpen={modalVis} toggle={() => setModalVis(!modalVis)}>
        <ModalHeader toggle={() => setModalVis(false)}>Are you sure you want to join this household?</ModalHeader>
        <ModalBody>{householdNameClicked}</ModalBody>
        <ModalFooter>
  <Button onClick={() => confirmJoinHousehold(householdClicked)}>
      Join
    </Button>{''}
    <Button onClick={() => setModalVis(false)}>
      Nevermind
    </Button>
  </ModalFooter>
      </Modal>
    
 
    {/*Modal for creating new house*/}
    <Modal isOpen={modalVisTwo} toggle={() => setModalVisTwo(!modalVisTwo)}>
    <ModalHeader toggle={() => setModalVisTwo(false)}>Create Household</ModalHeader>
        <ModalBody><Form>
        <FormGroup>
  <Label for="householdName">Household Name</Label>
  <Input 
    type="text"
    id="householdName"
    placeholder="Enter a name for your new household"
    value={household.name}
    onChange={(e) => setHousehold({ name: e.target.value })}
  />
</FormGroup></Form></ModalBody>
    <ModalFooter>
<Button onClick={() => addHousehold(household)}>
  Create Household  & Add me to it!
</Button>{''}
<Button onClick={() => setModalVisTwo(false)}>
  Nevermind
</Button>
</ModalFooter>
        </Modal>
        
         {/*Modal for removing myself to an existing house*/}
      <Modal isOpen={modalVisThree} toggle={() => setModalVisThree(!modalVisThree)}>
        <ModalHeader toggle={() => setModalVisThree(false)}>Are you sure you want to leave this household?</ModalHeader>
        <ModalBody>{householdNameClickedThree}</ModalBody>
        <ModalFooter>
  <Button onClick={() => deleteMyselfFromHousehold(householdClickedThree)}>
      Leave Household
    </Button>{''}
    <Button onClick={() => setModalVisThree(false)}>
      Nevermind
    </Button>
  </ModalFooter>
      </Modal>
      </>
</Container>
    
  );
}