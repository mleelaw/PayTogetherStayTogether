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
   <Navbar color="dark" fixed="true" expand="lg" className="px-3 bg-dark text-light">
     <NavbarBrand tag={RRNavLink} to="/" className="fw-bold fs-4 text-light">
       Pay Together, Stay Together
     </NavbarBrand>
     
     {loggedInUser ? (
       <>
         <NavbarToggler onClick={toggleNavbar} />
         <Collapse isOpen={open} navbar>
           <Nav navbar className="mx-2">
             <NavItem onClick={() => setOpen(false)} className="mx-2">
               <NavLink 
                 tag={RRNavLink} 
                 onClick={() => setCurrentHouseholdId(null)} 
                 to="/household"
                 className="nav-link-hover fs-5 text-light"
                 style={{ transition: "transform 0.3s" }}
                 onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.2)"}
                 onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
               >
                 View Households
               </NavLink>
             </NavItem>
             
             {currentHouseholdId && (
               <>
                 <NavItem onClick={() => setOpen(false)} className="mx-2">
                   <NavLink 
                     tag={RRNavLink} 
                     to={`/household/${currentHouseholdId}`}
                     className="fs-5 text-light"
                     style={{ transition: "transform 0.3s" }}
                     onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.1)"}
                     onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
                   >
                     Household Dashboard
                   </NavLink>
                 </NavItem>
                 
                 <Dropdown nav isOpen={expenseDropdownOpen} toggle={toggleExpenseDropdown} className="mx-2">
                   <DropdownToggle 
                     nav 
                     caret
                     className="fs-5 text-light"
                     style={{ transition: "transform 0.3s" }}
                     onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.1)"}
                     onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
                   >
                     Expense
                   </DropdownToggle>
                   <DropdownMenu>
                     <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/expense`} className="fs-6 text-dark">
                       View Expenses
                     </DropdownItem>
                     <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/expense/create`} className="fs-6 text-dark">
                       Add Expense
                     </DropdownItem>
                   </DropdownMenu>
                 </Dropdown>
                 
                 <Dropdown nav isOpen={incomeDropdownOpen} toggle={toggleIncomeDropdown} className="mx-2">
                   <DropdownToggle 
                     nav 
                     caret
                     className="fs-5 text-light"
                     style={{ transition: "transform 0.3s" }}
                     onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.1)"}
                     onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
                   >
                     Income
                   </DropdownToggle>
                   <DropdownMenu>
                     <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/income`} className="fs-6 text-dark">
                       View Incomes
                     </DropdownItem>
                     <DropdownItem tag={Link} to={`/household/${currentHouseholdId}/income/create`} className="fs-6 text-dark">
                       Add Income
                     </DropdownItem>
                   </DropdownMenu>  
                 </Dropdown>
                 
                 <NavItem className="mx-2">
                   <NavLink 
                     tag={RRNavLink} 
                     to={`/household/${currentHouseholdId}/budget`}
                     className="fs-5 text-light"
                     style={{ transition: "transform 0.3s" }}
                     onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.1)"}
                     onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
                   >
                     Budget
                   </NavLink>
                 </NavItem>
               </>
             )}

             {loggedInUser.roles.includes("Admin") && (
               <NavItem onClick={() => setOpen(false)} className="mx-2">
                 <NavLink 
                   tag={RRNavLink} 
                   to="/admin"
                   className="fs-5 text-light"
                   style={{ transition: "transform 0.3s" }}
                   onMouseOver={(e) => e.currentTarget.style.transform = "scale(1.1)"}
                   onMouseOut={(e) => e.currentTarget.style.transform = "scale(1)"}
                 >
                   Admin
                 </NavLink>
               </NavItem>
             )}
           </Nav>
         </Collapse>
         <Button
           color="primary"
           className="fs-5"
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
             <Button color="primary" className="fs-5">Login</Button>
           </NavLink>
         </NavItem>
       </Nav>
     )}
   </Navbar>
 );
}