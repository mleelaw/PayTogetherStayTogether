import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Container, Card, CardText, CardTitle, Row, Col } from "reactstrap";
import { getExpenseTotalAmount } from "../../managers/householdManager";
import ExpensePieChart from "./HouseholdDashboardChart";

export default function HouseholdDashboard({ setCurrentHouseholdId }) {
  const { householdId } = useParams();
  const [householdTotalExpense, setHouseholdTotalExpense] = useState();
  const [userExpenses, setUserExpenses] = useState([]);
  const [householdTotalIncome, setHouseholdTotalIncome] = useState();
  const [userIncomes, setUserIncomes] = useState([]);
  const [householdName, setHouseholdName] = useState("");
  const [budgetTotal, setBudgetTotal] = useState("");
  const [householdMembers, setHouseholdMembers] = useState([]);

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    
    if (householdId) {
      getExpenseTotalAmount(householdId).then((data) => {
        setHouseholdTotalExpense(data.householdTotalExpense);
        setUserExpenses(data.userExpenses);
        setHouseholdTotalIncome(data.householdTotalIncome);
        setUserIncomes(data.userIncomes);
        setHouseholdName(data.householdName);
        setHouseholdMembers(data.householdMembers)
        setBudgetTotal(data.budgetTotal);
      });
    }
  }, [householdId, setCurrentHouseholdId]);

  return (
    <Container className="py-5">
      <h1 className="text-center mb-5 text-dark">{householdName.name}</h1>
      
      <Row className="g-4">
        <Col md={6}>
          <Card className="p-4 shadow h-100">
            <CardTitle className="h4 mb-4 text-center">Current Household Members</CardTitle>
            {householdMembers?.map((hm) => (
              <CardText key={hm.Id} className="text-center" value={hm.Id}>
                {hm.firstName}
              </CardText> 
            ))}
          </Card>
        </Col>
        
        <Col md={6}>
          <Card className="p-4 shadow h-100">
            <CardTitle className="h4 mb-4 text-center">Expense Overview</CardTitle>
            <CardText className="text-center h5">
              Total for the Month: ${householdTotalExpense}
            </CardText>
            {userExpenses?.map((ue) => (
              <CardText key={ue.userId} className="text-center" value={ue.userId}>
                {ue.userName}'s Total: ${ue.userTotal}
              </CardText> 
            ))}
          </Card>
        </Col>
        
        <Col md={6}>
          <Card className="p-4 shadow h-100">
            <CardTitle className="h4 mb-4 text-center">Income Overview</CardTitle>
            <CardText className="text-center h5">
              Total for the Month: ${householdTotalIncome}
            </CardText>
            {userIncomes?.map((ui) => (
              <CardText key={ui.userId} className="text-center" value={ui.userId}>
                {ui.userName}'s Total: ${ui.userTotal}
              </CardText> 
            ))}
          </Card>
        </Col>
        
        <Col md={6}>
          <Card className="p-4 shadow h-100">
            <CardTitle className="h4 mb-4 text-center">Budget Overview</CardTitle>
            <CardText className="text-center h5">
              Percentage of Budget Spent: {budgetTotal}%
            </CardText>
            <div className="d-flex justify-content-center">
              <ExpensePieChart budgetTotal={budgetTotal} />
            </div>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}