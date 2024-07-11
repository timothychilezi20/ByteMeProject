using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPick : MonoBehaviour
{
    public float interactRadius = 2f; 
    public Transform itemHolder; 
    public GameObject pickUpButton; 
    public GameObject dropOffButton; 

    private GameObject currentItem; 

    void Update()
    {
        CheckForInteractableItem();
    }

    void CheckForInteractableItem()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PickupItem"))
            {
                ShowPickUpButton(collider.gameObject);
                return;
            }
        }
        HideButtons();
    }

    void ShowPickUpButton(GameObject item)
    {
        if (currentItem == null)
        {
            pickUpButton.SetActive(true);
            pickUpButton.GetComponent<Button>().onClick.RemoveAllListeners();
            pickUpButton.GetComponent<Button>().onClick.AddListener(() => PickUpItem(item));
        }
    }

    void ShowDropOffButton()
    {
        if (currentItem != null)
        {
            dropOffButton.SetActive(true);
            dropOffButton.GetComponent<Button>().onClick.RemoveAllListeners();
            dropOffButton.GetComponent<Button>().onClick.AddListener(DropOffItem);
        }
    }

    void HideButtons()
    {
        pickUpButton.SetActive(false);
        dropOffButton.SetActive(false);
    }

    void PickUpItem(GameObject item)
    {
        currentItem = item;
        item.transform.SetParent(itemHolder);
        item.transform.localPosition = Vector3.zero;
        ShowDropOffButton();
    }

    void DropOffItem()
    {
        currentItem.transform.SetParent(null);
        currentItem = null;
        HideButtons();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}

