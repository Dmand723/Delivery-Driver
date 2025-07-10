using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    Driver driver;
    [SerializeField] GameManager gameManager;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (gameObject.tag == "Player")
        {
            try
            {
                driver = GetComponent<Driver>();
            }
            catch (MissingComponentException e)
            {
                Debug.LogError("Driver component is missing on the Player object: " + e.Message);
            }
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name +": Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "SolidOject" && gameObject.tag == "Player")
        {
            Debug.Log("player has hit an object");
            driver.hitObject();
            gameManager.AddScore(-5f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !hasPackage)
        {
            Color32 newColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            changeColor(newColor);
            hasPackage = true;
            Debug.Log("package has been picked up");
            Destroy(collision.gameObject);
            gameManager.startTimer();
        }
        if(collision.tag == "DeleverySpot" && hasPackage)
        {
            if (spriteRenderer.color == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                gameManager.packageDelivered(); ;
                Debug.Log("player has delivered the package");
                hasPackage = false;
                Debug.Log("player has delevered the package");
                resetColor();
            }
            else
            {
                Debug.Log("Wrong Delevery Spot");
            }
            
        }
        if(collision.tag == "Boost" && gameObject.tag == "Player")
        {
            Debug.Log("player has Hit A Boost");
            driver.hitBoost();
        }

    }
    
    void changeColor(Color32 color)
    {
        spriteRenderer.color = color;
    }
    void resetColor()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 255);  
    }

}
