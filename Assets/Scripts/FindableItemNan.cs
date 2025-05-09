using UnityEngine;
using UnityEngine.SceneManagement;

public class FindableItemNan : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    SceneManager.LoadScene("FliterScene_KhunNan");
                }
            }
        }
    }
}
