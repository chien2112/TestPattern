using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public float damage = 0;
    public IDoDamage dmgType;
    Vector3 mousePos;
    
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.transform.position = mousePos;
        
    }
    public void DoAttack()
    {
        CircleEnemy enemy = null;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(mousePos, new Vector2(1.5f, 1.5f), 0, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                enemy = hit.transform.GetComponent<CircleEnemy>();
            }
        }

        if (enemy != null)
        {
            dmgType?.DoDamage(damage, enemy);
        }
        Debug.Log(dmgType);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(mousePos, new Vector2(1.5f,1.5f));
        Gizmos.color = Color.red;
    }
}
