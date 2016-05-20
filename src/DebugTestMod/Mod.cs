using System;
using UnityEngine;

namespace DebugTestMod
{
    public sealed class Mod : IMod
    {
        public string Name { get { return "Debug Test Mod"; } }
        public string Description { get { return "Test/example mod to demonstrate debugging a Parkitect mod."; } }
        public string Identifier { get; set; }

        private GameObject _go = null;

        public void onEnabled()
        {
            Debug.Log(string.Format("{0} enabled", Name));

            _go = new GameObject();
            _go.AddComponent<Logic>();
        }

        public void onDisabled()
        {
            Debug.Log(string.Format("{0} disabled", Name));

            UnityEngine.Object.Destroy(_go);
            _go = null;
        }
    }

    public sealed class Logic : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) & Input.GetKeyDown(KeyCode.F9))
            {
                Debug.Log("Ctrl+F9");
            }
            else if (Input.GetKey(KeyCode.LeftControl) & Input.GetKeyDown(KeyCode.F10))
            {
                Debug.Log("Ctrl+F10 -> throwing exception");
                throw new Exception("Ctrl+F10");
            }
        }
    }
}