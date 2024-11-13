
    using UnityEngine;

    public class GameManager : Singleton<GameManager>
    {
        public Player Player { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Player = GameObject.Find("Player").GetComponent<Player>();  
        }
    }
