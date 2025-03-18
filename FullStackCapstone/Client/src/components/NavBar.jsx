import { useState } from "react";
import { Link, NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from "reactstrap";
import { logout } from "../managers/authManager";

export default function NavBar({
  loggedInUser,
  setLoggedInUser,
  currentHouseholdId,
  setCurrentHouseholdId
}) {
  const [open, setOpen] = useState(false);
  const [expenseDropdownOpen, setExpenseDropdownOpen] = useState(false);
  const [incomeDropdownOpen, setIncomeDropdownOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);
  const toggleExpenseDropdown = () => setExpenseDropdownOpen(!expenseDropdownOpen);
  const toggleIncomeDropdown = () => setIncomeDropdownOpen(!incomeDropdownOpen);

  return (
    <Navbar color="light" light fixed="true" expand="lg">
      <NavbarBrand tag={RRNavLink} to="/">
        Pay Together, Stay Together
      </NavbarBrand>
      
      {loggedInUser ? (
        <>
          <NavbarToggler onClick={toggleNavbar} />
          <Collapse isOpen={open} navbar>
            <Nav navbar>
            <NavItem onClick={() => setOpen(false)}>
                <NavLink tag={RRNavLink} onClick={() => setCurrentHouseholdId(null)} to="/household">
                  View Households
                </NavLink>
              </NavItem>
              

              {currentHouseholdId && (
                <>
                  <NavItem onClick={() => setOpen(false)}>
                <NavLink tag={RRNavLink} to={`/household/${currentHouseholdId}`}>
                  Household Dashboard
                </NavLink>
              </NavItem>
                  <Dropdown nav isOpen={expenseDropdownOpen} toggle={toggleExpenseDropdown}>
                    <DropdownToggle nav caret>
                      Expense
                    </DropdownToggle>
                    <DropdownMenu>
                      <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/expense`}>
                        View Expenses
                      </DropdownItem>
                      <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/expense/create`}>
                        Add Expense
                      </DropdownItem>
                    </DropdownMenu>
                  </Dropdown>
                 
                  <NavItem>
                  <Dropdown nav isOpen={incomeDropdownOpen} toggle={toggleIncomeDropdown}>
                    <DropdownToggle nav caret>
                      Income
                    </DropdownToggle>
                    <DropdownMenu>
                      <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/income`}>
                        View Incomes
                      </DropdownItem>
                      <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/income/create`}>
                        Add Income
                      </DropdownItem>
                    </DropdownMenu>  
                  </Dropdown>
                  </NavItem>
                   
                  <NavItem>
                    <NavLink tag={RRNavLink} to={`/household/${currentHouseholdId}/budget`}>
                      Budget
                    </NavLink>
                  </NavItem>
                </>
              )}

              {loggedInUser.roles.includes("Admin") && (
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to="/admin">
                    Admin
                  </NavLink>
                </NavItem>
              )}
            </Nav>
          </Collapse>
          <Button
            color="primary"
            onClick={() => {
              logout().then(() => {
                setLoggedInUser(null);
                window.location.href = "/";
              });
            }}
          >
            Logout
          </Button>
        </>
      ) : (
        <Nav navbar>
          <NavItem>
            <NavLink tag={RRNavLink} to="/">
              <Button color="primary">Login</Button>
            </NavLink>
          </NavItem>
        </Nav>
      )}
    </Navbar>
  );
}