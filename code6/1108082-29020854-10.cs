    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    
    public class Test : MonoBehaviour {
    
        public PlayerList playerList; //replace GameObject with PlayerList 
         
        // Use this for initialization
        void Start () {
             
            var playerTankList = playerList.PlayerTankList; // You can access it directly
    
            playerTankList .Add (new PlayerList.PlayerTank(1,2,"a player name", "black")); 
        }
    
    }
