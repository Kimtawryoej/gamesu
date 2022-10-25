using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public interface IState
    {
        void OnEnter(Player Player);
        void Update();
        void OnExit();
    }

