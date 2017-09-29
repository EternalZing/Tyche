using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.System.StatusSystem {
    [Serializable]
    public class GameStatus : MonoBehaviour {
        public object this[string index] {
            get {
                return this._gameStatus[index];
            }
            set {
                if (this._gameStatus.ContainsKey(index)) {
                    this._gameStatus[index] = value;
                }
                else { 
                    this._gameStatus.Add(index,value);
                }
                
            }
        }

        public T GetStatus<T>(string s) {
            return (T) _gameStatus[s];
        }

        public void SetStatus<T>(string s,T value) {
            this[s] = value;
        }

        public bool HasStatus(string s) {
            return _gameStatus.ContainsKey(s);
        }
        private Dictionary<string, object> _gameStatus = new Dictionary<string, object>() ;
        string ToJson() {

        
            return JsonUtility.ToJson( this );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static GameStatus FromJson(string jsonStr) {
            return JsonUtility.FromJson<GameStatus>( jsonStr );
        }

        public GameStatus() {
            InitStatus();
        }
        public virtual void InitStatus() {
           
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}