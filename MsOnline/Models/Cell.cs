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
    public class Cell
    {
        //properties
        [DataMember]
        private int Crow { get; set; }
        [DataMember]
        private int Ccolumn { get; set; }
        [DataMember]
        private bool visited { get; set; }
        [DataMember]
        private bool live { get; set; }
        [DataMember]
        private int neighborsLive { get; set; }
        [DataMember]
        private bool isFlagged { get; set; }
        [DataMember]
        private string img { get; set; }

        //constructor
        public Cell()
        {
            this.Crow = -1;
            this.Ccolumn = -1;
            this.visited = false;
            this.live = false;
            this.neighborsLive = 0;
            this.isFlagged = false;
            this.img = "/Images/unclicked.jpg";
           
        }

        public Cell(int row, int column)
        {
            Crow = row;
            Ccolumn = column;
            visited = false;
            live = false;
            neighborsLive = 0;
            this.isFlagged = false;
            this.img = "/Images/unclicked.jpg";
        }

        public string getImg()
        {
            return this.img;
        }
        public void setImg(string img)
        {
            this.img = img;
        }
        public int GetCrow()
        {
            return this.Crow;
        }

        public void setCrow(int r)
        {
            this.Crow = r;
        }

        public int GetCculumn()
        {
            return this.Ccolumn;
        }

        public void setCculumn(int c)
        {
            this.Ccolumn = c;
        }

        public bool getVisited()
        {
            return this.visited;
        }

        public void setVisited(bool v)
        {
            this.visited = v;
        }

        public bool getCLive()
        {
            return this.live;
        }

        public void setCLive(bool l)
        {
            this.live = l;
        }

        public int getNeighborsLive()
        {
            return this.neighborsLive;
        }

        public void setNeighborsLive()
        {
            this.neighborsLive++;
        }

        public bool equals(Cell c)
        {
            if (c.Crow == Crow && c.Ccolumn == Ccolumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void flagCell()
        {
           
            this.isFlagged = true;
            this.setImg("/Images/flag.png");

        }

        public void unFlag()
        {
        
            this.isFlagged = false;
            this.setImg("/Images/unclicked.jpg");
        }

        public bool isflagged()
        {
            if (this.isFlagged == true)
                return true;
            else return false;
        }
    }
}
