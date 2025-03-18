import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import ExpenseList from "./Expense/ExpenseList";
import IncomeList from "./Income/IncomeList";
import BudgetList from "./Budget/BudgetList";
import Home from "./Homepage";
import HouseholdDashboard from "./Household/HouseholdMain";
import CreateExpense from "./Expense/ExpenseCreate";
import CreateIncome from "./Income/IncomeCreate";
import CreateNewIncome from "./Income/IncomeCreate";

export default function ApplicationViews({
  loggedInUser,
  setLoggedInUser,
  setCurrentHouseholdId,
}) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            loggedInUser ? (
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Home />
              </AuthorizedRoute>
            ) : (
              <Login setLoggedInUser={setLoggedInUser} />
            )
          }
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>

      <Route path="/household">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":householdId"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <HouseholdDashboard
                setCurrentHouseholdId={setCurrentHouseholdId}
              />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":householdId/expense"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ExpenseList
                setCurrentHouseholdId={setCurrentHouseholdId}
                loggedInUser={loggedInUser}
              />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":householdId/expense/create/:expenseId?"
          element={
            <CreateExpense
              setCurrentHouseholdId={setCurrentHouseholdId}
              loggedInUser={loggedInUser}
            />
          }
        />
        <Route
          path=":householdId/income"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <IncomeList
                setCurrentHouseholdId={setCurrentHouseholdId}
                loggedInUser={loggedInUser}
              />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":householdId/income/create/:incomeId?"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateNewIncome
                setCurrentHouseholdId={setCurrentHouseholdId}
                loggedInUser={loggedInUser}
              />
            </AuthorizedRoute>
          }
        />
        <Route
          path=":householdId/budget"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <BudgetList setCurrentHouseholdId={setCurrentHouseholdId} />
            </AuthorizedRoute>
          }
        />
      </Route>

      <Route
        path="/admin"
        element={
          <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
            <h1>Admin Area</h1>
            <p>Only administrators can see this page.</p>
          </AuthorizedRoute>
        }
      />

      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
