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
  Container,
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
        setDateOfExpense(expense.dateOfExpense.split('T')[0]);
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
      CreateNewExpense(householdId, expenseData)
      .then(() => {
        window.alert("Expense added!");
        navigate(`/household/${householdId}/expense`)
        setAmount("");
        setDescription("");
        setCategoryId("0");
        setDateOfExpense("");
        GetExpenses(householdId).then(data => setExpenses(data));
      })
      .catch(error => {
        console.error("Error creating expense:", error);
        alert("Failed to add expense. Please try again.");
      });
    }
  };

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5">
        {isEditing ? "Edit Expense" : "Add Expense"}
      </h1>
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
              <Label for="category" className="h5">Category</Label>
              <Input
                type="select"
                id="category"
                value={categoryId}
                onChange={(e) => setCategoryId(e.target.value)}
                className="form-control-lg"
                required
              >
                <option value="0">Select a category</option>
                {categories && categories.length > 0 ? (
                  categories.map(category => (
                    <option key={category.id} value={category.id}>
                      {category.name}
                    </option>
                  ))
                ) : (
                  <option value="">No categories available</option>
                )}
              </Input>
            </FormGroup>

            <FormGroup>
              <Label for="description" className="h5">Description</Label>
              <Input
                type="text"
                id="description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                className="form-control-lg"
                required
              />
            </FormGroup>

            <FormGroup>
              <Label for="dateOfExpense" className="h5">Date of Expense</Label>
              <Input
                type="date"
                id="dateOfExpense"
                value={dateOfExpense}
                onChange={(e) => setDateOfExpense(e.target.value)}
                className="form-control-lg"
                max={new Date().toISOString().split('T')[0]} 
                required
              />
            </FormGroup>

            <FormGroup check className="mb-3">
              <Label check>
                <Input
                  type="checkbox"
                  checked={isRecurring}
                  onChange={(e) => setIsRecurring(e.target.checked)}
                />
                <span className="h5">Recurring Expense?</span>
              </Label>
            </FormGroup>

            {isRecurring && (
              <FormGroup>
                <Label for="frequency" className="h5">Frequency</Label>
                <Input
                  type="select"
                  id="frequency"
                  value={frequencyId}
                  onChange={(e) => setFrequencyId(e.target.value)}
                  className="form-control-lg"
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
                {isEditing ? "Update Expense" : "Add Expense"}
              </Button>
            </div>
          </Form>
        </div>
      </div>
    </Container>
  );
}