using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Developer;

namespace _DevTeam
{
    public class DevTeam
    {
        private string teamName = "";
        private string uniqueTeamID = "";
        private List<Developer> myTeamMembers = new List<Developer>();
        public DevTeam(string teamName, string uniqueTeamID){
            
            this.teamName = teamName;
            this.uniqueTeamID = uniqueTeamID;
        }
        public string getTeamName(){
            return teamName;
        }
        public void setTeamName(string teamName){
            this.teamName = teamName;
        }
        public string getTeamID(){
            return uniqueTeamID;
        }
        public void setTeamID(string uniqueTeamID){
            this.uniqueTeamID = uniqueTeamID;
        }
        public void addDeveloper(Developer devMember){
            myTeamMembers.Add(devMember);
        }
        public void removeDeveloper(Developer devMember){
            myTeamMembers.Remove(devMember);
        }
        public List<Developer> getTeamMembers(){
            return myTeamMembers;
        }

        
    }
}