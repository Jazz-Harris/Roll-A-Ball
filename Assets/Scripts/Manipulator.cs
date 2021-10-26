using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Use transform.Translate and pass on user-defined values of x, y, and z if the user selects the Transform option.
/// 
/// Use transform.Rotate and pass on user-defined values of x, y, and z if the user selects the Rotation option.
/// Repeat the same for the scale.
/// 
/// For reset, just restore the original values of X, Y, Z to the gameObject’s local.transform, rotation and scale
/// → you have already stored the initial positions in the Start(), so just restore them back.
/// 
/// &&&
///
/// When you scale the object, you should scale it for only one frame (like I showed in the video).
/// The GameObject should NOT constantly scale and keep expanding.
///
/// &&&
///
/// if I enable the boolean value of any one of these(translate,rotate,scale , and reset), then the boolean values for the rest of the three components should be disabled in the inspector.
/// Which means at a given time I should be able to apply only one functionality(either translate/rotate/scale).
///
/// This requirement holds 10 points in this part of the assignment.
/// </summary>
public class Manipulator : MonoBehaviour
{
    
    public bool transformObject = false;
    public bool rotateObject = false;
    public bool scaleObject = false;
    public bool reset = false;
    public float speed = 2.0f;
   
    
    public float _xAxis;
    public float _yAxis;
    public float _zAxis;
    
    private Vector3 startPosition;
  


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
     

        // Uses user input for x,y and z axis to transform, rotate or scale objectß

        if(transformObject == true)
        {
            rotateObject = false;
            scaleObject = false;
            reset = false;
            transform.Translate(new Vector3(_xAxis, _yAxis, _zAxis)*Time.deltaTime);
        }

        else if (rotateObject == true)
        {
            transformObject = false;
            scaleObject = false;
            reset = false;
            transform.Rotate(new Vector3(_xAxis, _yAxis, _zAxis) * Time.deltaTime);
        }

        else if (scaleObject == true)
        {
            transformObject = false;
            rotateObject = false;
            reset = false;
            transform.localScale = (new Vector3(_xAxis, 1, _zAxis));
            
        }

        else if(reset == true)
        {
            transformObject = false;
            rotateObject = false;
            scaleObject = false;
            transform.position = startPosition;
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.identity;





        }



    }
}
