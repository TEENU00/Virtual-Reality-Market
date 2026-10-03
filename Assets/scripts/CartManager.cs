using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance;

    public TMP_Text cartItemsText;

    private List<string> cartLines = new List<string>();
    private List<ProductData> cartProducts = new List<ProductData>();
    private List<int> cartQuantities = new List<int>();

    private float grandTotal = 0;

    void Awake()
    {
        Instance = this;

        if (cartItemsText == null)
        {
            cartItemsText =
                GameObject.Find("CartItemsText")
                ?.GetComponent<TMP_Text>();
        }

        if (cartItemsText == null)
        {
            Debug.LogError(
                "CartItemsText object not found!");
            return;
        }

        cartItemsText.text = "Cart Empty";
    }

    public void AddItem(ProductData product, int quantity)
    {
        Debug.Log("Item Added To Cart");

        float total = quantity * product.price;
        grandTotal += total;

        string line =
            product.productName +
            " x " +
            quantity +
            " = " +
            total + "/-";

        cartLines.Add(line);
        cartProducts.Add(product);
        cartQuantities.Add(quantity);

        UpdateCart();
    }

    void UpdateCart()
    {
        if (cartItemsText == null)
            return;

        if (cartLines.Count == 0)
        {
            cartItemsText.text = "Cart Empty";
            return;
        }

        string content = "";

        foreach (string item in cartLines)
        {
            content += item + "\n";
        }

        content +=
            "\n-----------------\n" +
            "TOTAL = " +
            grandTotal +
            "/-";

        cartItemsText.text = content;
    }

    public void RemoveLastItem()
    {
        Debug.Log("REMOVE BUTTON CLICKED");

        if (cartLines.Count == 0)
            return;

        int lastIndex =
            cartLines.Count - 1;

        ProductData product =
            cartProducts[lastIndex];

        int quantity =
            cartQuantities[lastIndex];

        float itemTotal =
            quantity * product.price;

        grandTotal -= itemTotal;

        product.stock += quantity;

        cartLines.RemoveAt(lastIndex);
        cartProducts.RemoveAt(lastIndex);
        cartQuantities.RemoveAt(lastIndex);

        UpdateCart();
    }
}