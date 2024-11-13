
    using UnityEngine;

    public class GameManager : Singleton<GameManager>
    {
        public Player Player { get; set; }

        public int StageLevel { get; set; } = 1;
        protected override void Awake()
        {
            base.Awake();
            Player = GameObject.Find("Player").GetComponent<Player>();  
        }
    }
