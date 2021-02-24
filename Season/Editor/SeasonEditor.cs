using UnityEditor;

[CustomEditor(typeof(SeasonManager))]
public class SeasonEditor : Editor
{
    private SeasonManager _target;

    public override void OnInspectorGUI()
    {
        _target = target as SeasonManager;
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("現在の季節は"+_target.current_season_jpn);
        
        _target.isSimulateSeason = EditorGUILayout.ToggleLeft("IsSimulateSeason", _target.isSimulateSeason);

        if (_target.isSimulateSeason)
        {
            var simulateDate = serializedObject.FindProperty("simulateDate");
            EditorGUILayout.PropertyField(simulateDate);
            ClampDayProperty(simulateDate);

            serializedObject.ApplyModifiedProperties();
        }
        
        _target.setSeasonStart = EditorGUILayout.ToggleLeft("SetSeasonStart",_target.setSeasonStart);
        if (_target.setSeasonStart)
        {
            var springStart = serializedObject.FindProperty("springStart");
            EditorGUILayout.PropertyField(springStart);
            ClampDayProperty(springStart);
            
            var summerStart = serializedObject.FindProperty("summerStart");
            EditorGUILayout.PropertyField(summerStart);
            ClampDayProperty(summerStart);
            
            var fallStart = serializedObject.FindProperty("fallStart");
            EditorGUILayout.PropertyField(fallStart);
            ClampDayProperty(fallStart);
            
            var winterStart = serializedObject.FindProperty("winterStart");
            EditorGUILayout.PropertyField(winterStart);
            ClampDayProperty(winterStart);
            
            serializedObject.ApplyModifiedProperties();
        }
    }

    private void ClampDayProperty(SerializedProperty property)
    {
        if (property.FindPropertyRelative("month").intValue > 12)
            property.FindPropertyRelative("month").intValue = 1;
        if (property.FindPropertyRelative("month").intValue <= 0)
            property.FindPropertyRelative("month").intValue = 12;
        if (property.FindPropertyRelative("day").intValue > 31)
            property.FindPropertyRelative("day").intValue = 1;
        if (property.FindPropertyRelative("day").intValue <= 0)
            property.FindPropertyRelative("day").intValue = 31;
    }
    
}
