    public class SearchableWindow : EditorWindow
    {
        private string searchString = "";
        private IEnumerable<GameObject> selected;
    
        [MenuItem("Tools/Searching")]
        private static void Searching()
        {
            const int width = 340;
            const int height = 420;
    
            var x = (Screen.currentResolution.width - width) / 2;
            var y = (Screen.currentResolution.height - height) / 2;
    
            var window = GetWindow<SearchableWindow>();
            window.position = new Rect(x, y, width, height);
    
            window.selected = GetChildrenRecursive(Selection.gameObjects);
        }
    
        private void OnSelectionChange()
        {
            selected = GetChildrenRecursive(Selection.gameObjects);
            Repaint();
        }
    
        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.FlexibleSpace();
            searchString = EditorGUILayout.TextField(searchString, EditorStyles.toolbarTextField);
            EditorGUILayout.EndHorizontal();
    
            // only as fallback
            if (selected == null)
            {
                selected = GetChildrenRecursive(Selection.gameObjects);
            }
    
            // Do comparison here. For example
            foreach (var selectedObject in selected)
            {
                if (selectedObject.name.Contains(searchString))
                {
                    if (GUILayout.Button(selectedObject.name, EditorStyles.label))
                    {
                        EditorGUIUtility.PingObject(selectedObject);
                    }
                }
            }
        }
    
        private static IEnumerable<GameObject> GetChildrenRecursive(GameObject root)
        {
            var output = new List<GameObject>();
    
            // iterate over direct children
            foreach (Transform child in root.transform)
            {
                var childsOfchild = GetChildrenRecursive(child.gameObject);
                output.AddRange(childsOfchild);
    
                // add the children themselves
                output.Add(child.gameObject);
            }
    
            //add the root object itself
            output.Add(root);
    
            return output;
        }
    
        private static IEnumerable<GameObject> GetChildrenRecursive(IEnumerable<GameObject> rootObjects)
        {
            var output = new List<GameObject>();
    
            foreach (var root in rootObjects)
            {
                output.AddRange(GetChildrenRecursive(root));
            }
    
            // remove any duplicates that would e.g. appear if you select a parent and its child
            return output.Distinct();
        }
    }
