using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private float delay = 1f;

    CarDelivery myCarDelivery;

    // Start is called before the first frame update
    void Start()
    {
        myCarDelivery = FindObjectOfType<CarDelivery>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCarDelivery.GetPackagesDeliveredAmount() == 5) Invoke(nameof(RestartGame), delay);
    }

    void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
