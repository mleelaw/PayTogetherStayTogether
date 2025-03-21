import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetIncomes, CreateIncome } from "../../managers/incomeManager";
import {
  Form,
  FormGroup,
  Input,
  Label,
  Button,
  Container,
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

    CreateIncome(householdId, newIncome)
      .then(() => {
        window.alert("Income added!");
        setAmount("");
        setSource("");
        setFrequencyId("0");
        setIsFavorite(false);
        setIsFrequent(false);
        GetIncomes(householdId).then((data) => setIncome(data));
      })
      .catch(error => {
        console.error("Error creating income:", error);
        alert("Failed to add income. Please try again.");
      });
  };

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5">Add Income</h1>
      <div className="row justify-content-center">
        <div className="col-md-6">
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label for="amount" className="h5">Amount</Label>
              <Input
                type="number"
                id="amount"
                value={amount}
                onChange={(e) => setAmount(e.target.value)}
                className="form-control-lg"
                required
              />
            </FormGroup>

            <FormGroup>
              <Label for="source" className="h5">Source</Label>
              <Input
                type="text"
                id="source"
                value={source}
                onChange={(e) => setSource(e.target.value)}
                className="form-control-lg"
                required
              />
            </FormGroup>

            <FormGroup check className="mb-3">
              <Label check>
                <Input
                  type="checkbox"
                  checked={isFrequent}
                  onChange={(e) => setIsFrequent(e.target.checked)}
                />
                <span className="h5">Recurring Income</span>
              </Label>
            </FormGroup>

            {isFrequent && (
              <FormGroup>
                <Label for="frequency" className="h5">Frequency</Label>
                <Input
                  type="select"
                  id="frequency"
                  value={frequencyId}
                  onChange={(e) => setFrequencyId(e.target.value)}
                  className="form-control-lg"
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

            <FormGroup check className="mb-3">
              <Label check>
                <Input
                  type="checkbox"
                  checked={isFavorite}
                  onChange={(e) => setIsFavorite(e.target.checked)}
                />
                <span className="h5">Favorite?</span>
              </Label>
            </FormGroup>

            <div className="text-center">
              <Button 
                type="submit" 
                color="dark" 
                size="lg" 
                className="w-100"
              >
                Add Income
              </Button>
            </div>
          </Form>
        </div>
      </div>
    </Container>
  );
}