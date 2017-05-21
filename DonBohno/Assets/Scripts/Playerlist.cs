using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Playerlist : MonoBehaviour
    {
        private string _player1;
        private string _player2;
        public string[] prefabs;

        public string Player1{ get{ return _player1; } set { _player1 = value;} }
        public string Player2{ get { return _player2; } set { _player2 = value; } }
        void Start ()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void setCharakters(int playerID, int ChoosenCharakter)
        {
            if(playerID == 1)
            _player1 = prefabs[ChoosenCharakter];
            if (playerID == 2)
                _player2 = prefabs[ChoosenCharakter];
        }

    }

    
}
