using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private CanvasManager canvasManager;
    public float health = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyBullet")) 
        {
            health -= 10;

            if(health <= 0)
            {
                canvasManager.ActiveGameOver();
                Time.timeScale = 0;
            }
        }
    }
}
