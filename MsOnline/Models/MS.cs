using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Jacob Hushaw
//Stanley Backlund
//CST-247 Shad Sluiter
//02-12-2020
//this is out own work.
namespace MsOnline.Models
{
    public class MS : Grid
    {

        private List<Cell> queue = new List<Cell>();
        private List<Cell> alreadyVisited = new List<Cell>();
        public MS(int size) : base(size)
        {
            setLive();
            setNeighborsLive();
        }

        public void EndGrid(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    getGridOfCells()[j, i].setVisited(true);
                   

                    if (getGridOfCells()[j, i].getCLive())
                    {
                        getGridOfCells()[j, i].setImg("/Images/bomb.png");
                    }
                    else if (getGridOfCells()[j, i].getNeighborsLive() != 0)
                    {
                        
                        if (getGridOfCells()[j, i].getNeighborsLive() == 1)
                        {
                            getGridOfCells()[j, i].setImg("/Images/1.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 2)
                        {
                            getGridOfCells()[j, i].setImg("/Images/2.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 3)
                        {
                            getGridOfCells()[j, i].setImg("/Images/3.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 4)
                        {
                            getGridOfCells()[j, i].setImg("/Images/4.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 5)
                        {
                            getGridOfCells()[j, i].setImg("/Images/5.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 6)
                        {
                            getGridOfCells()[j, i].setImg("/Images/6.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 7)
                        {
                            getGridOfCells()[j, i].setImg("/Images/7.png");
                        }
                        else if (getGridOfCells()[j, i].getNeighborsLive() == 8)
                        {
                            getGridOfCells()[j, i].setImg("/Images/8.png");
                        }
                    }
                    else
                    {
                        getGridOfCells()[j, i].setImg("/Images/clicked.jpg");
                    }
                }
            }
        }
        public int getBombs()
        {
            int bombs = 0;
            for (int i = 0; i < getGridSize(); i++)
            {
                for (int j = 0; j < getGridSize(); j++)
                {
                    if (getGridOfCells()[j, i].getCLive())
                    {
                        bombs++;
                    }
                }
            }
            return bombs;
        }
        public void setLive()
        {
            Random r = new Random();
            int random = r.Next(10, 16);
            int liveCells = (int)Math.Round(random / 100.0 * getGridSize() * getGridSize());
            for (int i = 0; i < liveCells; i++)
            {

                int x = r.Next(getGridSize());
                int y = r.Next(getGridSize());
                if (getGridOfCells()[x, y].getCLive())
                {
                    i--;
                }
                else
                {
                    getGridOfCells()[x, y].setCLive(true);
                }
            }
        }

        public void setNeighborsLive()
        {
            for (int y = 0; y < getGridSize(); y++)
            {
                for (int x = 0; x < getGridSize(); x++)
                {
                    if (getGridOfCells()[x, y].getCLive())
                    {
                       
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                try
                                {
                                    if (j == 0 && i == 0)
                                    {

                                    }
                                    else
                                    {
                                        getGridOfCells()[x + j, y + i].setNeighborsLive();
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
        }



        public bool playGame(Cell c)
        {

            if (c.getVisited())
            {
                return true;
            }
            else
            {
                if (c.getCLive())
                {
                    c.setVisited(true);
                    c.setImg("/Images/bomb.png");
                    return false;
                }
                else
                {
                    if (c.getNeighborsLive() == 0)
                    {
                        queue.Add(c);
                        search();
                        //still alive
                        return true;
                    }
                    else
                    {
                        //cell has been visited
                        c.setVisited(true);
                        //setimage to number of neighbors live
                        if (c.getNeighborsLive() == 1)
                        {
                            c.setImg("/Images/1.png");
                        }else if(c.getNeighborsLive() == 2)
                        {
                            c.setImg("/Images/2.png");
                        }
                        else if(c.getNeighborsLive() == 3)
                        {
                            c.setImg("/Images/3.png");
                        }
                        else if (c.getNeighborsLive() == 4)
                        {
                            c.setImg("/Images/4.png");
                        }
                        else if (c.getNeighborsLive() == 5)
                        {
                            c.setImg("/Images/5.png");
                        }
                        else if (c.getNeighborsLive() == 6)
                        {
                            c.setImg("/Images/6.png");
                        }
                        else if (c.getNeighborsLive() == 7)
                        {
                            c.setImg("/Images/7.png");
                        }
                        else if (c.getNeighborsLive() == 8)
                        {
                            c.setImg("/Images/8.png");
                        }
                        //still alive
                        return true;
                    }
                }
            }
        }

        public void search()
        {
            if (alreadyVisited.Count != 0)
            {
                for (int i = 0; i < alreadyVisited.Count; i++)
                {
                    for (int j = 0; j < queue.Count; j++)
                    {
                        if (queue[j].equals(alreadyVisited[i]))
                        {
                            queue.Remove(queue[j]);
                        }
                    }
                }
            }

            if (queue.Count == 0)
            {
                return;
            }

            int y = queue[0].GetCculumn();
            int x = queue[0].GetCrow();

            if (!getGridOfCells()[x, y].getCLive() && getGridOfCells()[x, y].getNeighborsLive() == 0)
            {
                getGridOfCells()[x, y].setVisited(true);
                getGridOfCells()[x, y].setImg("/Images/clicked.jpg");

            }


           
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    try
                    {
                        if (j == 0 && i == 0)
                        {

                        }
                        else
                        {
                            if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 0 && !getGridOfCells()[x + j, y + i].getVisited())
                            {
                                queue.Add(getGridOfCells()[x + j, y + i]);
                            }
                            else if (!getGridOfCells()[x + j, y + i].getVisited())
                            {
                                getGridOfCells()[x + j, y + i].setVisited(true);
                                if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 1)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/1.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 2)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/2.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 3)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/3.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 4)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/4.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 5)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/5.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 6)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/6.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 7)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/7.png");
                                }
                                else if (getGridOfCells()[x + j, y + i].getNeighborsLive() == 8)
                                {
                                    getGridOfCells()[x + j, y + i].setImg("/Images/8.png");
                                }
                                

                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }

            alreadyVisited.Add(new Cell(x, y));

            queue.RemoveAt(0);
            if (queue.Count != 0)
            {
                search();
            }
        }
    }
}
