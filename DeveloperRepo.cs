using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Developer;

namespace _DeveloperRepo
{
    public class DeveloperRepo
    {
        private List<Developer> allDevelopers = new List<Developer>();
        public DeveloperRepo()
        {
        }

        public List<Developer> getListOfDevelopers()
        {
            return allDevelopers;
        }
        public void addDeveloper(Developer developerPlaceholder)
        {
            allDevelopers.Add(developerPlaceholder);
        }

        //Create
        // public void addDeveloper(string devName, string uniqueID, bool hasPluralsight, string devTeamName)
        // {
        //     Developer addingDev = new Developer(devName, uniqueID, hasPluralsight, devTeamName);
        //     allDevelopers.Add(addingDev);
        // }
        // public void addDeveloper_GenerateID(string devName, bool hasPluralsight, string devTeamName)
        // {   
        //     string threeLetter = "";
        //     while(true){
        //         string counter = generateUniqueID();
        //         if(isDuplicateID(counter)){
        //             continue;
        //         }else{
        //             threeLetter = counter;
        //             break;
        //         }

        //     }
        //     Developer addingDev = new Developer(devName, threeLetter, hasPluralsight, devTeamName);
        //     allDevelopers.Add(addingDev);

        // }
        public string generateUniqueID()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            string uniqueID = "";
            while (true)
            {
                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    int rng = random.Next(0, 35);
                    uniqueID += chars[rng];
                }
                if (isDuplicateID(uniqueID) == true)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            return uniqueID;


        }
        public bool isDuplicateID(string threeChar)
        {

            foreach (Developer devPerson in allDevelopers)
            {
                if (devPerson.getID() == threeChar)
                {
                    return true;
                }
            }
            return false;

        }
        //Read
        public Developer getDeveloperInfoByID(string uniqueID)
        {
            foreach (Developer devMember in allDevelopers)
            {
                if (devMember.getID() == uniqueID)
                {
                    return devMember;
                }
            }
            System.Console.WriteLine("nobody exists");
            return null;
        }
        public List<Developer> getAllDevInDevRepo()
        {
            return allDevelopers;
        }

        public void updateDeveloperByID(string uniqueID, string name, bool hasPluralsight, string devTeamName)
        {
            foreach (Developer devMember in allDevelopers)
            {
                if (devMember.getID() == uniqueID)
                {
                    devMember.setName(name);
                    devMember.setPS_Status(hasPluralsight);
                    devMember.setDevTeamName(devTeamName);
                }
            }
            System.Console.WriteLine("nobody exists");

        }
        //Delete
        public void removeDeveloperByID(string uniqueID)
        {
            Developer counterDeveloper = null; 

            foreach (Developer devMember in allDevelopers)
            {
                if (devMember.getID() == uniqueID)
                {
                    counterDeveloper = devMember;
                }
            }
            if(counterDeveloper == null){
                return;
            }
            else{
                allDevelopers.Remove(counterDeveloper);
            }

        }

        public List<Developer> returnListOfNonLicenseHolders()
        {
            List<Developer> nonLicenseHolders = new List<Developer>();
            foreach (Developer devMember in allDevelopers)
            {
                if (devMember.getPS_Status() == false)
                {
                    nonLicenseHolders.Add(devMember);
                }
            }
            return nonLicenseHolders;
        }

        public List<Developer> notInATeam()
        {
            List<Developer> newList = new List<Developer>();
            foreach (Developer devMember in allDevelopers)
            {
                if (devMember.getDevTeamName() != "None")
                {
                    continue;
                }
                else
                {
                    newList.Add(devMember);
                }
            }
            return newList;
        }




    }
}