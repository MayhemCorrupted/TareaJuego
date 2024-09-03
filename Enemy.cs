using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaJuegoRol
{
    internal class Enemy
    {
        private float health;        
        private float damage;      
        private bool dead;       
        
        public float Damage { get {return damage;} set {damage = value;} }        
        public bool Dead { get {return dead;} }

        public void EnemyHealth(float damage)
        {           
             health -= damage;
             if (health == 0) dead = true;           
        }      
    }
}
