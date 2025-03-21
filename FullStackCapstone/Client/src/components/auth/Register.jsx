import { useState } from "react";
import { register } from "../../managers/authManager";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label, Container, Form } from "reactstrap";

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const [passwordMismatch, setPasswordMismatch] = useState();
  const [registrationFailure, setRegistrationFailure] = useState(false);

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      const newUser = {
        firstName,
        lastName,
        userName,
        email,
        address,
        password,
      };
      register(newUser).then((user) => {
        if (user) {
          setLoggedInUser(user);
          navigate("/");
        } else {
          setRegistrationFailure(true);
        }
      });
    }
  };

  return (
    <Container className="py-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <h1 className="text-center mb-5">Sign Up</h1>
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label className="h5">First Name</Label>
              <Input
                type="text"
                className="form-control-lg"
                value={firstName}
                onChange={(e) => {
                  setFirstName(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Last Name</Label>
              <Input
                type="text"
                className="form-control-lg"
                value={lastName}
                onChange={(e) => {
                  setLastName(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Email</Label>
              <Input
                type="email"
                className="form-control-lg"
                value={email}
                onChange={(e) => {
                  setEmail(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">User Name</Label>
              <Input
                type="text"
                className="form-control-lg"
                value={userName}
                onChange={(e) => {
                  setUserName(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Address</Label>
              <Input
                type="text"
                className="form-control-lg"
                value={address}
                onChange={(e) => {
                  setAddress(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Password</Label>
              <Input
                invalid={passwordMismatch}
                type="password"
                className="form-control-lg"
                value={password}
                onChange={(e) => {
                  setPasswordMismatch(false);
                  setPassword(e.target.value);
                }}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Confirm Password</Label>
              <Input
                invalid={passwordMismatch}
                type="password"
                className="form-control-lg"
                value={confirmPassword}
                onChange={(e) => {
                  setPasswordMismatch(false);
                  setConfirmPassword(e.target.value);
                }}
                required
              />
              <FormFeedback>Passwords do not match!</FormFeedback>
            </FormGroup>
            
            {registrationFailure && (
              <p className="text-danger text-center mb-3">Registration Failure</p>
            )}

            <div className="text-center">
              <Button 
                color="dark" 
                size="lg" 
                className="w-100 mb-3"
                type="submit"
                disabled={passwordMismatch}
              >
                Register
              </Button>
              <p className="h5">
                Already signed up? Log in <Link to="/">here</Link>
              </p>
            </div>
          </Form>
        </div>
      </div>
    </Container>
  );
}