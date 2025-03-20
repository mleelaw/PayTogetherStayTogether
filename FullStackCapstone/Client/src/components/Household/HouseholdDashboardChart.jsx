// src/components/Chart/ExpensePieChart.js
import React from "react";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

export default function ExpensePieChart({ budgetTotal }) {
  const data = [
    { name: "Used Budget", value: budgetTotal },
    { name: "Remaining Budget", value: 100 - budgetTotal },
  ];

  const COLORS = ["#FF6384", "#36A2EB"]; // Customize colors as needed

  return (
    <PieChart width={400} height={400}>
      <Pie
        data={data}
        cx="50%"
        cy="50%"
        outerRadius={150}
        fill="#8884d8"
        dataKey="value"
        label
      >
        {data.map((entry, index) => (
          <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
        ))}
      </Pie>
      <Tooltip />
      <Legend />
    </PieChart>
  );
}
