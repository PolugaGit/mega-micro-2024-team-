using UnityEngine;

public class Player : MonoBehaviour
{
    public float value = 0.5f;
    public float rotationSpeed = 0.5f;
    public float rotationLimit = 140f;
    public Animator animator;
    public GameObject pivotObject;

    // Update is called once per frame
    void Update()
    {
        float convertedRotLimit = 90 - rotationLimit*0.5f;
        animator.SetFloat("position", value);
        float input = Input.GetAxis("Horizontal");
        Vector3 pivotPoint = pivotObject.transform.position;

        if (input != 0)
        {
            value += input * rotationSpeed * Time.deltaTime;
            value = Mathf.Clamp(value, 0f, 1f);

            float rotationAngle = 90f + (-1f * value * rotationLimit) - (180 - rotationLimit) * 0.5f;
            Vector3 direction = Quaternion.Euler(0f, 0f, rotationAngle) * Vector3.up;
            Vector3 newPos = pivotPoint + direction * Vector3.Distance(pivotPoint, transform.position);
            transform.position = newPos;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }
    }
}
