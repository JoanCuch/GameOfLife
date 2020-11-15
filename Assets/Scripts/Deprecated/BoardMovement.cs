using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    [SerializeField] private float lerping;

    private Vector3 difference;

    // Start is called before the first frame update
    void Start()
    {
        difference = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            difference = touchPos - transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float x = Mathf.Lerp(transform.position.x - difference.x, touchPos.x, lerping);
            float y = Mathf.Lerp(transform.position.y - difference.y, touchPos.y, lerping);
           
            Vector3 newPosition = new Vector3(x, y, transform.position.z);

            transform.position = newPosition;
        }
    }
}
