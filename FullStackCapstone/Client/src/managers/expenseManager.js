export const GetExpenses = (householdId, month, year) => {
  let _apiUrl = `/api/household/${householdId}/expense`;

  const params = new URLSearchParams();
  if (month != null) params.append("month", month);
  if (year != null) params.append("year", year);

  if (params.toString()) {
    _apiUrl += `?${params.toString()}`;
  }

  return fetch(_apiUrl).then((response) => response.json());
};

export const DeleteExpense = (householdId, expenseId) => {
  return fetch(`/api/household/${householdId}/expense/${expenseId}`, {
    method: "DELETE",
  });
};

export const GetExpenseById = (householdId, expenseId) => {
  return fetch(`/api/household/${householdId}/expense/${expenseId}`).then(
    (res) => res.json()
  );
};

export const UpdateExpense = (householdId, expenseId, expense) => {
  return fetch(`/api/household/${householdId}/expense/${expenseId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(expense),
  });
};

export const CreateNewExpense = (householdId, expense) => {
  return fetch(`/api/household/${householdId}/expense`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(expense),
  });
};
