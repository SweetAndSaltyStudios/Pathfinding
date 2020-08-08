using System;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    [Serializable]
    public class Node
    {
        #region VARIABLES

        [SerializeField]
        private Vector2 position;
        [SerializeField]
        private bool isWalkable;

        #endregion VARIABLES

        #region PROPERTIES

        public Vector2 WorldPosition
        {
            get
            {
                return position;
            }
        }

        public bool IsWalkable
        {
            get
            {
                return isWalkable;
            }
            set
            {
                isWalkable = value;
            }
        }

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public Node(Vector2 position, bool isWalkable)
        {
            this.position = position;
            this.isWalkable = isWalkable;
        }

        #endregion CONSTRUCTORS

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}
