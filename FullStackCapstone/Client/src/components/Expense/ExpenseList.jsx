import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { GetExpenses, DeleteExpense } from "../../managers/expenseManager";
import {
  Button,
  Card,
  CardText,
  Container,
  CardTitle,
  Dropdown,
  DropdownItem,
  DropdownToggle,
  DropdownMenu,
} from "reactstrap";

export default function ExpenseList({ setCurrentHouseholdId, loggedInUser }) {
  const { householdId } = useParams();
  const [expenses, setExpenses] = useState([]);
  const [yearFilter, setYearFilter] = useState();
  const [dropdownYearOpen, setDropdownYearOpen] = useState(false);
  const [monthFilter, setMonthFilter] = useState();
  const [dropdownMonthOpen, setDropdownMonthOpen] = useState(false);

  const navigate = useNavigate();
  const years = [
    2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030,
  ];
  const months = [
    { value: 1, label: "January" },
    { value: 2, label: "February" },
    { value: 3, label: "March" },
    { value: 4, label: "April" },
    { value: 5, label: "May" },
    { value: 6, label: "June" },
    { value: 7, label: "July" },
    { value: 8, label: "August" },
    { value: 9, label: "September" },
    { value: 10, label: "October" },
    { value: 11, label: "November" },
    { value: 12, label: "December" },
  ];

  useEffect(() => {
    setCurrentHouseholdId(householdId);
    GetExpenses(householdId, monthFilter, yearFilter).then(setExpenses);
  }, [householdId, monthFilter, yearFilter, setCurrentHouseholdId]);

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

      <Dropdown
        isOpen={dropdownYearOpen}
        toggle={() => setDropdownYearOpen(!dropdownYearOpen)}
      >
        <DropdownToggle caret>
          {yearFilter ? `Year: ${yearFilter}` : "Select Year"}
        </DropdownToggle>
        <DropdownMenu>
          <DropdownItem
            onClick={() => {
              setYearFilter(null);
              setDropdownYearOpen(false);
            }}
          >
            All Years
          </DropdownItem>
          {years.map((year) => (
            <DropdownItem
              key={year}
              onClick={() => {
                setYearFilter(year);
                setDropdownYearOpen(false);
              }}
            >
              {year}
            </DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>

       <Dropdown
        isOpen={dropdownMonthOpen}
        toggle={() => setDropdownMonthOpen(!dropdownMonthOpen)}
      >
        <DropdownToggle caret>
          {monthFilter ? `Month: ${months.find((m) => m.value === monthFilter)?.label}` : "Select Month"}
        </DropdownToggle>
        <DropdownMenu>
          <DropdownItem
            onClick={() => {
              setMonthFilter(null);
              setDropdownMonthOpen(false);
            }}
          >
            All Months
          </DropdownItem>
          {months.map((month) => (
  <DropdownItem
    key={month.value}
    onClick={() => setMonthFilter(month.value)}
  >
    {month.label}
  </DropdownItem>
))}
        </DropdownMenu>
      </Dropdown>

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
              <Button onClick={() => handleDeleteExpense(e.id)}>Delete</Button>
              <Button
                onClick={() =>
                  navigate(`/household/${householdId}/expense/create/${e.id}`)
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
