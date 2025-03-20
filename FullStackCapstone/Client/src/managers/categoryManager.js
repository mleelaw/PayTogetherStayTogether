export const GetCategories = (householdId) => {
  return fetch(`/api/household/${householdId}/expense/categories`).then((res) =>
    res.json()
  );
};

export const UpdateCategory = (categoryId, householdId, categoryData) => {
  return fetch(`/api/category/${categoryId}?householdId=${householdId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(categoryData),
  }).then((res) => {
    if (!res.ok) {
      throw new Error("Failed to update category");
    }
    return res.json();
  });
};
