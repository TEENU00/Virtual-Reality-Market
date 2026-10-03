using UnityEngine;

public class RemoveCartItem : MonoBehaviour
{
    public void Remove()
    {
        Debug.Log("REMOVE BUTTON PRESSED");

        CartManager.Instance.RemoveLastItem();
    }
}