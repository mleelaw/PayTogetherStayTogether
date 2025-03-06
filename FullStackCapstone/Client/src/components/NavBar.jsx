import { useState } from "react";
import { NavLink as RRNavLink, useNavigate } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";

export default function NavBar({
  loggedInUser,
  setLoggedInUser,
  currentHouseholdId,
}) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
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
                    <NavItem>
                      <NavItem>
                        <select
                          className="nav-select"
                          onChange={(e) => {
                            if (e.target.value) {
                              window.location.href = e.target.value;
                            }
                          }}
                          value=""
                        >
                          <option value="" disabled>
                            Expense
                          </option>
                          <option
                            value={`/household/${currentHouseholdId}/expense`}
                          >
                            View Expenses
                          </option>
                          <option
                            value={`/household/${currentHouseholdId}/expense/create`}
                          >
                            Add Expense
                          </option>
                        </select>
                      </NavItem>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        tag={RRNavLink}
                        to={`/household/${currentHouseholdId}/budget`}
                      >
                        Budget
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink
                        tag={RRNavLink}
                        to={`/household/${currentHouseholdId}/income`}
                      >
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
              onClick={(e) => {
                e.preventDefault();
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
    </div>
  );
}
