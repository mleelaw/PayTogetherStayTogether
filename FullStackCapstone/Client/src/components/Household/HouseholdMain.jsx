import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Container, Card, CardText, CardTitle } from "reactstrap";
import { getExpenseTotalAmount } from "../../managers/householdManager";

export default function HouseholdDashboard({ setCurrentHouseholdId }) {
  const { householdId } = useParams();
  const [householdTotalExpense, setHouseholdTotalExpense] = useState();
  const [userExpenses, setUserExpenses] = useState([]);
  const [householdTotalIncome, setHouseholdTotalIncome] = useState();
  const [userIncomes, setUserIncomes] = useState([]);
  const [householdName, setHouseholdName] = useState("");
  const [budgetTotal, setBudgetTotal] = useState("");

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    
    if (householdId) {
      getExpenseTotalAmount(householdId).then((data) => {
        setHouseholdTotalExpense(data.householdTotalExpense);
        setUserExpenses(data.userExpenses);
        setHouseholdTotalIncome(data.householdTotalIncome);
        setUserIncomes(data.userIncomes);
        setHouseholdName(data.householdName);
        setBudgetTotal(data.budgetTotal);
      });
    }
  }, [householdId, setCurrentHouseholdId]);

  return (
    <Container>
      <Card>
        <CardTitle className="text-center">{householdName.name} Expense Overview</CardTitle>
        <CardText>
          Total for the Month:
          ${householdTotalExpense}
        </CardText>
        {userExpenses?.map((ue) => (
          <CardText key={ue.userId} value={ue.userId}>
            {ue.userName}'s Total: ${ue.userTotal}
          </CardText> 
        ))}
      </Card>
      <Card>
        <CardTitle className="text-center">{householdName.name} Income Overview</CardTitle>
        <CardText>
          Total for the Month:
          ${householdTotalIncome}
        </CardText>
        {userIncomes?.map((ui) => (
          <CardText key={ui.userId} value={ui.userId}>
            {ui.userName}'s Total: ${ui.userTotal}
          </CardText> 
        ))}
      </Card>
      <Card>
        <CardTitle className="text-center">{householdName.name} Budget Overview</CardTitle>
        <CardText>
          Percentage of Our Budget We have Spent: {budgetTotal}%
        </CardText>
      </Card>
    </Container>
  );
}
