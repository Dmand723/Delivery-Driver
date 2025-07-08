using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float baseSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] float slowSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    public void hitBoost()
    {
        moveSpeed = boostSpeed;

    }
    public void hitObject()
    {
        moveSpeed = slowSpeed;
    }

}
