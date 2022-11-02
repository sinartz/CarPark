using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] GameObject[] car;
    [SerializeField] int ActiveCarIndex=0;
    [SerializeField] int HowMuchCar;


    [Header("Platform Settings")]
    [SerializeField] GameObject platform_1;    
    [SerializeField] float donusHizi;

    void Start()
    {
        car[ActiveCarIndex].SetActive (true);
        
    }

    
    void Update()

    {
        CarForward();
        PlatformTurn();

    }

    void CarForward()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            car[ActiveCarIndex].GetComponent<Car>().forward = true;
            ActiveCarIndex++;
        }
    }

    void PlatformTurn()
    {
        platform_1.transform.Rotate(new Vector3(0, 0, donusHizi), Space.Self);
    }
    /// <summary>
    /// For new car summon trigger from another scp.
    /// </summary>
    public void NewCarSummon()
    {
        if (ActiveCarIndex < HowMuchCar)
        {
            car[ActiveCarIndex].SetActive(true);
        }
        else
        {
            Debug.Log("Araç bitti");
        }

    }

}
