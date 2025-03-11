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
}) {
  const [open, setOpen] = useState(false);
  const [expenseDropdownOpen, setExpenseDropdownOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);
  const toggleExpenseDropdown = () => setExpenseDropdownOpen(!expenseDropdownOpen);

  return (
    <Navbar color="light" light fixed="true" expand="lg">
      <NavbarBrand tag={RRNavLink} to="/">
        Budget Tracker
      </NavbarBrand>
      
      {loggedInUser ? (
        <>
          <NavbarToggler onClick={toggleNavbar} />
          <Collapse isOpen={open} navbar>
            <Nav navbar>
              <NavItem onClick={() => setOpen(false)}>
                <NavLink tag={RRNavLink} to="/household">
                  Home
                </NavLink>
              </NavItem>

              {currentHouseholdId && (
                <>
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
                    <NavLink tag={RRNavLink} to={`/household/${currentHouseholdId}/budget`}>
                      Budget
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={RRNavLink} to={`/household/${currentHouseholdId}/income`}>
                      Income
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