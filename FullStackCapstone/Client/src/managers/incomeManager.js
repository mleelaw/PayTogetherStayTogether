export const GetIncomes = (householdId) => {
  const _apiUrl = `/api/household/${householdId}/income`;
  return fetch(_apiUrl).then((response) => response.json());
};

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
