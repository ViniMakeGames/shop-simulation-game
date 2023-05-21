using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{
    private SpriteRenderer _body;
    private SpriteRenderer _eyes;
    private SpriteRenderer _hair;
    private SpriteRenderer _glasses;
    private SpriteRenderer _hat;
    private SpriteRenderer _top;
    private SpriteRenderer _pants;
    private SpriteRenderer _shoes;
    private GameObject _blackBox;

    private void Awake()
    {
        _body = transform.Find("Body").GetComponent<SpriteRenderer>();
        _eyes = transform.Find("Eyes").GetComponent<SpriteRenderer>();
        _hair = transform.Find("Hair").GetComponent<SpriteRenderer>();
        _glasses = transform.Find("Glasses").GetComponent<SpriteRenderer>();
        _hat = transform.Find("Hat").GetComponent<SpriteRenderer>();
        _top = transform.Find("Top").GetComponent<SpriteRenderer>();
        _pants = transform.Find("Pants").GetComponent<SpriteRenderer>();
        _shoes = transform.Find("Shoes").GetComponent<SpriteRenderer>();
        _blackBox = transform.Find("BlackBox").gameObject;
    }

    [SerializeField] private VisualData _bodyVisual;
    [SerializeField] private VisualData _eyesVisual;
    [SerializeField] private VisualData _hairVisual;
    [SerializeField] private VisualData _glassesVisual;
    [SerializeField] private VisualData _hatVisual;
    [SerializeField] private VisualData _topVisual;
    [SerializeField] private VisualData _pantsVisual;
    [SerializeField] private VisualData _shoesVisual;

    public void SetBodyColor(Color color) => _body.color = color;
    public void SetHairColor(Color color) => _hair.color = color;
    public void SetEyesColor(Color color) => _eyes.color = color;

    public void SetGlasses(ItemData item)
    {
        var remove = item == null;
        _glasses.gameObject.SetActive(!remove);

        if (remove) return;

        _glassesVisual = item.visual;
        _glasses.color = item.color;
    }
    
    public void SetHat(ItemData item)
    {
        var remove = item == null;
        _hat.gameObject.SetActive(!remove);

        if (remove) return;

        _hatVisual = item.visual;
        _hat.color = item.color;
    }
    
    public void SetTop(ItemData item)
    {
        var remove = item == null;
        _top.gameObject.SetActive(!remove);

        if (remove) return;

        _topVisual = item.visual;
        _top.color = item.color;
    }
    
    public void SetPants(ItemData item)
    {
        var remove = item == null;
        _pants.gameObject.SetActive(!remove);
        _blackBox.SetActive(remove);
        
        if (remove) return;

        _pantsVisual = item.visual;
        _pants.color = item.color;
    }
    
    public void SetShoes(ItemData item)
    {
        var remove = item == null;
        _shoes.gameObject.SetActive(!remove);

        if (remove) return;

        _shoesVisual = item.visual;
        _shoes.color = item.color;
    }

    public bool playAnimation;
    public float animationSpeed;
    private int _currentFrame;
    private float _animationTimer;
    private int _currentDirection = 2;

    public void SetAnimationDirection(int direction) => SetAnimation(_currentFrame, direction, playAnimation);
    public void SetAnimation(bool play) => SetAnimation(_currentFrame, play);
    public void SetAnimation(int frame, bool play) => SetAnimation(frame, _currentDirection, play);
    public void SetAnimation(int frame, int direction, bool play)
    {
        playAnimation = play;
        _currentFrame = frame;
        _currentDirection = direction;
        
        UpdateFrames();
    }
    
    private void Update()
    {
        if (!playAnimation) return;

        if (_animationTimer < 1f)
        {
            _animationTimer += animationSpeed * Time.deltaTime;
            return;
        }

        _animationTimer = 0f;
        _currentFrame = _currentFrame + 1 <= 3 ? _currentFrame + 1 : 0;
        UpdateFrames();
    }

    private void UpdateFrames()
    {
        UpdateVisual(_body, _bodyVisual);
        UpdateVisual(_eyes, _eyesVisual);
        UpdateVisual(_hair, _hairVisual);
        UpdateVisual(_glasses, _glassesVisual);
        UpdateVisual(_hat, _hatVisual);
        UpdateVisual(_top, _topVisual);
        UpdateVisual(_pants, _pantsVisual);
        UpdateVisual(_shoes, _shoesVisual);
    }

    private void UpdateVisual(SpriteRenderer spr, VisualData visual)
    {
        if (!spr.gameObject.activeSelf) return;
        spr.sprite = visual.GetSpritesByDirection(_currentDirection)[_currentFrame];
    }
}
