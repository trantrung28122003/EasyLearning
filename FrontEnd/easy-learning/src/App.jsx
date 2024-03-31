import axios from "axios";
import { useEffect, useState } from "react";
import "./App.css";
import CardSample from "./components/CardSample";

const App = () => {
  useEffect(() => {
    CallAPI();
  }, []);

  const [data, setData] = useState([]);
  const CallAPI = () => {
    axios({
      method: "get",
      url: "https://localhost:7229/WeatherForecast",
    })
      .then((res) => {
        console.log(res);
        setData(res.data);
      })
      .catch((e) => console.log(e));
  };

  return (
    <div className="data-container">
      {data.map((e) => {
        return <CardSample summary={e.summary} date={e.date} />;
      })}
    </div>
  );
};
export default App;
