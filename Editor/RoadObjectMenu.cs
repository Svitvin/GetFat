using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TNRD.Utilities;
using UnityEngine;

public class RoadObjectMenu : EditorWindow
{

    [MenuItem("GameObject/ObjectPoint/Burger", false, 20)]
    public static void CreateBurgerPoint(MenuCommand menuCommand)
    {
        GameObject newPoint = new GameObject("Coin");
        GameObjectUtility.SetParentAndAlign(newPoint, menuCommand.context as GameObject);
        CoinPoint burgerPoint = newPoint.AddComponent<CoinPoint>();
        newPoint.AddComponent<ObjectUpdater>();
        Undo.RegisterCreatedObjectUndo(newPoint, "Create " + newPoint.name);
        IconManager.SetIcon(newPoint, LabelIcon.Orange);
        Selection.activeObject = newPoint;
        newPoint.tag = "Coin";
    }

    [MenuItem("GameObject/ObjectPoint/Enemy", false, 20)]
    public static void CreateEnemyPoint(MenuCommand menuCommand)
    {
        GameObject newPoint = new GameObject("Enemy");
        GameObjectUtility.SetParentAndAlign(newPoint, menuCommand.context as GameObject);
        EnemyPoint enemyPoint = newPoint.AddComponent<EnemyPoint>();
        newPoint.AddComponent<ObjectUpdater>();
        Undo.RegisterCreatedObjectUndo(newPoint, "Create " + newPoint.name);
        IconManager.SetIcon(newPoint, LabelIcon.Red);
        Selection.activeObject = newPoint;
        newPoint.tag = "Enemy";
    }

    [MenuItem("GameObject/ObjectPoint/Wall", false, 20)]
    public static void CreateWallPoint(MenuCommand menuCommand)
    {
        GameObject newPoint = new GameObject("Wall");
        GameObjectUtility.SetParentAndAlign(newPoint, menuCommand.context as GameObject);
        WallPoint wallPoint = newPoint.AddComponent<WallPoint>();
        newPoint.AddComponent<ObjectUpdater>();
        Undo.RegisterCreatedObjectUndo(newPoint, "Create " + newPoint.name);
        IconManager.SetIcon(newPoint, LabelIcon.Blue);
        Selection.activeObject = newPoint;
        newPoint.tag = "Wall";
    }

    [MenuItem("GameObject/ObjectPoint/Toxic", false, 20)]
    public static void CreateTreadmillPoint(MenuCommand menuCommand)
    {
        GameObject newPoint = new GameObject("Toxic");
        GameObjectUtility.SetParentAndAlign(newPoint, menuCommand.context as GameObject);
        ToxicPoint treadmillPoint = newPoint.AddComponent<ToxicPoint>();
        newPoint.AddComponent<ObjectUpdater>();
        Undo.RegisterCreatedObjectUndo(newPoint, "Create " + newPoint.name);
        IconManager.SetIcon(newPoint, LabelIcon.Yellow);
        Selection.activeObject = newPoint;
        newPoint.tag = "Toxic";
    }

    [MenuItem("GameObject/ObjectPoint/Camera", false, 20)]
    public static void CreateCameraPoint(MenuCommand menuCommand)
    {
        GameObject newPoint = new GameObject("Camera");
        GameObjectUtility.SetParentAndAlign(newPoint, menuCommand.context as GameObject);
        CameraPoint cameraPoint = newPoint.AddComponent<CameraPoint>();
        newPoint.AddComponent<ObjectUpdater>();
        Undo.RegisterCreatedObjectUndo(newPoint, "Create " + newPoint.name);
        IconManager.SetIcon(newPoint, LabelIcon.Gray);
        Selection.activeObject = newPoint;
        newPoint.tag = "Camera";
    }
}
