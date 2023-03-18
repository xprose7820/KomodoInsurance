using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _DevTeam;
using _Developer;

namespace _DevTeamRepo
{
    public class DevTeamRepo
    {
        private List<DevTeam> allDevTeams = new List<DevTeam>();

        public DevTeamRepo()
        {

        }

        public List<DevTeam> getListOfDevTeams()
        {
            return allDevTeams;
        }
        public void addDevTeam(DevTeam devTeam)
        {
            allDevTeams.Add(devTeam);
        }
        public DevTeam getDevTeamInfoByID(string uniqueTeamID)
        {
            foreach (DevTeam devTeam in allDevTeams)
            {
                if (devTeam.getTeamID() == uniqueTeamID)
                {
                    return devTeam;
                }
            }
            System.Console.WriteLine("No team exists.\n");
            return null;
        }
        public void updateDevTeamNameByID(string uniqueTeamID, string teamName)
        {
            foreach (DevTeam devTeam in allDevTeams)
            {
                if (devTeam.getTeamID() == uniqueTeamID)
                {
                    devTeam.setTeamName(teamName);

                }
            }
            System.Console.WriteLine("nobody exists");

        }
        public string generateUniqueID()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            string uniqueID = "";
            while (true)
            {
                Random random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    int rng = random.Next(0, 35);
                    uniqueID += chars[rng];
                }
                if(isDuplicateID(uniqueID) == true){
                    continue;
                }
                else{
                    break;
                }
            }
            return uniqueID;


        }
        public bool isDuplicateID(string fourChar)
        {

            foreach (DevTeam devTeamObj in allDevTeams)
            {
                if (devTeamObj.getTeamID() == fourChar)
                {
                    return true;
                }
            }
            return false;

        }
        // already made sure team exists
        public void addTeamMemberToDevTeam(Developer devMember, string uniqueTeamID)
        {
            DevTeam counterDevTeam = getDevTeamInfoByID(uniqueTeamID);
            counterDevTeam.addDeveloper(devMember);

        }
        public void removeTeamMemberFromDevTeam(Developer devMember, string uniqueTeamID)
        {
            DevTeam counterDevTeam = getDevTeamInfoByID(uniqueTeamID);
            counterDevTeam.removeDeveloper(devMember);
        }
        public void removeDevTeamFromRepo(DevTeam devTeamMember){
            allDevTeams.Remove(devTeamMember);
        }

    }
}