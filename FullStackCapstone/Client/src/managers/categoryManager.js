export const GetCategories = (householdId) => {
  return fetch(`/api/household/${householdId}/expense/categories`).then((res) =>
    res.json()
  );
};

export const UpdateCategory = (categoryId, categoryData) => {
  return fetch(`/api/category/${categoryId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(categoryData),
  }).then((res) => res.json());
};
