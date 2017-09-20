using UnityEngine;

public class Palm : MonoBehaviour {

    private int health = 15;
    public ParticleSystem Shards;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Shards.Play();

            if (--health <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }

}
