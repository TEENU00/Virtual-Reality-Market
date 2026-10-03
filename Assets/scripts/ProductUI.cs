using UnityEngine;
using TMPro;

public class ProductUI : MonoBehaviour
{
    public static ProductUI Instance;

    public GameObject panel;

    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text stockText;
    public TMP_Text descriptionText;

    public TMP_InputField quantityInput;
    public TMP_Text messageText;

    private ProductData currentProduct;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void ShowProduct(ProductData product)
    {
        currentProduct = product;

        panel.SetActive(true);

        nameText.text = product.productName;
        priceText.text = "Price: " + product.price +"/-";
        stockText.text = "Stock: " + product.stock;
        descriptionText.text = product.description;

        quantityInput.text = "";
        messageText.text = "";
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void AddToCart()
    {
        Debug.Log("ADD TO CART CLICKED");

        int quantity;

        if (!int.TryParse(quantityInput.text, out quantity))
        {
            messageText.text = "Enter Valid Quantity";
            Invoke("ClearMessage", 5f);
            return;
        }

        if (quantity <= 0)
        {
            messageText.text = "Enter Valid Quantity";
            Invoke("ClearMessage", 5f);
            return;
        }

        if (quantity > currentProduct.stock)
        {
            messageText.text = "Stock Unavailable";
            Invoke("ClearMessage", 5f);
            return;
        }

        currentProduct.stock -= quantity;

        stockText.text =
            "Stock: " + currentProduct.stock;

        CartManager.Instance.AddItem(
            currentProduct,
            quantity);

        messageText.text = "Added To Cart";

        Invoke("ClearMessage", 5f);
    }
    void ClearMessage()
    {
        messageText.text = "";
    }
}