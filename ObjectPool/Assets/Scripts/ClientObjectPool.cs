using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.ObjectPool
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroneObjectPool _pool;
        // Start is called before the first frame update
        void Start()
        {
            _pool = gameObject.AddComponent<DroneObjectPool>();
        }
        private void OnGUI()
        {
            if (GUILayout.Button("SpawnDrones"))
            {
                _pool.Spawn();
            }
        }
    }
}