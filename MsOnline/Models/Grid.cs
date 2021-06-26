using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
//Jacob Hushaw
//Stanley Backlund
//CST-247 Shad Sluiter
//02-12-2020
//this is out own work.

namespace MsOnline.Models
{
    [DataContract]
    public class Grid
    {
        [DataMember]
        public Cell[,] gridOfCells { get; set; }
        [DataMember]
        private int gridSize { get; set; }

        public Grid(int size)
        {
            this.gridSize = size;
            gridOfCells = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gridOfCells[j, i] = new Cell(j, i);
                   
                }
            }
        }

        public int getGridSize()
        {
            return this.gridSize;
        }

        public Cell[,] getGridOfCells()
        {
            return this.gridOfCells;
        }
    }
}
