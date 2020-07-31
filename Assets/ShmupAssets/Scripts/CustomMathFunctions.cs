using System.Collections;
using UnityEngine;

namespace CustomMathFunctions
{
    public struct CMath
    {
        //returns a quaternion for the angle between two GameObjects
        public Quaternion DirCalc(GameObject obj1, GameObject obj2)
        {
            Vector2 difference = obj1.transform.position - obj2.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
            return Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }

        //adds an arbitrary angle
        public Quaternion DirCalc(GameObject obj1, GameObject obj2, float angle)
        {
            Vector2 difference = obj1.transform.position - obj2.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
            return Quaternion.Euler(0.0f, 0.0f, rotationZ + angle);
        }

        //only uses an arbitrary angle
        public Quaternion DirCalc(GameObject obj, float angle)
        {
            Vector2 difference = obj.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
            return Quaternion.Euler(0.0f, 0.0f, rotationZ + angle);
        }

    }
}