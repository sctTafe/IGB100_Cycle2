using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
namespace ScottBarley.IGB100.TESTING
{
    /// Adds a button to the Unity Editor Inspector Window 
    //[CustomEditor(typeof(DoTweenDelegateTest))]
    //public class Editor_Examples : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        DrawDefaultInspector();

    //        DoTweenDelegateTest ex = (DoTweenDelegateTest)target;
    //        if (GUILayout.Button("Test"))
    //        {
    //            ex.fn_TEST();
    //        }
    //    }
    //}
    public class DoTweenDelegateTest : MonoBehaviour
    {
        private delegate float testDelegate(float f);


        public void fn_TEST()
        {

        }    
    }


   
}
