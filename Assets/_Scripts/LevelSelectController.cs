using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] private Transform _camera, minPos, maxPos;
    [SerializeField] private float moveSpeed;


    private void Start()
    {
        AudioManager.instance.PlayLevelSelectMusic();
    }

    private void Update()
    {
        Vector2 adjustMousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        //Move Cam To Right
        if (adjustMousePos.x > .75f)
        {
            if (adjustMousePos.x > .9f)
            {
                _camera.position += _camera.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                _camera.position += _camera.right * moveSpeed * Time.deltaTime * .5f;
            }
        }
        
        //Move Cam To Left
        if (adjustMousePos.x < .25f)
        {
            if (adjustMousePos.x < .1f)
            {
                _camera.position -= _camera.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                _camera.position -= _camera.right * moveSpeed * Time.deltaTime * .5f;
            }
        }
        
        //Move Cam To Up
        if (adjustMousePos.y > .75f)
        {
            if (adjustMousePos.y > .9f)
            {
                _camera.position += _camera.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                _camera.position += _camera.forward * moveSpeed * Time.deltaTime * .5f;
            }
        }
        
        //Move Cam To Down
        if (adjustMousePos.y < .25f)
        {
            if (adjustMousePos.y < .1f)
            {
                _camera.position -= _camera.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                _camera.position -= _camera.forward * moveSpeed * Time.deltaTime * .5f;
            }
        }

        _camera.position = new Vector3(
            Mathf.Clamp(_camera.position.x, minPos.position.x, maxPos.position.x),
            _camera.position.y,
            Mathf.Clamp(_camera.position.z, minPos.position.z, maxPos.position.z));
    }
}
