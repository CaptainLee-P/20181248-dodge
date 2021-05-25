using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int healAmount = 20;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 15f * Time.deltaTime, 0f);   
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if(playerController!=null)
        {
            playerController.GetHeal(healAmount);
        }

        Destroy(gameObject);
    }
}
