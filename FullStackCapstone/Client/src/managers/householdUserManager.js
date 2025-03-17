const _apiUrl = "/api/householduser";

export const DeleteHouseholdUser = (householdId) => {
  return fetch(`${_apiUrl}/${householdId}`, {
    method: "DELETE",
  });
};
