using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private PlayerInfo _player;
    public Item _item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && _player.holdingItem == false)
        {
            GameObject heldItem = gameObject;
            heldItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            heldItem.transform.localPosition = Vector3.zero;
            heldItem.transform.localRotation = Quaternion.identity;
            Destroy(heldItem.GetComponent<Collider>());
            Instantiate(heldItem, other.gameObject.transform.GetChild(0));
            _player.holdingItem = true;
            Destroy(gameObject);
        }
    }
}
