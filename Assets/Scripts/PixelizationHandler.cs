using UnityEngine;

public class PixelizationHandler : MonoBehaviour
{
    [SerializeField]
    private string backwardSwitchKey = "q";

    [SerializeField]
    private string forwardSwitchKey = "e";

    [SerializeField]
    private Material[] filters = null;

    private int currentFilterIndex = 1;

    private PixelizationFilter filter = null;
    private void Start()
    {
        filter = GetComponent<PixelizationFilter>();
        filter.SetMaterial(filters[currentFilterIndex]);
    }
    void Update()
    {
        if (Input.GetKeyDown(backwardSwitchKey))
        {
            currentFilterIndex = (3 + currentFilterIndex - 1) % filters.Length;
            filter.SetMaterial(filters[currentFilterIndex]);
        }
        else if (Input.GetKeyDown(forwardSwitchKey))
        {
            currentFilterIndex = (currentFilterIndex + 1) % filters.Length;
            filter.SetMaterial(filters[currentFilterIndex]);
        }
        Debug.Log(currentFilterIndex);
    }
}
