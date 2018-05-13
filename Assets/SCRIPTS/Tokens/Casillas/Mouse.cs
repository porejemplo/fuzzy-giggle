using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mouse : InventoryPosition
{
    [Header("Event References")]
    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    private InventoryPosition from;
    private InventoryPosition to;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            from = GetObject();

            if (from && from.drag)
            {
                transform.position = Input.mousePosition;
                from.Visible();
                setPosition(from.token);
            }
        }
        //Mover el objeto
        else if (token && Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;
        }
        //Resolucion
        else if (token && Input.GetMouseButtonUp(0))
        {
            to = GetObject();
            if (InGame(Input.mousePosition))
            {
                from.Clear();
            }
            else if (to && !to.drag)
            {
                if(to.setPosition(from.token))
                    from.Clear();
            }
            else if (to && to.drag)
            {
                Token ip = to.token;
                to.setPosition(from.token);
                from.setPosition(ip);
            }
            from.Visible(true);
            Clear();
        }
	}

    private InventoryPosition GetObject()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>(12);

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            InventoryPosition ip = result.gameObject.GetComponentInChildren<InventoryPosition>();

            if (ip)
                return ip;
        }
        return null;
    }

    public override bool setPosition(Token t)
    {
        if (!t)
        {
            Clear();
            return true;
        }

        return base.setPosition(t);
    }

    public bool InGame(Vector2 v)
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = v;//Input.mousePosition;
        
        List<RaycastResult> results = new List<RaycastResult>(12);

        m_Raycaster.Raycast(m_PointerEventData, results);
        
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Game"))
                return true;
        }

        return false;
    }
}
