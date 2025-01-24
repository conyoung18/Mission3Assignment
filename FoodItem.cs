namespace Mission3Assignment;

public class FoodItem
{
    // store information in variables to be used later
    public string foodItemName = "";
    string foodItemCategory = "";
    int foodItemQuantity = 0;
    DateOnly foodExpirationDate = default;
    public FoodItem(string name, string category, int quantity, DateOnly expirationDate) // takes inputs from foodItem in Program
    {
        foodItemName = name;
        foodItemCategory = category;
        foodItemQuantity = quantity;
        foodExpirationDate = expirationDate;
    }
    
    // Displays each parameter of the object
    public override string ToString()
    {
        return $"Name: {foodItemName}, Category: {foodItemCategory}, Quanitity: {foodItemQuantity}, Expiration Date: {foodExpirationDate}";
    }
}