using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;

    [SerializeField] private SpriteRenderer _correctPlace;

    private bool _dragging, _placed;
    private Vector2 _offset, originalPosition;

    void Awake(){
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_placed) return;
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    void OnMouseUp(){
        if(Vector2.Distance(transform.position, _correctPlace.transform.position) < 1.5){
            transform.position = _correctPlace.transform.position;
            _placed = true;
        }else{
            transform.position = originalPosition;
            _source.PlayOneShot(_dropClip);
        }
        _dragging = false;
    }

    void OnMouseDown(){
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    Vector2 GetMousePos(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
