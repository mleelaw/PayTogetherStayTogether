import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { GetExpenses, DeleteExpense } from "../../managers/expenseManager";
import {
  Button,
  Card,
  CardText,
  Container,
  CardTitle,
} from "reactstrap";

export default function ExpenseList({ setCurrentHouseholdId, loggedInUser }) {
  const { householdId } = useParams();
  const [expenses, setExpenses] = useState([]);
    const navigate = useNavigate();

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    GetExpenses(householdId).then((data) => setExpenses(data));
  }, [householdId, setCurrentHouseholdId]);

  const handleDeleteExpense = (expenseId) => {
    DeleteExpense(householdId, expenseId).then(() => {
      GetExpenses(householdId).then((data) => setExpenses(data));
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
    <Container className="text-center">
      <h3>Expense List</h3>

      {expenses.map((e) => (
        <Card key={e.id} className="text-center">
          <CardTitle>{formatDate(e.dateOfExpense)}</CardTitle>
          <CardText>
            ${e.amount} - {e.category?.name} - {e.description}
            {e.isRecurring ? " - Recurring Payment" : " - One-time Payment"}
            {e.frequency && ` (${e.frequency.description})`}
          </CardText>
          {e.purchasedByUserId === loggedInUser.id && (
            <div>
              <Button 
                onClick={() => handleDeleteExpense(e.id)}
              >
                Delete
              </Button>
              <Button
                onClick={() =>
                  navigate(
                    `/household/${householdId}/expense/create/${e.id}`
                  )
                }
              >
                Edit
              </Button>
            </div>
          )}
        </Card>
      ))}
    </Container>
  );
}