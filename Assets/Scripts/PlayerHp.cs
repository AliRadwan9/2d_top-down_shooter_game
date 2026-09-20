using UnityEngine;


public class PlayerHp : MonoBehaviour
{
    public int playerHp;
    public UIManager uiManager;

    private float survivalTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        survivalTimer += Time.deltaTime;
        if (survivalTimer >= 1.0f)
        {
            playerHp += 1;
            survivalTimer -= 1.0f;
        }
        uiManager.UpdatePlayerHp(playerHp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamagePlayer(5);
            Destroy(collision.gameObject);
        }
       
    }
    public void DamagePlayer (int damage)
    {
        playerHp -= damage;
        if (playerHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
