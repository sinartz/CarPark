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
    [SerializeField] float rotationSpeed;

    [Header("Platform Settings")]
    public int diamondScore;
    void Start()
    {
        CarSetActive(); // set active car for object pool

    }

    private void CarSetActive()
    {
        car[ActiveCarIndex].SetActive(true);
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
        platform_1.transform.Rotate(new Vector3(0, 0, rotationSpeed), Space.Self);
    }
    /// <summary>
    ///  ("Yasin")      For new car summon trigger from another scp.
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
