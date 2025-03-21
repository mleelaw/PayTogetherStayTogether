export const formatCurrency = (amount) => {
    return amount ? `$${parseFloat(amount).toFixed(2)}` : "$0.00";
  };