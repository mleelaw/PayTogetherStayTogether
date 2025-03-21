import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetCategories, UpdateCategory } from "../../managers/categoryManager";
import { GetRemainingBudgetByCategory } from "../../managers/categoryBudgetManger";
import {
  Card, CardBody, CardTitle, CardText, Container,
  Input, Button, FormGroup, Label, Form, Row, Col, Badge
} from "reactstrap";
import { formatCurrency } from "../formatDollar/formatdollar";

export default function BudgetList({ setCurrentHouseholdId }) {
  const { householdId } = useParams();
  const [categories, setCategories] = useState([]);
  const [editingCategory, setEditingCategory] = useState(null);
  const [editedBudget, setEditedBudget] = useState("");
  const [editedActive, setEditedActive] = useState(true);
  const [totalBudget, setTotalBudget] = useState(0);
  const [remainingBudgets, setRemainingBudgets] = useState({});
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchBudgetData = async () => {
    try {
      setIsLoading(true);
      setError(null);

      const categoryData = await GetCategories(householdId);
      const budgetData = await GetRemainingBudgetByCategory(householdId);

      const updatedRemainingBudgets = {};
      budgetData.forEach(budget => {
        updatedRemainingBudgets[budget.categoryId] = budget.remainingBudget;
      });

      const sortedCategories = categoryData.categories.sort((a, b) => 
        a.name.localeCompare(b.name)
      );

      setCategories(sortedCategories || []);
      setTotalBudget(categoryData.totalBudget || 0);
      setRemainingBudgets(updatedRemainingBudgets);
    } catch (err) {
      console.error("Error fetching budget data:", err);
      setError("Failed to load budget information");
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    fetchBudgetData();
  }, [householdId, setCurrentHouseholdId]);

  const handleEditClick = (category) => {
    setEditingCategory(category.id);
    setEditedBudget(category.categoryBudgetForTheMonth?.toString() || "");
    setEditedActive(category.isActive !== false);
  };

  const handleSaveClick = async (categoryId) => {
    try {
      const budgetAmount = parseFloat(editedBudget) || 0;
      
      const updatedCategory = {
        name: categories.find(c => c.id === categoryId).name,
        isActive: editedActive,
        budgetAmount: budgetAmount
      };
    
      await UpdateCategory(categoryId, householdId, updatedCategory);
      await fetchBudgetData();
      setEditingCategory(null);
    } catch (error) {
      console.error("Failed to update category:", error);
      alert("Failed to update budget. Please try again.");
    }
  };

  if (isLoading) return <div className="text-center py-5">Loading...</div>;
  if (error) return <div className="text-center text-danger py-5">{error}</div>;

  return (
    <Container className="py-5">
      <h1 className="text-center mb-4">Household Budget</h1>
      <h2 className="text-center mb-5">
        {new Date().toLocaleString("default", { month: "long" })} {new Date().getFullYear()}
      </h2>
      
      <div className="row justify-content-center mb-4">
        <div className="col-md-6">
          <Card className="text-center shadow">
            <CardBody>
              <CardTitle className="h4">Total Monthly Budget</CardTitle>
              <CardText className="h3">{formatCurrency(totalBudget)}</CardText>
            </CardBody>
          </Card>
        </div>
      </div>

      <h2 className="text-center mb-4">Category Budgets</h2>
      <Row className="row-cols-1 row-cols-md-3 g-4">
        {categories.map(category => {
          const isInactive = category.isActive === false;
          return (
            <Col key={category.id}>
              <Card 
                className={`shadow h-100 ${isInactive ? 'border-secondary' : ''}`}
                style={{ 
                  opacity: isInactive ? 0.6 : 1,
                  backgroundColor: isInactive ? '#f8f9fa' : 'white'
                }}
              >
                <CardBody>
                  <CardTitle tag="h4" className="text-center mb-3">
                    {category.name}
                    {isInactive && (
                      <Badge 
                        color="secondary" 
                        className="ms-2"
                      >
                        Inactive
                      </Badge>
                    )}
                  </CardTitle>
                  {editingCategory === category.id ? (
                    <Form>
                      <FormGroup>
                        <Label for={`budget-${category.id}`} className="h5">Budget Amount</Label>
                        <Input
                          id={`budget-${category.id}`}
                          type="number"
                          min="0"
                          step="0.01"
                          value={editedBudget}
                          onChange={(e) => setEditedBudget(e.target.value)}
                          className="form-control-lg"
                        />
                      </FormGroup>
                      <FormGroup check className="mb-3">
                        <Label check>
                          <Input
                            type="checkbox"
                            checked={editedActive}
                            onChange={(e) => setEditedActive(e.target.checked)}
                          />
                          <span className="h5">Active</span>
                        </Label>
                      </FormGroup>
                      <div className="d-flex justify-content-center">
                        <Button 
                          color="dark" 
                          className="me-2" 
                          onClick={() => handleSaveClick(category.id)}
                        >
                          Save
                        </Button>
                        <Button 
                          color="secondary" 
                          onClick={() => setEditingCategory(null)}
                        >
                          Cancel
                        </Button>
                      </div>
                    </Form>
                  ) : (
                    <>
                      <CardText className="text-center">
                        <h5>Budget:</h5> 
                        <p className="h4">{formatCurrency(category.categoryBudgetForTheMonth)}</p>
                      </CardText>
                      <CardText className="text-center">
                        <h5>Remaining Budget:</h5> 
                        <p className="h4">{formatCurrency(remainingBudgets[category.id])}</p>
                      </CardText>
                      <div className="text-center">
                        <Button 
                          color="dark" 
                          onClick={() => handleEditClick(category)}
                        >
                          Edit
                        </Button>
                      </div>
                    </>
                  )}
                </CardBody>
              </Card>
            </Col>
          );
        })}
      </Row>
    </Container>
  );
}