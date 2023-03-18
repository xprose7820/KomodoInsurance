using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _Developer;
using _DevTeam;
using _DeveloperRepo;
using _DevTeamRepo;

namespace _komodoUI
{
    public class KomodoUI
    {


        public void Run()
        {
            DeveloperRepo developerRepoObj = new DeveloperRepo();
            DevTeamRepo devTeamRepoObj = new DevTeamRepo();

            while (true)
            {
                string developerOrDevTeam = "";
                // select to go into developer or devTeam section
                while (true)
                {
                    System.Console.WriteLine("Welcome to the Komodo Management Application\n" +
                                             "Would you like to access the Developer or DevTeam Management Section?\n");
                    System.Console.WriteLine("1. Developer Management Section\n" +
                                             "2. DevTeam Management Section\n");
                    developerOrDevTeam = Console.ReadLine();
                    Console.Clear();
                    if (!(developerOrDevTeam == "1" || developerOrDevTeam == "2"))
                    {
                        System.Console.WriteLine("Not a valid option.\n");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                switch (developerOrDevTeam)
                {
                    // for developer section
                    case "1":
                        {


                            string developerOptions = "";
                            while (true)
                            {
                                System.Console.WriteLine("Developers Management Section\n");
                                System.Console.WriteLine("Please select from below: \n");
                                System.Console.WriteLine("1. Add a Developer\n" +
                                                         "2. Update Developer name, ID, and/or Pluralsight status\n" +
                                                         "3. Remove a Developer\n" +
                                                         "4. Get a Developer Info\n" +
                                                         "5. List all Developers\n" +
                                                         "6. List all Developers without Pluralsight license\n");
                                developerOptions = Console.ReadLine();
                                Console.Clear();
                                if (!(developerOptions == "1" || developerOptions == "2" || developerOptions == "3" || developerOptions == "4" || developerOptions == "5" || developerOptions == "6"))
                                {
                                    System.Console.WriteLine("Not a valid choice.\n");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            // after picking a choice from above options
                            switch (developerOptions)
                            {   // Add a developer
                                case "1":
                                    {
                                        System.Console.WriteLine("Please enter a name:");
                                        string devName = Console.ReadLine();

                                        string enterOrGenerate = "";
                                        while (true)
                                        {
                                            System.Console.WriteLine("Would you like to enter a unique ID or generate one?\n");
                                            System.Console.WriteLine("1. Enter unique ID\n" +
                                                                     "2. Generate one\n");
                                            enterOrGenerate = Console.ReadLine();
                                            if (!(enterOrGenerate == "1" || enterOrGenerate == "2"))
                                            {
                                                System.Console.WriteLine("Not a valid option.\n");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        string threeCharID = "";
                                        switch (enterOrGenerate)
                                        {   // if they select to enter id
                                            case "1":
                                                {

                                                    while (true)
                                                    {
                                                        System.Console.WriteLine("Please enter a 3 character ID, use only alphanumeric characters:\n");
                                                        threeCharID = Console.ReadLine();
                                                        if (isValidDeveloperID(threeCharID) == false)
                                                        {
                                                            System.Console.WriteLine("Not a valid ID.\n");
                                                            continue;
                                                        }
                                                        if (developerRepoObj.isDuplicateID(threeCharID) == true)
                                                        {
                                                            System.Console.WriteLine("This ID already exists.\n");
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }

                                                    }
                                                    break;
                                                }
                                            // if they select to generate id
                                            case "2":
                                                {

                                                    threeCharID = developerRepoObj.generateUniqueID();
                                                    break;
                                                }

                                        }
                                        System.Console.WriteLine("Do they have a Pluralsight license?\n");
                                        System.Console.WriteLine("1. Yes\n" +
                                                                 "2. No\n");

                                        string pluralChoice = "";
                                        while (true)
                                        {
                                            pluralChoice = Console.ReadLine();
                                            if (!(pluralChoice == "1" || pluralChoice == "2"))
                                            {
                                                System.Console.WriteLine("Not a valid choice.\n");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        bool hasLicense = false;
                                        switch (pluralChoice)
                                        {
                                            case "1":
                                                {
                                                    hasLicense = true;
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    hasLicense = false;
                                                    break;
                                                }

                                        }
                                        System.Console.WriteLine("What Team should they be assigned to?\n");
                                        System.Console.WriteLine("1. Assign to specific team\n" +
                                                                 "2. None\n");
                                        string willAssign = "";
                                        while (true)
                                        {
                                            willAssign = Console.ReadLine();
                                            System.Console.WriteLine("\n1");
                                            if (!(willAssign == "1" || willAssign == "2"))
                                            {
                                                System.Console.WriteLine("Not a valid choice.\n");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        string developerTeamName = "";
                                        string developerTeamAssignment = "";
                                        switch (willAssign)
                                        {
                                            case "1":
                                                {
                                                    if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                                    {
                                                        System.Console.WriteLine("There exists no teams.\n");
                                                        developerTeamName = "None";
                                                        break;

                                                    }
                                                    while (true)
                                                    {
                                                        System.Console.WriteLine("Please enter TeamID: \n");
                                                        developerTeamAssignment = Console.ReadLine();
                                                        if (isValidTeamID(developerTeamAssignment) == false)
                                                        {
                                                            System.Console.WriteLine("Not a valid TeamID.\n");
                                                            continue;
                                                        }
                                                        if (devTeamRepoObj.getDevTeamInfoByID(developerTeamAssignment) == null)
                                                        {
                                                            System.Console.WriteLine("Team doesn't exist.\n");
                                                            continue;
                                                        }

                                                        else
                                                        {
                                                            developerTeamName = devTeamRepoObj.getDevTeamInfoByID(developerTeamAssignment).getTeamName();
                                                            break;
                                                        }


                                                    }
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    developerTeamName = "None";
                                                    break;
                                                }
                                        }
                                        Developer developerPlaceholder = new Developer(devName, threeCharID, hasLicense, developerTeamName);
                                        if (developerTeamName != "None")
                                        {
                                            devTeamRepoObj.addTeamMemberToDevTeam(developerPlaceholder, developerTeamAssignment);
                                        }
                                        developerRepoObj.addDeveloper(developerPlaceholder);
                                        System.Console.WriteLine("Developer created!");
                                        break;
                                    }
                                // update developer
                                case "2":
                                    {
                                        if (developerRepoObj.getAllDevInDevRepo().Count == 0)
                                        {
                                            System.Console.WriteLine("You have no existing Developers.\n");
                                            break;
                                        }
                                        string updateDeveloperID = "";
                                        while (true)
                                        {
                                            System.Console.WriteLine("To Update a Developer, please enter the ID: \n");
                                            updateDeveloperID = Console.ReadLine();

                                            if (isValidDeveloperID(updateDeveloperID) == false)
                                            {
                                                System.Console.WriteLine("That is not a valid ID.\n");
                                                continue;
                                            }
                                            if (developerRepoObj.getDeveloperInfoByID(updateDeveloperID) == null)
                                            {
                                                System.Console.WriteLine("No such Developer exists.\n");
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        Developer updateDeveloper = developerRepoObj.getDeveloperInfoByID(updateDeveloperID);
                                        string originalDeveloperName = updateDeveloper.getName();
                                        string originalDeveloperID = updateDeveloper.getID();
                                        bool originalDeveloperPlural = updateDeveloper.getPS_Status();
                                        string originalDeveloperTeamName = updateDeveloper.getDevTeamName();

                                        bool insideUpdateLoop = true;
                                        string teamIDChoice = "";
                                        while (insideUpdateLoop)
                                        {
                                            string updateChoice = "";
                                            while (true)
                                            {
                                                System.Console.WriteLine("What would you like to update?\n");
                                                System.Console.WriteLine("1. Name\n" +

                                                                         "2. Pluralsight Status\n" +
                                                                         "3. Team change\n" +
                                                                         "4. Exit\n");
                                                updateChoice = Console.ReadLine();
                                                if (!(updateChoice == "1" || updateChoice == "2" || updateChoice == "3" || updateChoice == "4"))
                                                {
                                                    System.Console.WriteLine("Not a valid choice.\n");
                                                    continue;

                                                }
                                                else
                                                {
                                                    break;
                                                }


                                            }
                                            switch (updateChoice)
                                            {
                                                //update Name
                                                case "1":
                                                    {
                                                        System.Console.WriteLine("What name would you like to change to?\n");
                                                        originalDeveloperName = Console.ReadLine();
                                                        System.Console.WriteLine($"Name changed to {originalDeveloperName}.");
                                                        break;
                                                    }
                                                // //update ID
                                                // case "2":
                                                //     {
                                                //         while (true)
                                                //         {
                                                //             string counterID = Console.ReadLine();
                                                //             if (isValidDeveloperID(counterID) == false)
                                                //             {
                                                //                 System.Console.WriteLine("This is not a valid ID.")
                                                //                 continue;
                                                //             }
                                                //             else
                                                //             {
                                                //                 originalDeveloperID = counterID;
                                                //                 System.Console.WriteLine($"ID changed to {originalDeveloperID}.");
                                                //                 break;
                                                //             }
                                                //         }

                                                //         break;
                                                //     }
                                                // update pluralsight status
                                                case "2":
                                                    {
                                                        System.Console.WriteLine($"This individual current has Pluralsight license status of: {originalDeveloperPlural}\n");
                                                        System.Console.WriteLine("Would you like to change it to: \n");
                                                        System.Console.WriteLine("1. has license\n" +
                                                                                 "2. does not have license\n");
                                                        string licenseChoice = Console.ReadLine();
                                                        switch (licenseChoice)
                                                        {
                                                            case "1":
                                                                {
                                                                    originalDeveloperPlural = true;
                                                                    System.Console.WriteLine("Developer now has license.\n");
                                                                    break;
                                                                }
                                                            case "2":
                                                                {
                                                                    System.Console.WriteLine("Developer now does not have license.\n");
                                                                    originalDeveloperPlural = false;
                                                                    break;
                                                                }
                                                        }
                                                        break;

                                                    }
                                                // update team
                                                case "3":
                                                    {
                                                        System.Console.WriteLine("What team would you like to them to change to? Please type a teamID from below.\n");
                                                        List<DevTeam> listOfAllDevTeams = devTeamRepoObj.getListOfDevTeams();
                                                        if (listOfAllDevTeams.Count == 0)
                                                        {
                                                            System.Console.WriteLine("There are no teams available.\n");
                                                            break;
                                                        }
                                                        int counter = 1;
                                                        foreach (DevTeam devTeamItem in listOfAllDevTeams)
                                                        {
                                                            System.Console.WriteLine($"{devTeamItem.getTeamName()} | Unique TeamID: {devTeamItem.getTeamID()}\n");
                                                        }

                                                        while (true)
                                                        {
                                                            teamIDChoice = Console.ReadLine();
                                                            if (isValidTeamID(teamIDChoice) == false)
                                                            {

                                                                System.Console.WriteLine("This is an invalid ID.\n");
                                                                continue;

                                                            }
                                                            if (devTeamRepoObj.getDevTeamInfoByID(teamIDChoice) == null)
                                                            {
                                                                System.Console.WriteLine("No such team exists.\n");
                                                                continue;
                                                            }
                                                            else
                                                            {

                                                                originalDeveloperTeamName = devTeamRepoObj.getDevTeamInfoByID(teamIDChoice).getTeamName();
                                                                devTeamRepoObj.addTeamMemberToDevTeam(updateDeveloper, teamIDChoice);
                                                                devTeamRepoObj.removeTeamMemberFromDevTeam(updateDeveloper, teamIDChoice);
                                                                System.Console.WriteLine("Successfully added.\n");
                                                                break;
                                                            }
                                                        }

                                                        break;
                                                    }
                                                case "4":
                                                    {
                                                        developerRepoObj.updateDeveloperByID(originalDeveloperID, originalDeveloperName, originalDeveloperPlural, originalDeveloperTeamName);

                                                        insideUpdateLoop = false;
                                                        break;
                                                    }

                                            }
                                        }
                                        break;
                                    }
                                // remove a developer
                                case "3":
                                    {
                                        if (developerRepoObj.getListOfDevelopers().Count == 0)
                                        {
                                            System.Console.WriteLine("No developers exist.\n");
                                            break;
                                        }

                                        string removeByID = "";
                                        while (true)
                                        {
                                            System.Console.WriteLine("Enter the ID of Developer you want to remove: \n");
                                            removeByID = Console.ReadLine();
                                            if (isValidDeveloperID(removeByID) == false)
                                            {
                                                System.Console.WriteLine("That is not a valid ID.");
                                                continue;
                                            }
                                            if (developerRepoObj.getDeveloperInfoByID(removeByID) == null)
                                            {
                                                System.Console.WriteLine("This person does not exist.");
                                                continue;
                                            }
                                            else
                                            {
                                                developerRepoObj.removeDeveloperByID(removeByID);
                                                System.Console.WriteLine($"\"{removeByID}\" has been removed. ");
                                                break;
                                            }

                                        }


                                        break;
                                    }

                                case "4":
                                    {
                                        if (developerRepoObj.getListOfDevelopers().Count == 0)
                                        {
                                            System.Console.WriteLine("No developers exist.\n");
                                            break;
                                        }
                                        string threeCharID = "";
                                        while (true)
                                        {
                                            System.Console.WriteLine("Please enter their ID:\n");
                                            threeCharID = Console.ReadLine();
                                            if (isValidDeveloperID(threeCharID) == false)
                                            {
                                                System.Console.WriteLine("This is not a valid ID.\n");
                                                continue;
                                            }
                                            if (developerRepoObj.getDeveloperInfoByID(threeCharID) == null)
                                            {
                                                System.Console.WriteLine("No such person exists.\n");
                                                continue;

                                            }
                                            else
                                            {
                                                Developer devCounter = developerRepoObj.getDeveloperInfoByID(threeCharID);
                                                System.Console.WriteLine($"This is Developer \"{threeCharID}\"\n");
                                                System.Console.WriteLine($"{devCounter.getName()} | Unique ID: {devCounter.getID()} | Has Pluralsight License: {devCounter.getPS_Status()} | current Team: {devCounter.getDevTeamName()}\n");
                                                break;
                                            }
                                        }

                                        break;
                                    }

                                case "5":
                                    {

                                        List<Developer> myList = developerRepoObj.getAllDevInDevRepo();

                                        if (myList.Count == 0)
                                        {
                                            System.Console.WriteLine("You have no Developers");
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Here is a list of all Developers:\n");
                                            int count = 1;
                                            foreach (Developer devMember in myList)
                                            {
                                                System.Console.WriteLine($"{count}. {devMember.getName()} | Unique ID: {devMember.getID()} | Has Pluralsight License: {devMember.getPS_Status()} | current Team: {devMember.getDevTeamName()}\n");
                                                count++;
                                            }
                                        }
                                        break;
                                    }
                                case "6":
                                    {
                                        System.Console.WriteLine("Here is a list of all Developers who don't have a license:\n");
                                        List<Developer> doNotHaveLicense = developerRepoObj.returnListOfNonLicenseHolders();
                                        if (doNotHaveLicense.Count == 0)
                                        {
                                            System.Console.WriteLine("Everyone has a license.\n");
                                        }
                                        else
                                        {
                                            for (int i = 1; i < doNotHaveLicense.Count + 1; i++)
                                            {
                                                System.Console.WriteLine($"Name: {doNotHaveLicense[i - 1].getName()} | Unique ID: {doNotHaveLicense[i - 1].getID()}\n");
                                            }
                                        }

                                        break;
                                    }
                            }
                            break;
                        }
                    // devteam section
                    case "2":
                        {
                            string devTeamOptions = "";
                            while (true)
                            {
                                System.Console.WriteLine("DevTeam Management Section\n");
                                System.Console.WriteLine("Please select from below: \n");
                                System.Console.WriteLine("1. Create a Team\n" +
                                                         "2. Update Team name and/or ID\n" +
                                                         "3. Remove a Team\n" +
                                                         "4. Add Developer/s/ to an Existing Team\n" +
                                                         "5. List all Teams\n" +
                                                         "6. List all Developers of a Team\n" +
                                                         "7. List all Teams and their Developers\n");
                                devTeamOptions = Console.ReadLine();
                                if (!(devTeamOptions == "1" || devTeamOptions == "2" || devTeamOptions == "3" || devTeamOptions == "4" || devTeamOptions == "5" || devTeamOptions == "6" || devTeamOptions == "7"))
                                {
                                    System.Console.WriteLine("Not a valid choice.\n");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            switch (devTeamOptions)
                            {
                                // creating a team
                                case "1":
                                    {
                                        System.Console.WriteLine("Please enter a Team Name: \n");
                                        string inputTeamName = Console.ReadLine();
                                        System.Console.WriteLine("Would you like to input or generate a TeamID? \n");
                                        System.Console.WriteLine("1. Input TeamID\n" +
                                                                 "2. Generate TeamID\n");
                                        string inputTeamID_Choice = "";
                                        while (true)
                                        {
                                            inputTeamID_Choice = Console.ReadLine();
                                            if (!(inputTeamID_Choice == "1" || inputTeamID_Choice == "2"))
                                            {
                                                System.Console.WriteLine("Not a valid choice.\n");
                                                continue;

                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }

                                        string inputTeamID = "";

                                        switch (inputTeamID_Choice)
                                        {
                                            case "1":
                                                {
                                                    while (true)
                                                    {
                                                        System.Console.WriteLine("Please enter 4 character TeamID, use only alphanumeric values.\n");

                                                        inputTeamID = Console.ReadLine();
                                                        if (isValidTeamID(inputTeamID) == false)
                                                        {

                                                            System.Console.WriteLine("Not a valid TeamID.\n");
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            inputTeamID = devTeamRepoObj.generateUniqueID();
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                }
                                            // generate teamid
                                            case "2":
                                                {
                                                    inputTeamID = devTeamRepoObj.generateUniqueID();
                                                    break;

                                                }
                                        }

                                        DevTeam counterDevTeam = new DevTeam(inputTeamName, inputTeamID);
                                        devTeamRepoObj.addDevTeam(counterDevTeam);
                                        System.Console.WriteLine("DevTeam added!\n");



                                        break;
                                    }
                                //update Team name
                                case "2":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("There exists no Teams. \n");
                                            break;
                                        }
                                        System.Console.WriteLine("Please enter the Team's Unique ID: \n");
                                        string inputUpdateTeamID = "";
                                        while (true)
                                        {
                                            inputUpdateTeamID = Console.ReadLine();
                                            if (isValidTeamID(inputUpdateTeamID) == false)
                                            {
                                                System.Console.WriteLine("Not a valid TeamID.\n");
                                                continue;
                                            }
                                            if (devTeamRepoObj.getDevTeamInfoByID(inputUpdateTeamID) == null)
                                            {
                                                System.Console.WriteLine("No such Team exists.\n");
                                                continue;

                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        System.Console.WriteLine($"Current Team's name is: {devTeamRepoObj.getDevTeamInfoByID(inputUpdateTeamID).getTeamName()}.");
                                        System.Console.WriteLine("What would you like to change it to?\n");
                                        string newInputTeamName = Console.ReadLine();
                                        devTeamRepoObj.getDevTeamInfoByID(inputUpdateTeamID).setTeamName(newInputTeamName);
                                        System.Console.WriteLine("Successfully updated Team Name!\n");



                                        break;
                                    }
                                // Remove team
                                case "3":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("There are no Teams to remove. \n");
                                            break;
                                        }
                                        System.Console.WriteLine("Please enter the ID of the Team you would like to remove.\n");
                                        string removeTeamFromID = "";
                                        while (true)
                                        {
                                            removeTeamFromID = Console.ReadLine();
                                            if (isValidTeamID(removeTeamFromID) == false)
                                            {
                                                System.Console.WriteLine("Not a valid TeamID. \n");
                                                continue;
                                            }
                                            if (devTeamRepoObj.getDevTeamInfoByID(removeTeamFromID) == null)
                                            {
                                                System.Console.WriteLine("No such team exists.\n");
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        if (devTeamRepoObj.getDevTeamInfoByID(removeTeamFromID).getTeamMembers().Count != 0)
                                        {
                                            foreach (Developer devMember in devTeamRepoObj.getDevTeamInfoByID(removeTeamFromID).getTeamMembers())
                                            {
                                                devMember.setDevTeamName("None");
                                            }
                                        }
                                        devTeamRepoObj.removeDevTeamFromRepo(devTeamRepoObj.getDevTeamInfoByID(removeTeamFromID));
                                        System.Console.WriteLine("Successfully removed Team from Repo!\n");
                                        break;
                                    }
                                // add develoepr to existing team
                                case "4":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("No teams exist.\n");
                                            break;
                                        }
                                        System.Console.WriteLine("What Team would you like to add to? Please enter the TeamID from the list below: \n");
                                        foreach (DevTeam devTeamObj in devTeamRepoObj.getListOfDevTeams())
                                        {

                                            System.Console.WriteLine($"Team Name: {devTeamObj.getTeamName()} | Unique TeamID: {devTeamObj.getTeamID()}\n");
                                        }
                                        string pickTeamIDFromList = "";
                                        while (true)
                                        {
                                            pickTeamIDFromList = Console.ReadLine();
                                            if (isValidTeamID(pickTeamIDFromList) == false)
                                            {
                                                System.Console.WriteLine("Not a valid TeamID.\n");
                                                continue;
                                            }
                                            if (devTeamRepoObj.getDevTeamInfoByID(pickTeamIDFromList) == null)
                                            {
                                                System.Console.WriteLine("No such team exists. \n");
                                                continue;
                                            }
                                            else
                                            {
                                                break;

                                            }
                                        }
                                        // we found team, and now can add developers
                                        if (developerRepoObj.getListOfDevelopers().Count == 0)
                                        {
                                            System.Console.WriteLine("You don't have any Developer's available. \n");
                                            break;
                                        }

                                        while (true)
                                        {
                                            if (developerRepoObj.getListOfDevelopers().Count == 0)
                                            {
                                                System.Console.WriteLine("You don't have any Developer's available. \n");
                                                break;
                                            }

                                            string inputListOfDeveloperIDToAdd = "";
                                            bool exitAddLoop = true;
                                            while (exitAddLoop)
                                            {
                                                System.Console.WriteLine("Here is a list of available Developers. Please list out IDs, with spaces in between, of as many Developers you want to add: \n");
                                                foreach (Developer devMember in developerRepoObj.notInATeam())
                                                {

                                                    System.Console.WriteLine($"Name: {devMember.getName()} | Unique ID: {devMember.getID()} | Has Pluralsight License: {devMember.getPS_Status()} | Current Team: {devMember.getDevTeamName()}");
                                                }
                                                inputListOfDeveloperIDToAdd = Console.ReadLine();
                                                string[] parsedListToGetDevelopers = inputListOfDeveloperIDToAdd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                                foreach (string developerID in parsedListToGetDevelopers)
                                                {
                                                    if (isValidDeveloperID(developerID) == false)
                                                    {
                                                        System.Console.WriteLine("One or more IDs were invalid, please try again.\n");
                                                        break;
                                                    }
                                                    if (developerRepoObj.getDeveloperInfoByID(developerID) == null)
                                                    {
                                                        System.Console.WriteLine("One of more Developers don't exist, please try again. \n");
                                                        break;
                                                    }
                                                    else
                                                    {

                                                        devTeamRepoObj.addTeamMemberToDevTeam(developerRepoObj.getDeveloperInfoByID(developerID), pickTeamIDFromList);
                                                        developerRepoObj.getDeveloperInfoByID(developerID).setDevTeamName(devTeamRepoObj.getDevTeamInfoByID(pickTeamIDFromList).getTeamName());
                                                        exitAddLoop = false;
                                                    }
                                                }


                                            }
                                            System.Console.WriteLine("Developer/s/ have been added!\n");
                                            break;


                                        }


                                        break;

                                    }
                                // list all teams
                                case "5":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("No teams exist. \n");
                                            break;
                                        }
                                        System.Console.WriteLine("Here is a list of all Teams: \n");
                                        foreach (DevTeam devTeamObj in devTeamRepoObj.getListOfDevTeams())
                                        {
                                            System.Console.WriteLine($"Team Name: {devTeamObj.getTeamName()} | Unique TeamID: {devTeamObj.getTeamID()}\n");
                                        }
                                        break;
                                    }
                                // list all members of a team
                                case "6":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("No teams exist. \n");
                                            break;
                                        }

                                        string inputToViewMembers = "";
                                        while (true)
                                        {
                                            System.Console.WriteLine("Please type a TeamID below to view it\'s members:\n ");
                                            foreach (DevTeam devTeamObj in devTeamRepoObj.getListOfDevTeams())
                                            {
                                                System.Console.WriteLine($"Team name: {devTeamObj.getTeamName()} | Unique ID: {devTeamObj.getTeamID()}\n");
                                            }
                                            inputToViewMembers = Console.ReadLine();
                                            if (isValidTeamID(inputToViewMembers) == false)
                                            {
                                                System.Console.WriteLine("Not a valid TeamID. \n");
                                                continue;
                                            }
                                            if (devTeamRepoObj.getDevTeamInfoByID(inputToViewMembers) == null)
                                            {
                                                System.Console.WriteLine("No such team exists. \n");
                                                continue;

                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        System.Console.WriteLine("Here are the Team Members: \n");
                                        System.Console.WriteLine($"Team Name: {devTeamRepoObj.getDevTeamInfoByID(inputToViewMembers).getTeamName()} | Unique TeamID: {devTeamRepoObj.getDevTeamInfoByID(inputToViewMembers).getTeamID()}\n");
                                        foreach (Developer devMember in devTeamRepoObj.getDevTeamInfoByID(inputToViewMembers).getTeamMembers())
                                        {
                                            System.Console.WriteLine($"        Name: {devMember.getName()} | Unique ID: {devMember.getID()} | Has PluralSight License: {devMember.getPS_Status()}\n");

                                        }
                                        break;
                                    }
                                case "7":
                                    {
                                        if (devTeamRepoObj.getListOfDevTeams().Count == 0)
                                        {
                                            System.Console.WriteLine("No Teams exist.\n");
                                            break;
                                        }
                                        System.Console.WriteLine("Here is a list of all Teams and their members: \n");
                                        foreach (DevTeam devTeamObj in devTeamRepoObj.getListOfDevTeams())
                                        {
                                            System.Console.WriteLine($"Team Name: {devTeamObj.getTeamName()} | Unique TeamID: {devTeamObj.getTeamID()}\n");
                                            foreach (Developer devMember in devTeamObj.getTeamMembers())
                                            {
                                                System.Console.WriteLine($"        Name: {devMember.getName()} | Unique ID: {devMember.getID()} | Has PluralSight License: {devMember.getPS_Status()}\n");
                                            }
                                        }
                                        break;
                                    }
                            }


                        }
                        break;
                }

            }

        }
        public bool isValidDeveloperID(string threeCharID)
        {
            if (threeCharID.Length != 3)
            {
                return false;
            }
            string counter = "0123456789abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 3; i++)
            {
                if (counter.Contains(threeCharID[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool isValidTeamID(string fourCharID)
        {
            if (fourCharID.Length != 4)
            {
                return false;
            }
            string counter = "0123456789abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < 4; i++)
            {
                if (counter.Contains(fourCharID[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

    }



}

