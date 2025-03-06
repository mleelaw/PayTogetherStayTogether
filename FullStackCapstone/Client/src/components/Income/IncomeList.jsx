import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetIncomes, CreateIncome, DeleteIncome } from "../../managers/incomeManager";
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

export default function IncomeList({ setCurrentHouseholdId, loggedInUser }) {
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

    //REMINDER look into propertyshorthand on these
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

  const handleDeleteIncome = (incomeId) => {
    DeleteIncome(householdId, incomeId).then(() => {
      GetIncomes(householdId).then((data) => setIncome(data));
    });
  };
 
  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const day = date.getDate().toString().padStart(2, "0");
    const year = date.getFullYear();
    return `${month}/${day}/${year}`;
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

      <Container className="text-center">
        <h3>Income List</h3>

        {income.map((i) => (
          <Card key={i.id} className="text-center">
            <CardTitle>{formatDate(i.incomeCreatedDate)}</CardTitle>
            <CardText>
              ${i.amount} - {i.source}
              {i.frequency && ` (${i.frequency.description})`}
            </CardText>
            {i.createdById === loggedInUser.id && 
              <Button onClick={() => handleDeleteIncome(i.id)}>
                Delete
              </Button>
            }
          </Card>
        ))}
      </Container>
    </>
  );
}