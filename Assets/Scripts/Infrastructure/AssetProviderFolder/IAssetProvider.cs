using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetProviderFolder
{
    public interface IAssetProvider:IService
    {
        public GameObject Load(string assetPath);
    }
}