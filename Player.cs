using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TareaJuegoRol
{
    internal class Player
    {
        private string name;
        private float health;        
        private float damage;       
        private bool dead;       
  
        public string Name { get {return name;} }
        public float Damage { get {return damage;} }       
        public bool Dead { get {return dead;} }  

        public Player(string name, float health, float damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }

        public void PlayerHealth(float damage, bool hit)
        {          
            if (hit)
            {
                health -= damage;

                if (health == 0) dead = true;                
            }
        }        
        public string Data()
        {
            return $"{name} - {health} - {damage}"; 
        }
    }
}
