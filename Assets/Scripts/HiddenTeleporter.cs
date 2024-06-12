using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTeleporter : MonoBehaviour
{
    [SerializeField] private Transform originRef;
    [SerializeField] private Transform destinationRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Player")
        {
            Debug.Log(name);

            Vector3 travelDirection = transform.position - other.transform.position;

            float dot = Vector3.Dot(travelDirection, originRef.forward);

            if (dot <= 0)
                return;

            var targetPosition = other.transform.position - originRef.position;
            targetPosition += destinationRef.position;

            other.transform.position = targetPosition;
        }
    }
}
