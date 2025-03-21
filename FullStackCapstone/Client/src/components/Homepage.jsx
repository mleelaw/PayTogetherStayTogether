import { useState, useEffect } from "react";
import {
  addNewHousehold,
  createNewHousehold,
  getAvailableUserHouseholds,
  getUserHouseholds,
} from "../managers/householdManager";
import { useNavigate } from "react-router-dom";
import {
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Container,
  Card,
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Form,
  FormGroup,
  Label,
  Input,
} from "reactstrap";
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
  const [householdNameClickedThree, setHouseholdNameClickedThree] =
    useState("");
  const navigate = useNavigate();

  useEffect(() => {
    getUserHouseholds().then((data) => setHouseholds(data));
    getAvailableUserHouseholds().then((data) => setAvailableHouseholds(data));
  }, []);

  const handleHouseholdClick = (household) => {
    setHouseholdClicked(household.id);
    setHouseholdNameClicked(household.name);
    setModalVis(true);
  };

  const handleHouseholdClickThree = (household) => {
    setHouseholdClickedThree(household.id);
    setHouseholdNameClickedThree(household.name);
    setModalVisThree(true);
  };

  const confirmJoinHousehold = (householdClicked) => {
    addNewHousehold(householdClicked).then(() => {
      getUserHouseholds().then((data) => setHouseholds(data));
      getAvailableUserHouseholds().then((data) => setAvailableHouseholds(data));
      setModalVis(false);
    });
  };

  const addHousehold = (household) => {
    createNewHousehold(household).then(() => {
      getUserHouseholds().then((data) => setHouseholds(data));
      setModalVisTwo(false);
    });
  };

  const deleteMyselfFromHousehold = (householdClickedThree) => {
    DeleteHouseholdUser(householdClickedThree).then(() => {
      getUserHouseholds().then((data) => setHouseholds(data));
      getAvailableUserHouseholds().then((data) => setAvailableHouseholds(data));
      setModalVisThree(false);
    });
  };

  return (
    <Container className="text-center py-5">
      <h1 className="mb-5">Welcome!</h1>
      <div className="row justify-content-center">
        <div className="col-md-6 mb-4">
          <Card className="p-4 shadow h-100">
            <h2 className="mb-4">Choose Your Household</h2>
            {households.length > 0 ? (
              <Dropdown
                isOpen={isOpen}
                toggle={() => setIsOpen(!isOpen)}
                className="d-inline-block"
              >
                <DropdownToggle caret className="px-3 py-1 bg-primary-subtle text-dark">
                  Select Household
                </DropdownToggle>
                <DropdownMenu className="text-center">
                  {households.map((h) => (
                    <DropdownItem
                      key={h.id}
                      onClick={() => navigate(`/household/${h.id}`)}
                      className="text-center"
                    >
                      {h.name}
                    </DropdownItem>
                  ))}
                </DropdownMenu>
              </Dropdown>
            ) : (
              <p className="h5">
                You currently are not a member of a household.
              </p>
            )}
          </Card>
        </div>
        <div className="col-md-6 mb-4">
          <Card className="p-4 shadow h-100">
            <h2 className="mb-4">Join Another Household</h2>
            {availableHouseholds.length > 0 ? (
              <Dropdown
                isOpen={isOpenTwo}
                toggle={() => setIsOpenTwo(!isOpenTwo)}
                className="d-inline-block"
              >
                <DropdownToggle caret className="px-3 py-1 bg-primary-subtle text-dark">
                  Select Household to Join
                </DropdownToggle>
                <DropdownMenu className="text-center">
                  {availableHouseholds.map((h) => (
                    <DropdownItem
                      key={h.id}
                      onClick={() => handleHouseholdClick(h)}
                      className="text-center"
                    >
                      {h.name}
                    </DropdownItem>
                  ))}
                </DropdownMenu>
              </Dropdown>
            ) : (
              <p className="h5">No Other Households Available To Join</p>
            )}
          </Card>
        </div>
        <div className="col-md-6 mb-4">
          <Card className="p-4 shadow h-100">
            <h2 className="mb-4">Leave a Household</h2>
            {households.length > 0 ? (
              <Dropdown
                isOpen={isOpenThree}
                toggle={() => setIsOpenThree(!isOpenThree)}
                className="d-inline-block"
              >
                <DropdownToggle caret className="px-3 py-1 bg-primary-subtle text-dark">
                  Select Household to Leave
                </DropdownToggle>
                <DropdownMenu className="text-center">
                  {households.map((h) => (
                    <DropdownItem
                      key={h.id}
                      onClick={() => handleHouseholdClickThree(h)}
                      className="text-center"
                    >
                      {h.name}
                    </DropdownItem>
                  ))}
                </DropdownMenu>
              </Dropdown>
            ) : (
              <p className="h5">No households to remove yourself from</p>
            )}
          </Card>
        </div>
        <div className="col-md-6 mb-4">
          <Card className="p-4 shadow h-100">
            <Button
              onClick={() => setModalVisTwo(true)}
              size="lg"
              className="w-100 bg-primary-subtle text-dark"
            >
              Start a New Household
            </Button>
          </Card>
        </div>
      </div>

      <Modal isOpen={modalVis} toggle={() => setModalVis(!modalVis)} size="lg">
        <ModalHeader toggle={() => setModalVis(false)}>
          Join Household
        </ModalHeader>
        <ModalBody className="h5">
          Are you sure you want to join: {householdNameClicked}?
        </ModalBody>
        <ModalFooter>
          <Button
            color="dark"
            size="lg"
            onClick={() => confirmJoinHousehold(householdClicked)}
          >
            Join
          </Button>
          <Button
            color="secondary"
            size="lg"
            onClick={() => setModalVis(false)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>

      <Modal
        isOpen={modalVisTwo}
        toggle={() => setModalVisTwo(!modalVisTwo)}
        size="lg"
      >
        <ModalHeader toggle={() => setModalVisTwo(false)}>
          Create Household
        </ModalHeader>
        <ModalBody>
          <Form>
            <FormGroup>
              <Label for="householdName" className="h5">
                Household Name
              </Label>
              <Input
                type="text"
                id="householdName"
                placeholder="Enter a name for your new household"
                value={household.name}
                onChange={(e) => setHousehold({ name: e.target.value })}
                size="lg"
              />
            </FormGroup>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button
            color="dark"
            size="lg"
            onClick={() => addHousehold(household)}
          >
            Create Household
          </Button>
          <Button
            color="secondary"
            size="lg"
            onClick={() => setModalVisTwo(false)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>

      <Modal
        isOpen={modalVisThree}
        toggle={() => setModalVisThree(!modalVisThree)}
        size="lg"
      >
        <ModalHeader toggle={() => setModalVisThree(false)}>
          Leave Household
        </ModalHeader>
        <ModalBody className="h5">
          Are you sure you want to leave: {householdNameClickedThree}?
        </ModalBody>
        <ModalFooter>
          <Button
            color="danger"
            size="lg"
            onClick={() => deleteMyselfFromHousehold(householdClickedThree)}
          >
            Leave Household
          </Button>
          <Button
            color="secondary"
            size="lg"
            onClick={() => setModalVisThree(false)}
          >
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
    </Container>
  );
}