import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { GetExpenses, CreateNewExpense, DeleteExpense, GetExpenseById, UpdateExpense } from "../../managers/expenseManager";
import { GetCategories } from "../../managers/categoryManager";
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

export default function CreateExpense({ setCurrentHouseholdId, loggedInUser }) {
  const { householdId, expenseId } = useParams();
  const isEditing = expenseId !== undefined;
  const [expenses, setExpenses] = useState([]);
  const [categories, setCategories] = useState([]);
  const [amount, setAmount] = useState("");
  const [categoryId, setCategoryId] = useState("0");
  const [description, setDescription] = useState("");
  const [dateOfExpense, setDateOfExpense] = useState("");
  const [frequencyId, setFrequencyId] = useState("0");
  const [isFavorite, setIsFavorite] = useState(false);
  const [isRecurring, setIsRecurring] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    GetExpenses(householdId).then((data) => setExpenses(data));
    GetCategories(householdId).then((data) => setCategories(data.categories))

    if (isEditing) {
      GetExpenseById(householdId, expenseId).then((expense) => {

        setAmount(expense.amount);
        setCategoryId(expense.categoryId.toString());
        setDescription(expense.description);
        setDateOfExpense(expense.dateOfExpense.split('T')[0]); // date from api is coming back inISO format this is grabbing just the xx/xx/xxxx part of this.
        setIsRecurring(expense.isRecurring);
        setFrequencyId(expense.frequencyId ? expense.frequencyId.toString() : "0");
        setIsFavorite(expense.isFavorite);
      });
    }
  }, [householdId, expenseId, setCurrentHouseholdId]);
    

  const handleSubmit = (e) => {
    e.preventDefault();
  
    const expenseData = {
      householdId: parseInt(householdId),
      amount: parseFloat(amount),
      categoryId: parseInt(categoryId),
      description: description,
      dateOfExpense: dateOfExpense,
      purchasedByUserId: loggedInUser.id,
      isRecurring: isRecurring,
      frequencyId: isRecurring ? parseInt(frequencyId) : null,
      isFavorite: isFavorite,
    };
  
    if (isEditing) {
      UpdateExpense(householdId, expenseId, expenseData).then(() => {
        window.alert("Expense updated!");
        navigate(`/household/${householdId}/expense`);
      });
    } else {
      CreateNewExpense(householdId, expenseData).then(() => {
        window.alert("Expense added!");
      });
    }
  };

  // const handleDeleteExpense = (expenseId) => {
  //   DeleteExpense(householdId, expenseId).then(() => {
  //     GetExpenses(householdId).then((data) => setExpenses(data));
  //   });
  // };
 
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
      <h3 className="text-center">{isEditing ? "Edit Expense" : "Add Expense"}</h3>
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
            <Label for="category">Category</Label>
            <Input
              type="select"
              id="category"
              value={categoryId}
              onChange={(e) => setCategoryId(e.target.value)}
              required
            >
              <option value="0">Select a category</option>
              {categories.map((c) => (
                <option key={c.id} value={c.id}>
                  {c.name}
                </option>
              ))}
            </Input>
          </FormGroup>

          <FormGroup>
            <Label for="description">Description</Label>
            <Input
              type="text"
              id="description"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              required
            />
          </FormGroup>

          <FormGroup>
            <Label for="dateOfExpense">Date of Expense</Label>
            <Input
              type="date"
              id="dateOfExpense"
              value={dateOfExpense}
              onChange={(e) => setDateOfExpense(e.target.value)}
              required
            />
          </FormGroup>

          <FormGroup check>
            <Label check>
              <Input
                type="checkbox"
                checked={isRecurring}
                onChange={(e) => setIsRecurring(e.target.checked)}
              />
              Recurring Expense?
            </Label>
          </FormGroup>

          {isRecurring && (
            <FormGroup>
              <Label for="frequency">Frequency</Label>
              <Input
                type="select"
                id="frequency"
                value={frequencyId}
                onChange={(e) => setFrequencyId(e.target.value)}
                required={isRecurring}
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
          <Button type="submit">{isEditing ? "Update Expense" : "Add Expense"}</Button>
          </div>
        </Form>
      </Container>

      
     
    </>
  );
}