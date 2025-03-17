const _apiUrl = "/api/household";

export const getUserHouseholds = () => {
  return fetch(`${_apiUrl}`).then((response) => {
    return response.json();
  });
};

export const addNewHousehold = (householdId) => {
  return fetch(`${_apiUrl}/available-households`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(householdId),
  });
};

export const getAvailableUserHouseholds = () => {
  return fetch(`${_apiUrl}/available-households`).then((response) => {
    return response.json();
  });
};
export const getExpenseTotalAmount = (householdId) => {
  return fetch(`${_apiUrl}/${householdId}`).then((response) => response.json());
};

export const getAllHouseholds = () => {
  return fetch(`${_apiUrl}/all`).then((response) => {
    return response.json();
  });
};

export const createNewHousehold = (household) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(household),
  });
};
