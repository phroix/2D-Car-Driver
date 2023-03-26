using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CarDelivery : MonoBehaviour
{
    bool pickedUpPackage = false;
    [SerializeField] TextMeshProUGUI packagesDeliveredText;
    [SerializeField] TextMeshProUGUI packageOnBoard;
    [SerializeField] TextMeshProUGUI mission;
    int packagesDelivered = 0;

    // Start is called before the first frame update
    void Start()
    {
        mission.text = "Find the pink Package and deliver the package.";
    }

    void Update()
    {
        SetPackagesDeliveredAmount();
    }

    void SetPackagesDeliveredAmount()
    {
        packagesDeliveredText.text = packagesDelivered.ToString();
    }

    public int GetPackagesDeliveredAmount()
    {
        return packagesDelivered;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Package" && !pickedUpPackage)
        {
            packageOnBoard.text = "Package picked up!";
            mission.text = "Find the blue customer and deliver the package.";
            Destroy(other.gameObject, .5f);
            pickedUpPackage = true;
        }

        if (other.gameObject.tag == "Customer" && pickedUpPackage)
        {
            packageOnBoard.text = "Package delivered!";
            mission.text = "Find next Package";
            ++packagesDelivered;
            pickedUpPackage = false;
        }
    }
}
