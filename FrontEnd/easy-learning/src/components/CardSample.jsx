import { Button, Card } from "react-bootstrap";

function CardSample({ summary, date }) {
  return (
    <Card style={{ width: "18rem" }}>
      <Card.Img variant="top" src="holder.js/100px180" />
      <Card.Body>
        <Card.Title>{summary}</Card.Title>
        <Card.Text>{date}</Card.Text>
        <Button variant="primary">Go</Button>
      </Card.Body>
    </Card>
  );
}

export default CardSample;
