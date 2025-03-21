export const GetCategories = (householdId) => {
  return fetch(`/api/household/${householdId}/category`).then((res) =>
    res.json()
  );
};

export const UpdateCategory = (categoryId, householdId, updatedCategory) => {
  return fetch(`/api/household/${householdId}/category/${categoryId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(updatedCategory),
  }).then((res) => {
    if (!res.ok) {
      throw new Error(`Failed to update category: ${res.status}`);
    }
    return res.json();
  });
};
