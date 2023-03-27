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
        if(mission!= null) mission.text = "Find a pink Package and deliver it.";
    }

    void Update()
    {
        SetPackagesDeliveredAmount();
    }

    void SetPackagesDeliveredAmount()
    {
        if(mission!= null) packagesDeliveredText.text = packagesDelivered.ToString();
    }

    public int GetPackagesDeliveredAmount()
    {
        return packagesDelivered;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Package" && !pickedUpPackage)
        {
            if(packageOnBoard!= null) packageOnBoard.text = "Package picked up!";
            if(mission!= null) mission.text = "Find a blue customer and deliver the package.";
            Destroy(other.gameObject, .5f);
            pickedUpPackage = true;
        }

        if (other.gameObject.tag == "Customer" && pickedUpPackage)
        {
            if(packageOnBoard!= null) packageOnBoard.text = "Package delivered!";
            if(mission!= null) mission.text = "Find the next Package!";
            ++packagesDelivered;
            pickedUpPackage = false;
        }
    }
}
