import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetIncomes, CreateIncome } from "../../managers/incomeManager";
import {
  Form,
  FormGroup,
  Input,
  Label,
  Button,
  Card,
  CardText,
  Container,
  CardTitle,
} from "reactstrap";

export default function CreateNewIncome({ setCurrentHouseholdId, loggedInUser }) {
  const { householdId } = useParams();
  const [income, setIncome] = useState([]);
  const [amount, setAmount] = useState("");
  const [source, setSource] = useState("");
  const [frequencyId, setFrequencyId] = useState("0");
  const [isFavorite, setIsFavorite] = useState(false);
  const [isFrequent, setIsFrequent] = useState(false);
  
  
  useEffect(() => {
    setCurrentHouseholdId(householdId);
    GetIncomes(householdId).then((data) => setIncome(data));
  }, [householdId, setCurrentHouseholdId]);

  const handleSubmit = (e) => {
    e.preventDefault();

    const newIncome = {
      amount: parseFloat(amount),
      source: source,
      frequencyId: frequencyId,
      isFrequent: isFrequent,
      isFavorite: isFavorite,
    };

    CreateIncome(householdId, newIncome).then(() => {
      setAmount("");
      setSource("");
      setFrequencyId("0");
      setIsFavorite(false);
      window.alert("Income added!");
      GetIncomes(householdId).then((data) => setIncome(data));
    });
  };

  return (
    <>
      <Container className="text-center">
        <h3 className="text-center">Add Income</h3>
        <Form onSubmit={handleSubmit}>
          <FormGroup>
            <Label for="amount">Amount</Label>
            <Input
              type="number"
              id="amount"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              required
            />
          </FormGroup>

          <FormGroup>
            <Label for="source">Source</Label>
            <Input
              type="text"
              id="source"
              value={source}
              onChange={(e) => setSource(e.target.value)}
              required
            />
          </FormGroup>

          <FormGroup check>
            <Label check>
              <Input
                type="checkbox"
                checked={isFrequent}
                onChange={(e) => setIsFrequent(e.target.checked)}
              />
              Recurring Income
            </Label>
          </FormGroup>

          {isFrequent && (
            <FormGroup>
              <Label for="frequency">Frequency</Label>
              <Input
                type="select"
                id="frequency"
                value={frequencyId}
                onChange={(e) => setFrequencyId(e.target.value)}
                required={isFrequent}
              >
                <option value="0">Select a frequency</option>
                <option value="1">Daily</option>
                <option value="2">Weekly</option>
                <option value="3">Bi-Weekly</option>
                <option value="4">Monthly</option>
                <option value="5">Quarterly</option>
                <option value="6">Annually</option>
              </Input>
            </FormGroup>
          )}

          <FormGroup check>
            <Label check>
              <Input
                type="checkbox"
                checked={isFavorite}
                onChange={(e) => setIsFavorite(e.target.checked)}
              />
              Favorite?
            </Label>
          </FormGroup>

          <div className="text-center">
            <Button type="submit">Add Income</Button>
          </div>
        </Form>
      </Container>

    
    </>
  );
}