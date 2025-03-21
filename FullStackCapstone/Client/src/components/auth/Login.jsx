import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../../managers/authManager";
import { Button, FormFeedback, FormGroup, Input, Label, Container, Form } from "reactstrap";

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [failedLogin, setFailedLogin] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    login(email, password).then((user) => {
      if (!user) {
        setFailedLogin(true);
      } else {
        setLoggedInUser(user);
        navigate("/");
      }
    });
  };

  return (
    <Container className="py-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <h1 className="text-center mb-5">Login</h1>
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label className="h5">Email</Label>
              <Input
                invalid={failedLogin}
                type="text"
                className="form-control-lg"
                value={email}
                onChange={(e) => {
                  setFailedLogin(false);
                  setEmail(e.target.value);
                }}
              />
            </FormGroup>
            <FormGroup>
              <Label className="h5">Password</Label>
              <Input
                invalid={failedLogin}
                type="password"
                className="form-control-lg"
                value={password}
                onChange={(e) => {
                  setFailedLogin(false);
                  setPassword(e.target.value);
                }}
              />
              <FormFeedback>Login failed.</FormFeedback>
            </FormGroup>

            <div className="text-center">
              <Button 
                color="dark" 
                size="lg" 
                className="w-100 mb-3"
                type="submit"
              >
                Login
              </Button>
              <p className="h5">
                Not signed up? Register <Link to="/register">here</Link>
              </p>
            </div>
          </Form>
        </div>
      </div>
    </Container>
  );
}