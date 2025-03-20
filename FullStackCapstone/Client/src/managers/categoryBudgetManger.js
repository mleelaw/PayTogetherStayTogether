export const GetRemainingBudgetByCategory = (householdId) => {
  return fetch(`/api/household/${householdId}/budget`).then((response) =>
    response.json()
  );
};
