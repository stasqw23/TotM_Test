using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    private bool _lavaBoots = false;
    [SerializeField] GameObject _youLost;
    [SerializeField] GameObject _youWin;
    [SerializeField] GameObject _roadAnimation;
    [SerializeField] GameObject _lavaNootsCheker;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Win()
    {
        Time.timeScale = 0;
        _youWin.SetActive(true);
        transform.position = transform.position;
        
    }
    public void DeathBomb()
    {
        Time.timeScale = 0;
        _youLost.SetActive(true);
        transform.position = transform.position;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == ("death"))||((collision.gameObject.tag == ("lava"))&&(!_lavaBoots)))
        {
            DeathBomb();
        }
        else if(collision.tag==("boots"))
        {
            _lavaBoots = true;
            _lavaNootsCheker.GetComponent<Image>().color = new Color(255, 255, 255, 1f) ;
            Destroy(collision.gameObject);
            
        }
        else if (collision.tag =="platform")
        {
            if (((collision.transform.position - transform.position).normalized == transform.up) || ((collision.transform.position - transform.position).normalized == -transform.up))
            {
                Instantiate(_roadAnimation, collision.transform).gameObject.transform.Rotate(0,0,90);
            }
            else
            {
                Instantiate(_roadAnimation, collision.transform);
            }
        }
        else if(collision.tag == "finish")
        {
            Win();
        }
    
    }
    

}
