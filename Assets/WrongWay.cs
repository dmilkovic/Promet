using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWay : MonoBehaviour {
    public bool flag1;
    public bool flag2;

    public WrongWay()
    {
        this.flag1 = false;
        this.flag2 = false;
    }

    public void isWrongWay() {
        if (this.flag2 && !this.flag1) {
            Debug.Log("Krivi smjer!");
        }
    }
    /*  private void OnTriggerEnter(Collider other)
      {
          if (other.GetComponent<Collider>().GetType() == typeof(BoxCollider))
          {
              Debug.Log("Usao u kocku" + other.GetComponent<Collider>().GetType());
              // do stuff only for the box collider
          }
          else if (other.GetComponent<Collider>().GetType() == typeof(CapsuleCollider))
          {
              Debug.Log("Usao u kapsulu" + other.name);
          }
      }
      private void OnTriggerExit(Collider other)
      {
          Debug.Log("Izasao");
      }*/

   /* public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }*/

}
