import "./App.css";
import axios from "axios";
import React, { Component, useEffect, useState } from "react";

function App() {
  const [hang, getlisthang] = useState([]);
  useEffect(() => {
    try {
      axios.get("http://localhost:8080/api/viewCTHang/1").then((res) => {
        console.log("abc", res.data);
        getlisthang(res.data);
      });
    } catch (error) {
      console.log(error);
    }
  }, []);
  return (
    <div className="App">
      <h1>test</h1>
    </div>
  );
}

export default App;
