using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Developer
{
    public class Developer
    {
        private string name = "";
        private string uniqueID = "";

        private bool hasPluralsight = false;

        private string devTeamName = "";

        public Developer(string name, string uniqueID, bool hasPluralsight, string devTeamName){
            this.name = name;
            this.uniqueID = uniqueID;
            this.hasPluralsight = hasPluralsight;
            this.devTeamName = devTeamName;
        }

        public string getName(){
            return name;
        }
        public void setName(string name){
            this.name = name;
        }
        public string getID(){
            return uniqueID;
        }
        public void setID(string uniqueID){
            this.uniqueID = uniqueID;
        }
        public bool getPS_Status(){
            return hasPluralsight;
        }
        public void setPS_Status(bool hasPluralsight){
            this.hasPluralsight = hasPluralsight;
        }
        public string getDevTeamName(){
            return devTeamName;
        }
        public void setDevTeamName(string devTeamName){
            this.devTeamName = devTeamName;
        }




        
    }
}