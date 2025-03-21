import React from "react";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

export default function ExpensePieChart({ budgetTotal }) {
  const usedPercentage = Math.min(budgetTotal, 100);
  const remainingPercentage = Math.max(0, 100 - usedPercentage);
  
  const data = [
    { name: "Used Budget", value: usedPercentage },
    { name: "Remaining Budget", value: remainingPercentage },
  ];

  const COLORS = ["#E03428", "#1A46DB"];

  return (
    <PieChart width={400} height={400}>
      <Pie
        data={data}
        cx="50%"
        cy="50%"
        outerRadius={150}
        fill="#8884d8"
        dataKey="value"
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