using UnityEditor;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolPathEditor : Editor
    {
        #region Public methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fill in Points"))
            {
                ((PatrolPath)target).FillPoints();

                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
        }

        #endregion
    }
}