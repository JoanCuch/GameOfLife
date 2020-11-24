using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D buttonHit = Physics2D.Raycast(mousePosition, Vector3.forward);

		if (buttonHit)
		{
            Debug.Log(buttonHit.transform.name + " " + buttonHit.transform.gameObject.layer); 
		}
                       
        
    }
}
