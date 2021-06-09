using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage = 35;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<EnemyDamage>() != null)
            {
                var dmg = Random.Range(damage - deltaDamage, damage + deltaDamage);
                collision.gameObject.GetComponent<EnemyDamage>().Damage(dmg);
                var pref = Instantiate(textPref, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                pref.Init(dmg.ToString(), Color.gray);
                Destroy(gameObject);
            }
        }
        */
