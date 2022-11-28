using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public int money = 1000;
    public int currentMoney { get; set; }
    public Text moneyText;
    public int xp = 1;
    public int currentXp { get; set; }
    public Text xpText;
    public int levelUp = 10;
    public int damage = 10;
    public int armorDefense = 0;
    public int currentArmorDefense { get; set; }
    public int armorAttack = 0;
    public int currentArmorAttack { get; set; }
    public int numberOfWins = 0;
    public int currentNumberOfWins { get; set; }
    public PlayerManager playerManager;
   
    public static CharacterStats Instance;

    public event System.Action<int, int> OnHealthChanged;

    [SerializeField] enum CharType { player, enemy };
    [SerializeField] CharType charType;

    void Awake()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerManager>();
        Instance = this;
        currentMoney = money;
        currentHealth = maxHealth;
        currentXp = xp;
        currentNumberOfWins = numberOfWins;
        currentArmorAttack = armorAttack;
        currentArmorDefense = armorDefense;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(damage);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Win();
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armorDefense;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
            if (charType == CharType.enemy)
            {
                Win(); 
            }
            if (charType == CharType.player) { 
               // playerManager.GameOver();
            }
        }
    }

    public void SetMoney(Item item)
    {
        currentMoney -= item.money;
    }

    public void UpdateMoneyScreen()
    {
        moneyText.text = currentMoney.ToString();
    }

    public void UpdateXpScreen()
    {
        xpText.text = currentXp.ToString();
    }

    public void Win()
    {
        if(currentXp <= 2)
        {
            currentMoney += 200;
            ChangeWins();
        }
        else if(currentXp > 2 && currentXp <= 4)
        {
            currentMoney += 500;
            ChangeWins();
        }
        else
        {
            currentMoney += 1000;
            ChangeWins();
        }
    }

    public void ChangeWins()
    {
        if (currentNumberOfWins == levelUp)
        {
            levelUp += 5;
            currentXp++;
            currentNumberOfWins++;
            UpdateMoneyScreen();
            UpdateXpScreen();
        }
        if (currentNumberOfWins < levelUp)
        {
            currentNumberOfWins++;
            UpdateMoneyScreen();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + " died.");

        if (charType == CharType.player) {
            playerManager.GameOver();
        }
        else {
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<EnemyController>().isAlive = false;
            Destroy(gameObject, 4);
        }
    }

}
