import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetCategories, UpdateCategory } from "../../managers/categoryManager";

import {
  Card,
  CardBody,
  CardTitle,
  CardText,
  Container,
  Input,
  Button,
  FormGroup,
  Label,
  Form,
  Row,
  Col,
} from "reactstrap";
import { GetRemainingBudgetByCategory } from "../../managers/categoryBudgetManger";

export default function BudgetList({ setCurrentHouseholdId }) {
  const { householdId } = useParams();
  const [categories, setCategories] = useState([]);
  const [editingCategory, setEditingCategory] = useState(null);
  const [editedBudget, setEditedBudget] = useState("");
  const [editedActive, setEditedActive] = useState(true);
  const [totalBudget, setTotalBudget] = useState(0);
  const [remainingbudgets, setRemainingBudgets] = useState({
    1: 0, // Rent
    2: 0, // Groceries
    3: 0, // PetExpense
  });

  useEffect(() => {
    setCurrentHouseholdId(householdId);

    GetRemainingBudgetByCategory(householdId).then((data) => {
      const updatedBudgetsRemaining = { ...remainingbudgets };
      data.forEach((categoryBudget) => {
        if (updatedBudgetsRemaining.hasOwnProperty(categoryBudget.categoryId)) {
          updatedBudgetsRemaining[categoryBudget.categoryId] =
            categoryBudget.remainingBudget;
        }
      });
      setRemainingBudgets(updatedBudgetsRemaining);
    });

    GetCategories(householdId).then((data) => {
      setCategories(data.categories);
      setTotalBudget(data.totalBudget);
    });
  }, [householdId, setCurrentHouseholdId]);

  const handleEditClick = (category) => {
    setEditingCategory(category.id);
    setEditedBudget(category.categoryBudgetForTheMonth);
    setEditedActive(category.isActive);
  };

  const handleSaveClick = (categoryId) => {
    const updatedCategory = {
      name: categories.find((c) => c.id === categoryId).name,
      isActive: editedActive,
      categoryBudgetForTheMonth: parseFloat(editedBudget),
    };
  
    UpdateCategory(categoryId, householdId, updatedCategory).then(() => {
      
      setCategories(
        categories.map((c) => {
          if (c.id === categoryId) {
            return {
              ...c,
              categoryBudgetForTheMonth: parseFloat(editedBudget),
              isActive: editedActive,
            };
          }
          return c;
        })
      );
  
      
      GetRemainingBudgetByCategory(householdId).then((data) => {
        const updatedBudgetsRemaining = { ...remainingbudgets };
        data.forEach((categoryBudget) => {
          if (updatedBudgetsRemaining.hasOwnProperty(categoryBudget.categoryId)) {
            updatedBudgetsRemaining[categoryBudget.categoryId] =
              categoryBudget.remainingBudget;
          }
        });
        setRemainingBudgets(updatedBudgetsRemaining);
      });
  

      setEditingCategory(null);
    });
  };

  const handleCancelClick = () => {
    setEditingCategory(null);
  };

  return (
    <Container>
      <h1 className="text-center">Household Budget</h1>
      <h2 className="text-center">
  
  {new Date().toLocaleString("default", { month: "long" })} {new Date().getFullYear()}
</h2>
      <Card className="text-center">
        <CardBody>
          <CardTitle>Total Monthly Budget</CardTitle>
         
          <CardText>${totalBudget.toFixed(2)}</CardText>
        </CardBody>
      </Card>
      <h2 className="text-center">Category Budgets</h2>
      <Row>
        {categories.map((category) => (
          <Col key={category.id}>
            <Card>
              <CardBody>
                <CardTitle>{category.name}</CardTitle>
                {editingCategory === category.id ? (
                  <Form>
                    <FormGroup>
                      <Label for={`budget-${category.id}`}>Budget Amount</Label>
                      <Input
                        id={`budget-${category.id}`}
                        type="number"
                        value={editedBudget}
                        onChange={(e) => setEditedBudget(e.target.value)}
                      />
                    </FormGroup>
                    <FormGroup check>
                      <Label check>
                        <Input
                          type="checkbox"
                          checked={editedActive}
                          onChange={(e) => setEditedActive(e.target.checked)}
                        />
                        Active
                      </Label>
                    </FormGroup>
                    <Button onClick={() => handleSaveClick(category.id)}>
                      Save
                    </Button>
                    <Button onClick={handleCancelClick}>Cancel</Button>
                  </Form>
                ) : (
                  <>
                    <CardText>
                      <h6>Budget:</h6> $
                      {category.categoryBudgetForTheMonth?.toFixed(2) || "0.00"}
                    </CardText>
                    <CardText>
                      <h6>Remaining Budget:</h6> $
                      {remainingbudgets[category.id]?.toFixed(2) || "0.00"}
                    </CardText>
                    <CardText>
                      <h6>Status:</h6> {category.isActive ? "Active" : "Inactive"}
                    </CardText>
                    <Button onClick={() => handleEditClick(category)}>Edit</Button>
                  </>
                )}
              </CardBody>
            </Card>
          </Col>
        ))}
      </Row>
    </Container>
  );
}
