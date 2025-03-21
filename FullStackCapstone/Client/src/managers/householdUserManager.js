const _apiUrl = "/api/householduser";

export const DeleteHouseholdUser = (householdId) => {
  return fetch(`/api/household/${householdId}/user`, { method: "DELETE" });
};
