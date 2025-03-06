import { useState, useEffect } from "react";
import { getUserHouseholds } from "../managers/householdManager";
import { useNavigate } from "react-router-dom";
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Container, Card } from "reactstrap";

export default function Home() {
  const [households, setHouseholds] = useState([]);
  const [isOpen, setIsOpen] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    getUserHouseholds().then(data => setHouseholds(data));
  }, []);

  return (
    <Container>
      <h2>Welcome!</h2>
      <Card className="p-4">
        <h4>Select a Household</h4>
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
          <p>No households found.</p>
        )}
      </Card>
    </Container>
  );
}