using UnityEngine;

public class ProductInteraction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                new Vector3(Screen.width / 2, Screen.height / 2));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f))
            {
                ProductData product =
                    hit.collider.GetComponent<ProductData>();

                if (product != null)
                {
                    ProductUI.Instance.ShowProduct(product);
                }
            }
        }
    }
}