using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ow");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage){
            Debug.Log("Package secured");
            hasPackage = true;
            spriteRenderer.color = other.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject, 0);
        }
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
