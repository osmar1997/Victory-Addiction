using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    private int maxHealth = 100;
    public int currentHealth { get; private set; }
    private int money = 1000;
    public int currentMoney { get; set; }
    public Text moneyText;
    private int xp = 2;
    public int currentXp { get; set; }
    public Text xpText;
    private int levelUp = 10;
    private int damage = 10;
    private int armorDefense = 0;
    public int currentArmorDefense { get; set; }
    private int armorAttack = 0;
    private int currentArmorAttack { get; set; }
    private int numberOfWins = 0;
    private int currentNumberOfWins { get; set; }
    public PlayerManager playerManager;
    public GameObject closeDoorAfter;
    public GameObject closeDoorAfter2;
    public GameObject AnimeObject;
    public GameObject AnimeObject2;
    SpriteRenderer spriteRenderer;
    public int currentArena { get; set; }
    public int arena = 0;
    
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
        currentArena = arena;
    }

    void Update()
    {
        UpdateMoneyScreen();
        UpdateXpScreen();
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
            Win();
        }
    }

    public void SetMoney(Item item)
    {
        Instance.currentMoney -= item.money;
    }

    public void UpdateMoneyScreen()
    {
        Instance.moneyText.text = currentMoney.ToString();
    }

    public void UpdateXpScreen()
    {
        Instance.xpText.text = currentXp.ToString();
    }

    public void Win()
    {
        if(currentXp <= 2)
        {
            Instance.currentMoney += 200;
            ChangeWins();
        }
        else if(currentXp > 2 && currentXp <= 4)
        {
            Instance.currentMoney += 500;
            ChangeWins();
        }
        else
        {
            Instance.currentMoney += 1000;
            ChangeWins();
        }
    }

    public void ChangeWins()
    {
        if (currentNumberOfWins == levelUp)
        {
            Instance.levelUp += 5;
            Instance.currentXp++;
            Instance.currentNumberOfWins++;
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
        
        Debug.Log(transform.name + " died.");

        if (charType == CharType.player) {
            //Esta linha seguinte nao d� porque o trabalho n�o est� organizado
            //Est� a tentar ir buscar o Animator ao ThirdPersonPlayer e n�o tem
            //GetComponent<Animator>().SetTrigger("die");
            playerManager.GameOver();
        }
        else {
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<EnemyController>().isAlive = false;
            Destroy(gameObject, 4);
            
            if (Instance.currentArena == 1)
            {
                AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                closeDoorAfter.SetActive(true);
            }
            
            if (Instance.currentArena == 2)
            {
                AnimeObject2.GetComponent<Animator>().Play("OpenDoor2");
                closeDoorAfter2.SetActive(true);
            }
            
        }
    }
}
