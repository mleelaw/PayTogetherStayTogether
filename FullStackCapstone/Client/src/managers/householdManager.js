const _apiUrl = "/api/household";

export const getUserHouseholds = () => {
  return fetch(`${_apiUrl}`).then((response) => {
    return response.json();
  });
};

export const getExpenseTotalAmount = (householdId) => {
  return fetch(`${_apiUrl}/${householdId}`).then((response) => response.json());
};
