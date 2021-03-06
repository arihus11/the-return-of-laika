using UnityEngine;

namespace Laika.Utils
{
    public enum MovementState
    {
        Steady,
        UpwardIdle,
        UpwardMoving,
        LeftIdle,
        LeftMoving,
        RightIdle,
        RightMoving,
        DownwardIdle,
        DownwardMoving
    }

    public enum CollisionMessageObjectTag
    {
        boundary,
        grabbableItem,
        grabbableShip,
        ship,
    }

    public enum ShipPartEnum
    {
        None,
        Part1,
        Part2,
        Part3,
        Part4,
        Part5,
    }

    public class Methods
    {
        public static bool isGrabbable(string tag)
        {
            return tag == CollisionMessageObjectTag.grabbableShip.ToString() || tag == CollisionMessageObjectTag.grabbableItem.ToString();
        }

        public static bool isGrabbableShip(string tag)
        {
            return tag == CollisionMessageObjectTag.grabbableShip.ToString();
        }

        public static bool isGrabbableItem(string tag)
        {
            return tag == CollisionMessageObjectTag.grabbableItem.ToString();
        }

        public static bool isBoundary(string tag)
        {
            return tag == CollisionMessageObjectTag.boundary.ToString();
        }

        public static bool isShip(string tag)
        {
            return tag == CollisionMessageObjectTag.ship.ToString();
        }

        public static ShipPartEnum getShipPartID(GameObject shipPart)
        {
            return shipPart.GetComponent<ShipPartID>().shipPartID;
        }
    }
}