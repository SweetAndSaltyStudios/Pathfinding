using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class GameManager : Singelton<GameManager>
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        public Camera MainCamera
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS      

        private void Awake()
        {
            Initialize();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void Initialize()
        {
            MainCamera = Camera.main;        
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
