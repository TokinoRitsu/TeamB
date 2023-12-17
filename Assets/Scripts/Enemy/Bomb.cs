using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float time;
    [SerializeField] float height;
    [SerializeField] float speed;
    Vector3 playerPos;
    GameObject z;

    public GameObject dangerZone;

    Vector3 start_pos; //Pos where the bomb start to shoot.
    public GameObject explosion_effect;

    private void Start()
    {
        start_pos = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        z = Instantiate(dangerZone, playerPos, dangerZone.transform.rotation);
        
       
    }

    void Update()
    {
        time += Time.deltaTime;
        //time = time % 5;

        transform.position = MathParabola.Parabola(start_pos, playerPos, height, time * 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(z);

    }
}
