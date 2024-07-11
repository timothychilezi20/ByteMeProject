using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabotage : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;

    public bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enemy!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sabotage" && !hasPackage)
        {
            Debug.Log("You can now sabotage!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.5f);

        }

        if (other.tag == "Sabotaged" && hasPackage)
        {
            Debug.Log("Object sabotaged!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
