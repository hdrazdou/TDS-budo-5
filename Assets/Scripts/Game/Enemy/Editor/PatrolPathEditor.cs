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

        #region Private methods

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmo(PatrolPath path, GizmoType gizmoType)
        {
            if (!IsGoOrChildSelected(path))
            {
                return;
            }

            if (path.Points == null || path.Points.Length == 0)
            {
                return;
            }

            Gizmos.color = Color.cyan;
            Vector3 previousPosition = path.Points[0].position;
            Gizmos.DrawSphere(previousPosition, 0.2f);

            for (int i = 1; i < path.Points.Length; i++)
            {
                Vector3 currentPosition = path.Points[i].position;
                Gizmos.DrawSphere(currentPosition, 0.2f);

                Gizmos.DrawLine(previousPosition, currentPosition);

                previousPosition = currentPosition;
            }

            Gizmos.DrawLine(previousPosition, path.Points[0].position);
        }

        private static bool IsGoOrChildSelected(MonoBehaviour monoBeh)
        {
            GameObject activeGo = Selection.activeGameObject;

            if (activeGo == null)
            {
                return false;
            }

            if (monoBeh.gameObject == activeGo)
            {
                return true;
            }

            for (int i = 0; i < monoBeh.transform.childCount; i++)
            {
                if (monoBeh.transform.GetChild(i).gameObject == activeGo)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}