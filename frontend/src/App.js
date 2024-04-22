import axios from "axios";
import React, { useMemo, useState, useEffect } from "react";

import Table from "./Table";
import "./App.css";

function App() {
  const columns = useMemo(
    () => [
      {
        Header: "Stanley Martin Homes",
        columns: [
          {
            Header: "Product Id",
            accessor: "ProductId",
          },
          {
            Header: "Product Name",
            accessor: "ProductName",
          },
          {
            Header: "Project Name",
            accessor: "ProjectName",
          },
          {
            Header: "Metro Area Id",
            accessor: "MetroAreaId",
          },
          {
            Header: "Metro Area Title",
            accessor: "MetroAreaTitle",
          },
          {
            Header: "Metro Area State Abr",
            accessor: "MetroAreaStateAbr",
          },
          {
            Header: "Metro Area State",
            accessor: "MetroAreaStateName",
          },
          {
            Header: "Full Name",
            accessor: "FullName",
          },
          {
            Header: "Project Group Id",
            accessor: "ProjectGroupId",
          },
          {
            Header: "Status",
            accessor: "Status",
          },
        ],
      }
    ],
    []
  );


  const [data, setData] = useState([]);

  useEffect(() => {
    (async () => {
      const result = await axios({
        url: 'http://localhost:5264/search',
        method: 'get',
        mode:'no-cors',
        headers: {
          Accept: 'application/json',
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Headers': 'Content-Type',
          'Access-Control-Expose-Headers': 'Content-Length, X-JSON',
          'Access-Control-Allow-Methods': 'GET',
          'Content-Type': 'application/json',
          withCredentials: true,
          mode: 'no-cors',
        },
      });
      setData(result.data);
    })();
  }, []);

  return (
    <div className="App">
      
      <Table columns={columns} data={data} />
    </div>
  );
}
export default App;