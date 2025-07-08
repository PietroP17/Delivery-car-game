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
    [SerializeField] GameObject scoreTitle;
    [SerializeField] GameObject scores;
    float timer;

    [SerializeField] TextMeshProUGUI leaderboardText;

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

            victoryText.GetComponent<TextMeshProUGUI>().text = $"All deliveries done!\nTime: {timeFormatted}\nPress Esc";

            NameAndTimeLogic.Instance.completionTime = timer;
            NameAndTimeLogic.Instance.SaveScore();

            ScoreList leaderboardContainer = NameAndTimeLogic.Instance.leaderboard;
            string leaderboardDisplay = "";

            for (int i = 0; i < Mathf.Min(5, leaderboardContainer.leaderboard.Count); i++)
            {
                string name = leaderboardContainer.leaderboard[i].name;
                float time = leaderboardContainer.leaderboard[i].time;
                int min = Mathf.FloorToInt(time / 60f);
                int sec = Mathf.FloorToInt(time % 60f);
                string formatted = string.Format("{0:00}:{1:00}", min, sec);
                leaderboardDisplay += $"{i + 1}. {name} - {formatted}\n\n";
            }

            leaderboardText.text = leaderboardDisplay;

            overlayBackground.SetActive(true);
            victoryText.SetActive(true);
            scoreTitle.SetActive(true);
            scores.SetActive(true);
        }
    } 
}
