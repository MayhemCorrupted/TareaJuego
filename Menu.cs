using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TareaJuegoRol
{
    internal class Menu
    {
        private Enemy enemy;        
        private Player player;
        private bool menu;
        private bool startGame;      
        private bool playerTurn;
        private bool enemyTurn;

        public void ExecuteGame()
        {
            StartMenu();
        }

        private void StartMenu()
        {
            int select;
            menu = true;
            while (menu)
            {
                Console.WriteLine("Elija la opción");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Empezar juego");
                Console.WriteLine("3. Salir");

                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        CreatePlayer();
                        break;                        
                    case 2:
                        StartGame();
                        break;
                    case 3:
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Elección incorrecta");
                        break;
                }
            }
        }
        private void CreatePlayer()
        {
            string name = PlayerName();
            float health = PlayerHealth();
            float damage = PlayerDamage();

            player = new Player(name, health, damage);
        }
        private string PlayerName()
        {
            string name;
            Console.WriteLine("Introduzca tu nombre");
            name = Console.ReadLine();
            Console.WriteLine($"Registrado, hola {name}");
            return name;
        }
        private float PlayerDamage()
        {
            int damage = 0;
            bool repeatLoop = true;
            while (repeatLoop)
            {
                Console.WriteLine("El daño que quiera hacer");
                damage = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tu daño total es {damage}");
                if (damage <= 100)
                {
                    repeatLoop = false;
                    Console.WriteLine("Muy bien.");
                }

                else if (damage == 0) Console.WriteLine("No puedes poner 0, intente de nuevo.");
                
                else Console.WriteLine("El valor es muy grande. Máx 100. Intente de nuevo");
                
            }
            return damage;
        }
        private float PlayerHealth()
        {
            int health = 0;
            bool repeatLoop = true;
            while (repeatLoop)
            {
                Console.WriteLine("Ponga su vida máxima");
                health = int.Parse(Console.ReadLine());
                Console.WriteLine($"Tu vida máxima es {health}");
                if (health <= 100)
                {
                    repeatLoop = false;
                    Console.WriteLine("Muy bien. prosiga.");
                }
                else if (health == 0) Console.WriteLine("No puedes poner 0, intente de nuevo");

                else Console.WriteLine("El valor es muy grande, máx 100, intente de nuevo");
            }
            return health;
        }
        private void StartGame()
        {
            startGame = true;            
            enemy = new Enemy();
            while (startGame)
            {
                menu = false;
                enemy.EnemyHealth(100);
                enemy.Damage = 20;

                int n;               

                Console.WriteLine("Elija las opciones contra el enemigo");
                Console.WriteLine("Enemigo: 100 HP - 20 DMG");
                Console.WriteLine("1. Atacar | 2. Esquivar");
                playerTurn = true;
                enemyTurn = false;
                n = int.Parse(Console.ReadLine());

                if (playerTurn)
                {
                    switch (n)
                    {
                        case 1:
                            enemy.EnemyHealth(player.Damage);
                            Console.WriteLine($"Atacaste {player.Damage}");
                            playerTurn = false;
                            enemyTurn = true;
                            break;
                        case 2:
                            Console.WriteLine("Esquivaste");
                            playerTurn = false;
                            enemyTurn = true;
                            break;
                        default:
                            Console.WriteLine("Valor incorrecto");
                            break;
                    }
                }
                else if (enemyTurn)
                {
                    int m;
                    Console.WriteLine("¡El enemigo ataca!");
                    Console.WriteLine("¿Bloquearás el ataque?");
                    Console.WriteLine("1. Sí | 2. No");

                    m = int.Parse(Console.ReadLine());
                    switch (m)
                    {
                        case 1:                            
                            player.PlayerHealth((enemy.Damage / 2), true);
                            Console.WriteLine($"Recibiste {enemy.Damage} por parte del enemigo");
                            playerTurn = true;
                            break;
                        case 2:
                            player.PlayerHealth(enemy.Damage, true);
                            Console.WriteLine($"Recibiste {enemy.Damage} por parte del enemigo");
                            playerTurn = true;
                            break;
                    }
                }

                if (player.Dead)
                {
                    int b;
                    Console.WriteLine("Perdiste");
                    Console.WriteLine("1. Volver al menú");
                    b = int.Parse(Console.ReadLine());

                    switch (b)
                    {
                        case 1:
                            startGame = false;
                            menu = true;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                }
                else if (enemy.Dead)
                {
                    int v;
                    Console.WriteLine("Ganaste");
                    Console.WriteLine("1. Volver al menú");
                    v = int.Parse(Console.ReadLine());

                    switch (v)
                    {
                        case 1:
                            startGame = false;
                            menu = true;
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                }
            }
        }
    }
}
