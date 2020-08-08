using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class MapManager : MonoBehaviour
    {
        #region VARIABLES

        public Texture2D LevelTexture;
        public LevelObject[] LevelObjects;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            CreateLevel(LevelTexture);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void CreateLevel(Texture2D levelTexture)
        {
            var pixels = levelTexture.GetPixels32();
            var levelWidth = levelTexture.width;
            var levelHeight = levelTexture.height;

            for(int x = 0; x < levelWidth; x++)
            {
                for(int y = 0; y < levelHeight; y++)
                {
                    var newLevelObjectInstance = SpawnGameAssetAtPosition(
                        pixels[x + (y * levelWidth)],
                        x,
                        y);
                }
            }
        }

        private GameObject SpawnGameAssetAtPosition(Color32 color, int x, int y)
        {
            if(color.a == 0)
            {
                return null;
            }

            foreach(var levelObject in LevelObjects)
            {
                if(levelObject.ColorIndex.Equals(color))
                {
                    var newGameAsset = Instantiate(
                        levelObject.Prefab,
                        new Vector2(x, y),
                        Quaternion.identity,
                        transform);

                    return newGameAsset;
                }
            }

            Debug.LogError($"No tile type found with pixel color: {color}");
            return null;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
