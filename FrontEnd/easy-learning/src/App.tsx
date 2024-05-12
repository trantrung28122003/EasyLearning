import { FC } from "react";
import "./App.css";
import Form from "./Components/Form/Form";
import * as yup from "yup";

interface User {
  name: string;
  email: string;
  age: number;
}
const App: FC = () => {
  const userData: User = {
    name: "John Doe",
    email: "johndoe@example.com",
    age: 25,
  };
  const schema: yup.Schema<User> = yup.object().shape({
    name: yup.string().required("Name is required"),
    email: yup
      .string()
      .email("Invalid email format")
      .required("Email is required"),
    age: yup
      .number()
      .min(18, "Must be 18 or older")
      .required("Age is required"),
  });

  const onSubmit = () => {
    console.log(userData);
  };

  return <Form initialValues={userData} schema={schema} onSubmit={onSubmit} />;
  //return <div>Hello world</div>;
};

export default App;
