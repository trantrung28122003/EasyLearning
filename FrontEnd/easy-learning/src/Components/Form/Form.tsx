import { Button, Input } from "@mui/material";
import { ErrorMessage, Field, Formik } from "formik";
import { FC, useState } from "react";
import { Schema } from "yup";

interface DynamicFormData {
  [key: string]: any;
}

interface FormProps {
  initialValues: DynamicFormData;
  schema: Schema<DynamicFormData>;
  onSubmit(data: DynamicFormData): void;
}

const AppForm: FC<FormProps> = (props: FormProps) => {
  const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
  const formItems = Object.keys(props.initialValues).map((key) => {
    return (
      // <label htmlFor={key}>
      //   <Field label={key} name={key} />
      //   <ErrorMessage name={key} component="div" className="error" />
      // </label>
      <div>{key}</div>
    );
  });

  const onSubmitForm = async (values: DynamicFormData) => {
    try {
      setIsSubmitting(true);
      await props.schema.validate(values);
      await props.onSubmit(values);
      setIsSubmitting(false);
    } catch (error) {
      console.error("Validation error:", error);
    }
  };

  return (
    <>
      <Formik
        initialValues={props.initialValues}
        validationSchema={props.schema}
        onSubmit={onSubmitForm}
      >
        {formItems}
        <Button disabled={isSubmitting} variant="contained">
          Submit
        </Button>
      </Formik>
    </>
  );
};

export default AppForm;
