using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObjectsHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _mergeClip;
    [SerializeField] private GameObject _mergeEffectPrefab;
    private bool _isDragging = false;
    private Transform _draggedObject;

    private Vector2 _offset;

    void Update()
    {
        if (_isDragging)
        {
            Vector2 mousePosition = GetMousePos();
            _draggedObject.position = mousePosition - _offset;
        }
    }

    void OnMouseUp()
    {
        if (_isDragging)
        {
            Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(_draggedObject.position, 0.2f); // Adjust the circle radius as needed

            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.gameObject != _draggedObject.gameObject && collider.CompareTag("Mergeable"))
                {
                    MergeObjects(_draggedObject.gameObject, collider.gameObject);
                    return;
                }
            }

            _isDragging = false;
        }
    }

    void OnMouseDown()
    {
        _isDragging = true;
        _draggedObject = transform;

        _offset = GetMousePos() - (Vector2)transform.position;
    }

    void MergeObjects(GameObject object1, GameObject object2)
    {
        Vector3 newPosition = (object1.transform.position + object2.transform.position) / 2f;
        Vector3 newScale = (object1.transform.localScale + object2.transform.localScale);

        object1.transform.position = newPosition;
        object1.transform.localScale = newScale;

        AudioSource.PlayClipAtPoint(_mergeClip, newPosition);

        if (_mergeEffectPrefab != null)
        {
            Instantiate(_mergeEffectPrefab, newPosition, Quaternion.identity);
        }

        // Remove both objects from the scene
        Destroy(object2);
        _isDragging = false;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
