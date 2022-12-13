
using UnityEngine;

public class PlaneController : MonoBehaviour
{


    private bool right;

    [SerializeField] private float maxTilt;
    [SerializeField] private float speed;
    [SerializeField] private float transformbounds;
    [SerializeField] private ParticleSystem explosionMissile;
    [SerializeField] private GameObject missile;

    private void Start()
    {
        right = true;
    }

    void Update()
    {
        playerMovement();
        firing();
    }

    void firing()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (right) { 
                Instantiate(explosionMissile, transform.position + new Vector3(0.59f, 0, 0), Quaternion.identity);
                Instantiate(missile, transform.position + new Vector3(0.59f, 0, 0), Quaternion.identity);
            }
            else { 
                Instantiate(explosionMissile, transform.position + new Vector3(-0.59f, 0, 0), Quaternion.identity);
                Instantiate(missile, transform.position + new Vector3(-0.59f, 0, 0), Quaternion.identity);
            }
            right = !right;
        }

    }

    void playerMovement()
    {

        if (!Input.GetKeyUp(KeyCode.D) || !Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 0), Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < transformbounds)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, -maxTilt, 0), Time.deltaTime * 5);
            transform.parent.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x > transformbounds)
        {
            transform.position = new Vector3(transformbounds, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -transformbounds)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, maxTilt, 0), Time.deltaTime * 5);
            transform.parent.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -transformbounds)
        {
            transform.position = new Vector3(-transformbounds, transform.position.y, transform.position.z);
        }
    }

}