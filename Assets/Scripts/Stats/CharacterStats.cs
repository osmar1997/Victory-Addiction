using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }


        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        anim.SetTrigger("die");
        Debug.Log(transform.name + " died.");

        GetComponent<EnemyController>().isAlive = false;
    }


}
