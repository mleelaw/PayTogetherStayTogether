export const CreateIncome = (householdId, income) => {
  return fetch(`/api/household/${householdId}/income`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(income),
  });
};

export const DeleteIncome = (householdId, incomeid) => {
  return fetch(`/api/household/${householdId}/income/${incomeid}`, {
    method: "DELETE",
  });
};

export const GetIncomes = (householdId, month, year) => {
  let _apiUrl = `/api/household/${householdId}/income`;

  const params = new URLSearchParams();
  if (month !== null && month !== undefined) params.append("month", month);
  if (year !== null && year !== undefined) params.append("year", year);

  if (params.toString()) {
    _apiUrl += `?${params.toString()}`;
  }

  return fetch(_apiUrl).then((response) => response.json());
};
