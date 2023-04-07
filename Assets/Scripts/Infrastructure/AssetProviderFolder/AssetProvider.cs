using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetProviderFolder
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Load(string assetPath)
        {
            return Resources.Load<GameObject>(assetPath);
        }
    }
}
