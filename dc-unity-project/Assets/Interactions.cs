using UnityEngine;
using TMPro;
using System.Collections;

public class Interactions : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite hasPackageSprite;

    bool hasPackage = false;
    //    int packagesDelivered = 0;
    GameObject[] deliveryPoints;

    [SerializeField] GameObject overlayBackground;
    [SerializeField] GameObject victoryText;
    float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        timer = Time.time;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Parked car")
        {
            Debug.Log("Hit parked cars will cost!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Delivery hub" && !hasPackage)
        {
            spriteRenderer.sprite = hasPackageSprite;
            hasPackage = true;
            Debug.Log("Package picked up!");

            deliveryPoints = GameObject.FindGameObjectsWithTag("Delivery point");

            if (deliveryPoints.Length == 1)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "Delivery point" && hasPackage)
        {
            spriteRenderer.sprite = defaultSprite;
            hasPackage = false;
            Destroy(other.gameObject);
            //            packagesDelivered++;
            Debug.Log("Package delivered!");

            StartCoroutine(CheckVictoryAfterFrame());
        }
    }

    IEnumerator CheckVictoryAfterFrame()
    {
        yield return null;

        deliveryPoints = GameObject.FindGameObjectsWithTag("Delivery point");

        if (deliveryPoints.Length == 0)
        {
            timer = Time.time - timer;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            string timeFormatted = string.Format("{0:00}:{1:00}", minutes, seconds);

            victoryText.GetComponent<TextMeshProUGUI>().text = $"All deliveries done!\nTime taken: {timeFormatted}\nPress Esc";

            overlayBackground.SetActive(true);
            victoryText.SetActive(true);
        }
    } 
}
