using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;
    public bool forward;
    [SerializeField] Transform carParent;
    [SerializeField] GameManager _gameManager;
    [SerializeField] bool stopPointd = false;

 


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stopPointd)
            transform.Translate(new Vector3(-2f * Time.deltaTime, 0, 0));
        if (forward)
            transform.Translate(new Vector3(-speed * Time.deltaTime,0,0)); 
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parking"))
        {
            forward = false;
            transform.SetParent(carParent);
            _gameManager.NewCarSummon();            
        }
        if (collision.gameObject.CompareTag("Gobek"))
        {
            
            Destroy(gameObject);
            _gameManager.NewCarSummon();

        }
        else if (collision.gameObject.CompareTag("StopPoint"))
        {
            stopPointd = true;
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {   
            
            _gameManager.diamondScore++;
            collision.gameObject.SetActive(false);
        }    
        

            
    }
}
